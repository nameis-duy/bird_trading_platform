using BirdTrading.Domain.Enums;
using BirdTrading.Domain.Models;
using BirdTrading.Interface;
using BirdTrading.Repository.Repositories;
using BirdTradingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BirdTradingApp.Pages.Shops
{
    public class WaitingConfirmModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public WaitingConfirmModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public SelectList Options { get; set; }
        public List<Order> Order { get; set; }
        public List<ShippingSession> ShippingSession { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public string CurrentFilter { get; set; }
        public int? Session { get; set; }
        public bool checkNull = false;
        public async Task OnGetAsync(string searchString, string searchBy)
        {
            bool validate = false;
            bool checkcancel = false;
            var currentUserLoginId = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user").Id;
            var shopid = _unitOfWork.ShopRepository.GetShopsUserIdAysnc((int)currentUserLoginId).Result.Id;
            var productlist = _unitOfWork.ProductRepository.GetByShopIdAsync((int)shopid);
            foreach (var item in productlist.Result)
            {
                if (OrderDetail == null)
                {
                    OrderDetail = _unitOfWork.OrderDetailRepository.GetByProductIdAsync(item.Id).Result;
                    continue;
                }
                if (OrderDetail != null)
                {
                    OrderDetail.AddRange(_unitOfWork.OrderDetailRepository.GetByProductIdAsync(item.Id).Result);
                    continue;
                }
            }
            foreach (var item in OrderDetail)
            {
                if (ShippingSession == null)
                {
                    ShippingSession = _unitOfWork.ShippingSessionRepository.GetByOrderDetailIdAndStatusAsync(item.Id, OrderStatus.WaitingForConfirm).Result;
                    continue;
                }
                if (ShippingSession != null)
                {
                    ShippingSession.AddRange(_unitOfWork.ShippingSessionRepository.GetByOrderDetailIdAndStatusAsync(item.Id, OrderStatus.WaitingForConfirm).Result);
                    continue;
                }

            }
            foreach (var item in ShippingSession)
            {
                checkcancel=_unitOfWork.ShippingSessionRepository.CheckStatus(item.OrderId, OrderStatus.Cancel);
                validate = _unitOfWork.ShippingSessionRepository.CheckStatus(item.OrderId, OrderStatus.WaitingForDelivery);
                if (!validate && !checkcancel)
                {
                    if (Order == null)
                    {
                        Order = _unitOfWork.OrderRepository.GetByOrderDetailIdAsync(item.OrderId).Result;
                        continue;
                    }
                    if (Order != null)
                    {
                        Order.AddRange(_unitOfWork.OrderRepository.GetByOrderDetailIdAsync(item.OrderId).Result);
                        continue;
                    }
                }
               
            }
            if (Order == null)
            {
                checkNull = true;
            }



        }
    }


}


