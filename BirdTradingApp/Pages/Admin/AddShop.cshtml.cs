using BirdTrading.Domain.Models;
using BirdTrading.Interface;
using BirdTrading.Repository.DTO;
using BirdTradingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdTradingApp.Pages.Admin
{
    public class AddShopModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Shop AddShopDTO { get; set;} 
        public List<User> Users { get; set; }
        public AddShopModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnGet()
        {
            User userLogin = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (userLogin == null)
            {
                return RedirectToPage("/Login/Index");
            }
            List<Shop> shops = _unitOfWork.ShopRepository.GetAll();
            List<int> shopIds = (from s in shops
                                 select s.UserId).ToList();
            Users = _unitOfWork.UserRepository.GetAllUsersExceptAdmin().FindAll(x => x.Role == BirdTrading.Domain.Enums.UserRole.ShopOwner && shopIds.Contains(x.Id) == false);
            return Page();
        }
        public IActionResult OnPost()
        {
            AddShopDTO.IsBlocked = false;
            AddShopDTO.Rating = 5;
            string result = _unitOfWork.ShopRepository.AddShop(AddShopDTO);
            if(result.Equals("Email is exist"))
            {
                Users = _unitOfWork.UserRepository.GetAllUsersExceptAdmin().FindAll(x => x.Role == BirdTrading.Domain.Enums.UserRole.ShopOwner);
                ViewData["EmailError"] = "Email is exist";
                return Page();
            }
            TempData["NotificationMessage"] = "Add new shop successfully";
            return RedirectToPage("/Admin/ShopManagement");
        }
    }
}
