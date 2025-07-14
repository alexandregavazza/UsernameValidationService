using UsernameValidationService.Models;

namespace UsernameValidationService.Services
{
    public interface IUsernameService
    {
        bool IsValidUsername(string username);
        Task<bool> AddOrUpdateUsernameAsync(Guid accountId, string username);
        Task<bool> UsernameExistsAsync(string username);
    }
}
