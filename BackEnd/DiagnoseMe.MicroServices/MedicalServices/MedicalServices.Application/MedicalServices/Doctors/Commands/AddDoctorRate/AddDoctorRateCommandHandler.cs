using ErrorOr;
using MediatR;
using MedicalServices.Application.Common.Interfaces.Persistence.IRepositories;
using MedicalServices.Application.Common.Interfaces.Persistence.IUnitOfWork;
using MedicalServices.Application.MedicalServices.Common;
using MedicalServices.Domain.Common.Errors;

namespace MedicalServices.Application.MedicalServices.Doctors.Commands.AddDoctorRate;

public class AddDoctorRateCommandHandler : IRequestHandler<AddDoctorRateCommand, ErrorOr<CommandResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IDoctorRateRepository _doctorRateRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddDoctorRateCommandHandler(
        IUserRepository userRepository,
        IDoctorRateRepository doctorRateRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _doctorRateRepository = doctorRateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CommandResponse>> Handle(AddDoctorRateCommand command, CancellationToken cancellationToken)
    {
        var doctorUser = (await _userRepository.Get(
            predicate: x => x.Id == command.DoctorId,
            include: "Doctor"
        )).FirstOrDefault();
    
        if (doctorUser == null || !doctorUser.IsDoctor)
            return Errors.Doctor.NotFound;
        
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user == null)
            return Errors.User.NotFound;

        var doctorRates = (await _doctorRateRepository.Get(
            predicate: x => x.DoctorId == command.DoctorId
        )).ToList();

        var userDoctorRate = doctorRates.FirstOrDefault(x => x.UserId == command.UserId);

        if (userDoctorRate != null){
            doctorUser.Doctor!.AverageRate = (doctorRates.Sum(x => x.Rate) - userDoctorRate.Rate + command.Rate) / (doctorRates.Count);
            userDoctorRate.Rate = command.Rate;
            userDoctorRate.Comment = command.Comment;
            await _doctorRateRepository.Edit(userDoctorRate);
        }
        else{
            doctorUser.Doctor!.AverageRate = doctorRates.Count == 0
            ? command.Rate
            : (doctorRates.Sum(x => x.Rate) + command.Rate) / (doctorRates.Count + 1);
            userDoctorRate = new DoctorRate{
                Rate = command.Rate,
                Comment = command.Comment,
                UserId = command.UserId,
                DoctorId = command.DoctorId
            };

            userDoctorRate.User = user;
            userDoctorRate.Doctor = doctorUser.Doctor;
            await _doctorRateRepository.AddAsync(userDoctorRate);
        }

        if (await _unitOfWork.Save() == 0)
            return Errors.Doctor.Rate.AddFailed;
        
        return new CommandResponse(
            Success: true,
            Message: "Doctor rate added successfully.",
            Path: $"Doctors/{command.DoctorId}"
        );
    }
}