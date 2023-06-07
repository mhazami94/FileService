using FileService.Application.Core.CQRS.QueryHandling;
using FluentValidation;
using FluentValidation.Results;

namespace FileService.Application.Owner.AuthenticateOwner;

public record class AuthenticateOwnerQuery : Query<OwnerViewModel>
{
    public string Email { get; init; }
    public string Password { get; init; }

    public AuthenticateOwnerQuery(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public override ValidationResult Validate()
    {
        return new AuthenticateOwnerQueryValidator().Validate(this);
    }
}

public class AuthenticateOwnerQueryValidator : AbstractValidator<AuthenticateOwnerQuery>
{
    public AuthenticateOwnerQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is empty");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is empty");
    }
}