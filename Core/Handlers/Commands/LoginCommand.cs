using Core.Enums;
using Core.Interface.Services;
using Core.Models.Response;
using FluentValidation;
using MediatR;

namespace Core.Handlers.Commands;

public class LoginCommand : IRequest<ResponseEntity<LoginResponse>>
{
    public string LoginValue { get; set; }
    public string Password { get; set; }
}

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.LoginValue).NotEmpty().NotNull();
        RuleFor(x => x.Password).NotEmpty().NotNull();       
    }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseEntity<LoginResponse>> 
{
    private readonly IJwtService _jwtService;
    public LoginCommandHandler(IJwtService jwtService)
    {
        _jwtService = jwtService;  
    }

    public async Task<ResponseEntity<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            cancellationToken.ThrowIfCancellationRequested();
        }

        await  Task.Delay(500);
        var jwtToken = _jwtService.GetAccessToken("Damilola", "Israel", request.LoginValue, Role.Admin);
        return new ResponseEntity<LoginResponse>()
        {
            Code = "E20",
            Message = "Completed",
            Data = new LoginResponse()
            {
                Jwt = jwtToken
            }
        };
    }
}
