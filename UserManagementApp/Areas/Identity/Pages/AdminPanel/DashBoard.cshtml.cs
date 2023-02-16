using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementApp.Areas.Identity.Data;
using UserManagementApp.Dto;
using UserManagementApp.Interfaces;

namespace UserManagementApp.Areas.Identity.Pages.AdminPanel
{
    public class DashBoardModel : PageModel
    {

        public DailyUserData Data { get; set; }
        private readonly IGetUsersData _getUsersData;

        public DashBoardModel(IGetUsersData getUsersData)
        {
            _getUsersData = getUsersData;
            Data = new DailyUserData();


        }

        public async Task OnGetAsync()
        {

            Data.DailyAverageVerifiedSeconds = await _getUsersData.GetTodayRegisterationAverageSeconds();
            Data.DailyNotVerifiedUsersCount = await _getUsersData.GetTodayNotVerifiedUsersCount();
            Data.DailyRegisteredUsersCount = await _getUsersData.GetTodayRegisteredUsersCount();

        }
    }
}
