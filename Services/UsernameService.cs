using UsernameValidationService.Data;
using UsernameValidationService.Models;
using Microsoft.EntityFrameworkCore;

namespace UsernameValidationService.Services
{
    public class UsernameService : IUsernameService
    {
        private readonly AppDbContext _context;

        public UsernameService(AppDbContext context)
        {
            _context = context;
        }

        public bool IsValidUsername(string username)
        {
            return !string.IsNullOrWhiteSpace(username)
                && username.Length >= 6 && username.Length <= 30
                && username.All(char.IsLetterOrDigit);
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _context.Usernames.AnyAsync(x => x.Username == username);
        }

        public async Task<bool> AddOrUpdateUsernameAsync(Guid accountId, string username)
        {
            if (!IsValidUsername(username)) return false;

            if (await UsernameExistsAsync(username)) return false;

            var existing = await _context.Usernames.FindAsync(accountId);
            if (existing != null)
                _context.Usernames.Remove(existing);

            _context.Usernames.Add(new UsernameEntry
            {
                AccountId = accountId,
                Username = username
            });

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
