using Models;

namespace Validations.Services
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = string.Empty; 

        public IEnumerable<ErrorList>? errors { get; set; }    
    }
}
