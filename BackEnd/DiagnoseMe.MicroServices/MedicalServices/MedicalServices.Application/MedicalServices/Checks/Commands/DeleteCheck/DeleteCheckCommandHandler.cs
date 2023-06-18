using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Checks.Commands.DeleteCheck;

public class DeleteCheckCommandHandeler : IRequestHandler<DeleteCheckCommand, ErrorOr<CommandResponse>>
{
    private readonly ICheckRepository _checkRepository;
    

    public DeleteCheckCommandHandeler(ICheckRepository checkRepository)
    {
        _checkRepository = checkRepository;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(DeleteCheckCommand command, CancellationToken cancellationToken)
    {
        var check = await _checkRepository.GetByIdAsync(command.CheckId);
        if (check is null)
            return Errors.Check.NotFound;
        

        if (check.PatientId != command.UserId)
            return Errors.User.YouCanNotDoThis;
        

        _checkRepository.Remove(check);
        if (await _checkRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Check.DeleteFailed;
        return new CommandResponse(
            Success: true,
            Message: "Check deleted successfully.",
            Path: null!
        );
    }
}