using Microsoft.EntityFrameworkCore;
using UserManagementApp.Data;
using UserManagementApp.Interfaces;

namespace UserManagementApp.Services
{
    public class GetUsersData : IGetUsersData
    {
        private readonly UserDbContext _context;

        public GetUsersData(UserDbContext context)
        {
            _context = context;
        }
        public async Task<int> GetTodayNotVerifiedUsersCount()
        {
            var hayvan = await _context.Users.Where(w =>
            !w.EmailConfirmed &&
            w.AccountCreationDate.Value.Date == DateTime.Now.Date).CountAsync();
            return hayvan;
        }

        public async Task<int> GetTodayRegisteredUsersCount()
        {
            var hayvan = await _context.Users.Where(w =>
            w.EmailConfirmed &&
            w.AccountVerificationDate.Value.Date == DateTime.Now.Date).CountAsync();
            return hayvan;
        }

       
        public async Task<double> GetTodayRegisterationAverageSeconds()
        {
            var hayvan = await _context.Users.Where(w => w.EmailConfirmed && w.AccountVerificationDate.Value.Date == DateTime.Now.Date).ToListAsync();
            double totalSeconds = 0;
            foreach (var item in hayvan)
            {
                TimeSpan ts = item.AccountVerificationDate.Value.Subtract(item.AccountCreationDate.Value);
                totalSeconds += ts.TotalSeconds;
            }
            return totalSeconds / hayvan.Count;
        }
    }
}
