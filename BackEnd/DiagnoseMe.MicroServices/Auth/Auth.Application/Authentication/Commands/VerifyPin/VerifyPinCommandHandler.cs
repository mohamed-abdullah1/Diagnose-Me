
namespace Auth.Application.Authentication.Commands.VerifyPin;

public class VerifyPinCommandHandler:
    BaseAuthenticationHandler,
    IRequestHandler<VerifyPinCommand, ErrorOr<PinIdResponse>>
{

    private readonly ISmtp _smtp;
    private readonly IMemoryCache _memoryCache;
    public VerifyPinCommandHandler(
        UserManager<ApplicationUser> userManager,
        ISmtp smtp,
        IMemoryCache memoryCache
    ): base(userManager)
    {
        _smtp = smtp;
        _memoryCache = memoryCache;
    }

    public Task<ErrorOr<PinIdResponse>> Handle(VerifyPinCommand command, CancellationToken cancellationToken)
    {
        if(command.PinCode == null)
            return Task.FromResult<ErrorOr<PinIdResponse>>(Errors.User.Pin.PinCode.Null);

        var jsonPin = _memoryCache.Get<string>(command.PinCode);

        if(jsonPin == null)
            return Task.FromResult<ErrorOr<PinIdResponse>>(Errors.User.Pin.Expired);

        var pin = JsonConvert.DeserializeObject<Pin>(jsonPin);  
        _memoryCache.Remove(command.PinCode);
        jsonPin = JsonConvert.SerializeObject(pin);
        var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(10));
        _memoryCache.Set(pin!.Id, jsonPin, cacheEntryOptions);
        return Task.FromResult<ErrorOr<PinIdResponse>>(
            new PinIdResponse(pin.Id));
    }
}