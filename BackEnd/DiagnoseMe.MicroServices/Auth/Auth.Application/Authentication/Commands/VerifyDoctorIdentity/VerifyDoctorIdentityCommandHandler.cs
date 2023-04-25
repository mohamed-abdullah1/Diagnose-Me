using Auth.Application.Common.Interfaces.AI;
using Auth.Application.Common.Interfaces.RabbitMQ;
using MapsterMapper;

namespace Auth.Application.Authentication.Commands.VerifyDoctorIdentity;


public class VerifyDoctorIdentityCommandHandler: 
    BaseAuthenticationHandler,
    IRequestHandler<VerifyDoctorIdentityCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IDoctorIdentifyService _doctorIdentifyService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IMessageQueueManager _messageQueueManager;
    private readonly IMapper _mapper;

    public VerifyDoctorIdentityCommandHandler(
        UserManager<ApplicationUser> userManager,
        IDoctorIdentifyService doctorIdentifyService,
        IMessageQueueManager messageQueueManager,
        IMapper mapper,
        IJwtTokenGenerator jwtTokenGenerator): base(userManager)
    {
        _doctorIdentifyService = doctorIdentifyService;
        _jwtTokenGenerator = jwtTokenGenerator;
        _messageQueueManager = messageQueueManager;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(VerifyDoctorIdentityCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(command.UserName);
        if(user == null)
            return Errors.User.Name.NotExists;
       
        var result = await _doctorIdentifyService.CheckIfDoctor(command.Base64License);
        if(result.IsError)
            return result.Errors;
        
        user!.IsDoctor = result.Value;

        if(user.IsDoctor){
            var roleResult = await _userManager.AddToRoleAsync(user, Roles.Doctor);
            if(!roleResult.Succeeded)
                return Errors.User.MapIdentityError(roleResult.Errors.ToList());
        }
            
        var updateResult = await _userManager.UpdateAsync(user);
        if(!updateResult.Succeeded)
            return Errors.User.MapIdentityError(updateResult.Errors.ToList());
        
        _messageQueueManager.UpdateUser(_mapper.Map<ApplicationUserResponse>(user));
        return new AuthenticationResult{
            Message = $"User {user.UserName} is {(user.IsDoctor ? "doctor" : "not doctor")}",
            Token = "Bearer " + (new JwtSecurityTokenHandler().WriteToken(_jwtTokenGenerator
            .GenerateJwtTokenAsync(
            user.Id,
            user.UserName!,
            await GetUserClaims(user)))),
            Username = user.UserName
        };
    }
}