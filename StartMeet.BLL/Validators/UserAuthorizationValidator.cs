

using FluentValidation;
using StartMeet.BLL.Users;
using StartMeet.Model.Users;

namespace StartMeet.BLL.Validators
{
    public class UserAuthorizationValidator : AbstractValidator<AppUser>
    {
        public UserAuthorizationValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.SecondName)
                .NotEmpty();
        }
    }
}
