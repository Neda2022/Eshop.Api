

using Common.Application;
using Common.Application.Validation.FluentValidations;

namespace Shop.Application.Users.Rejester;

public record RegisterUserCommand(string PhoneNumber, string Password):IBaseCommand;
