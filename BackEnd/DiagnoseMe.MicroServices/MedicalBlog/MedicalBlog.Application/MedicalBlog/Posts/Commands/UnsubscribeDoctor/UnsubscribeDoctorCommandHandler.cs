using ErrorOr;
using MediatR;
using MedicalBlog.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalBlog.Application.Common.Interfaces.Persistence.IUnitOfWork;
using MedicalBlog.Application.MedicalBlog.Common;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Posts.Commands.UnsubscribeDoctor;

public class UnsubscribeDoctorCommandHandler : IRequestHandler<UnsubscribeDoctorCommand, ErrorOr<CommandResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UnsubscribeDoctorCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(UnsubscribeDoctorCommand command, CancellationToken cancellationToken)
    {
        var doctor = (await _userRepository.Get(
            predicate: x => x.Id == command.DoctorId,
            include: "Subscribers"))
            .FirstOrDefault();

        if (doctor == null)
            return Errors.User.DoctorNotFound;
        
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user == null)
            return Errors.User.NotFound;
        
        if (doctor.Id == user.Id)
            return Errors.User.YouCanNotDoThis;
        
        if (!doctor.Subscribers.Any(x => x.Id == user.Id))
            return Errors.User.AlreadySubscribed;
        
        doctor.Subscribers.Remove(user);

        if (await _unitOfWork.Save() == 0)
            return Errors.User.FailedToUnsubscribe;
        return new CommandResponse(
            true,
            $"You have successfully unsubscribed from this doctor with id {command.DoctorId}.",
            null!);
    }
}