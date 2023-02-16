using Microsoft.VisualBasic;


namespace UserManagementApp.Interfaces
{
    public interface IGetUsersData
    {
        Task<int> GetTodayRegisteredUsersCount();
        Task<int> GetTodayNotVerifiedUsersCount();
        Task<double> GetTodayRegisterationAverageSeconds();
    }
}
