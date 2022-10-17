using FluentValidation;
using Models;
using Validatiors;

namespace Validations.Services
{
    public interface IUserServices
    {
        Task<ServiceResponse<List<User>>> postAUser(User request);
    }

}

