using BirdTrading.Interface;
using BirdTrading.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdTradingApp.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public LoginViewModel LoginModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var login = await _unitOfWork.UserRepository
                    .GetUserByEmailOrPhoneAndPasswordAsync(LoginModel.UserName, LoginModel.Password);
                if (login is not null)
                {
                    HttpContext.Session.SetString("Role", login.Role.ToString());
                    HttpContext.Session.SetInt32("Id", login.Id);
                    HttpContext.Session.SetString("Name", login.Name);
                    TempData["success"] = "Login Succeed";
                    return RedirectToPage("/Index");
                }
                ModelState.AddModelError(string.Empty, "Incorrect account, please check again.");
            }

            return Page();
        }
    }
}