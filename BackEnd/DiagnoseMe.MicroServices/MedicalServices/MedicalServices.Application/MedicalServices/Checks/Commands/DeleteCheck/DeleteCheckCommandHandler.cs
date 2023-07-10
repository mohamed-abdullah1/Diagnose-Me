using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.Common.Interfaces.RabbitMq;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;
using MedicalServices.Domain.Common.Roles;

namespace MedicalServices.Application.MedicalServices.Checks.Commands.DeleteCheck;

public class DeleteCheckCommandHandeler : IRequestHandler<DeleteCheckCommand, ErrorOr<CommandResponse>>
{
    private readonly ICheckRepository _checkRepository;
    private readonly IMessageQueueManager   _messageQueueManager;
    

    public DeleteCheckCommandHandeler(
        ICheckRepository checkRepository,
        IMessageQueueManager messageQueueManager)
    {
        _checkRepository = checkRepository;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(DeleteCheckCommand command, CancellationToken cancellationToken)
    {
        var check = (await _checkRepository.Get(
            predicate: c => c.Id == command.CheckId,
            include: "CheckFiles")).FirstOrDefault();
        if (check is null)
            return Errors.Check.NotFound;
        

        if (!(check.PatientId == command.UserId ||
            check.DoctorId == command.UserId || 
            command.Roles.Contains(Roles.Admin)))
            return Errors.User.YouCanNotDoThis;
        

        _checkRepository.Remove(check);
        if (await _checkRepository.SaveAsync(cancellationToken) == 0)
            return Errors.Check.DeleteFailed;
        
        _messageQueueManager.DeleteFile(check.CheckFiles.Select(cf => cf.FileUrl).ToList());
        return new CommandResponse(
            Success: true,
            Message: "Check deleted successfully.",
            Path: null!
        );
    }
}