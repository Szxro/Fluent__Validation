using FluentValidation;
using Models;
using Validatiors;

namespace Validations.Services
{
    public class UserServices : IUserServices
    {
        private static List<User> users = new List<User>();
        private readonly IValidator<User> _validator;
        public UserServices(IValidator<User> validator)
        {
            _validator = validator;
        }

        public async Task<ServiceResponse<List<User>>> postAUser(User request)
        {
            var errors = new List<ErrorList>() { };
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                foreach (var e in validation.Errors)
                {
                    var error = new ErrorList() { ErrorField = e.PropertyName,ErrorDescription = e.ErrorMessage };
                    errors.Add(error);
                }
                return new ServiceResponse<List<User>>() { errors = errors, Message = "Something Happen", Success = false };
            }

            try
            {
                var user = new User() { Name = request.Name, Number = request.Number, LastName = request.LastName };
                users.Add(user);
                return new ServiceResponse<List<User>>() { Data = users };
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<User>>() { Message = e.Message, Success = false };
            }
        }
    }
}
