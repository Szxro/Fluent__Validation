using FluentValidation;
using Models;

namespace Validatiors
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            Include(new UserSimpleValidator());
            Include(new UserComplexValidator()); 

        }
    }


    public class UserNameValidator : AbstractValidator<UserName>
    {
        public UserNameValidator()
        {
          RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("The Child Fild have to be fill");
        }
    }

    public class UserSimpleValidator : AbstractValidator<User> 
    {
        public UserSimpleValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty().WithMessage("The Name field must be fill");
            // RuleFor(c => c.Name).Must(x => x?.StartsWith("S") == true).WithMessage("The Name fill need a S");
            RuleFor(c => c.Number).NotNull().WithMessage("The Number Field must be fill");
            RuleFor(c => c.Number).NotEqual(0).WithMessage("The Number must be higher than zero");
            RuleFor(c => c.LastName).NotEmpty().NotNull().WithMessage("The LastName Field must be fill");
        }
    }

    public class UserComplexValidator : AbstractValidator<User>
    {
        public UserComplexValidator()
        {
            RuleForEach(x => x.names)
                    .SetValidator(new UserNameValidator());
        }
    }
}