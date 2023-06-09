using BirdTrading.Domain.Models;
using BirdTrading.Interface;
using BirdTrading.Utils.Pagination;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdTradingApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CategoryType> CategoryTypes { get; set; }
        public Pagination<Product> ProductPaging { get; set; }

        public async Task OnGetAsync(int pageIndex = 0, int pageSize = 9)
        {
            CategoryTypes = await _unitOfWork.CategoryTypeRepository.GetListAsync();
            ProductPaging = await _unitOfWork.ProductRepository.GetPaginationsAsync(pageIndex, pageSize);
        }

        #region Search
        public async Task OnGetSearchAsync(string search, int pageIndex = 0, int pageSize = 9)
        {
            if (search is null)
            {
                await OnGetAsync(pageIndex, pageSize);
            }
            else
            {
                CategoryTypes = await _unitOfWork.CategoryTypeRepository.GetListAsync();
                ProductPaging = await _unitOfWork.ProductRepository.SearchProductPagingAsync(search, pageIndex, pageSize);
            }
        }
        #endregion

        #region Filter
        public async Task OnGetFilterAsync(string category, int pageIndex = 0, int pageSize = 9)
        {
            if (category is null)
            {
                await OnGetAsync(pageIndex, pageSize);
            }
            else
            {
                CategoryTypes = await _unitOfWork.CategoryTypeRepository.GetListAsync();
                ProductPaging = await _unitOfWork.ProductRepository.SearchProductPagingAsync(category, pageIndex, pageSize);
            }
        }
        #endregion

        #region AddToCartHandle
        public async Task OnGetAddToCartAsync(int id, int quantity = 1)
        {
            var userId = HttpContext.Session.GetInt32("Id");
            if (userId is not null)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
                if (product is not null && product.Quantity >= quantity)
                {
                    var cart = await _unitOfWork.CartRepository.GetCartByUserIdAndShopIdAsync((int)userId, product.Shop.Id);
                    if (cart is null)
                    {
                        if (await CreateNewCartAsync((int)userId, product, quantity))
                        {
                            TempData["success"] = "Add to cart";
                            await OnGetAsync();
                        }
                    }
                    else
                    {
                        var details = await _unitOfWork.CartDetailRepository.GetDetailByCartIdAndProductIdAsync(cart.Id, product.Id);
                        if (details is not null)
                        {
                            if (await UpdateCartDetailAsync(details, quantity))
                            {
                                TempData["success"] = "Add to cart";
                                await OnGetAsync();
                                return;
                            }
                        }
                        //
                        if (await CreateNewCartDetailAsync((int)userId, product, quantity, cart.Id))
                        {
                            TempData["success"] = "Add to cart";
                            await OnGetAsync();
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Create new cart when product is not belong to any shop in cart.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<bool> CreateNewCartAsync(int userId, Product product, int quantity)
        {
            var cart = new Cart
            {
                ShopId = product.Shop.Id,
                UserId = userId,
                CartDetails = new List<CartDetail>()
            };

            var cartDetailCreate = new CartDetail
            {
                ProductId = product.Id,
                Quantity = quantity,
            };

            cart.CartDetails.Add(cartDetailCreate);

            await _unitOfWork.CartRepository.AddAsync(cart);
            return await _unitOfWork.SaveChangeAsync();
        }

        /// <summary>
        /// Create new cart detail when the product is same shop.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public async Task<bool> CreateNewCartDetailAsync(int userId, Product product, int quantity, int cartId)
        {
            var cart = await _unitOfWork.CartRepository.GetByIdAsync(cartId);
            //
            if (cart is null) return await CreateNewCartAsync(userId, product, quantity);
            //
            var cartDetail = new CartDetail
            {
                CartId = cart.Id,
                ProductId = product.Id,
                Quantity = quantity
            };
            //
            cart.CartDetails.Add(cartDetail);
            _unitOfWork.CartRepository.Update(cart);
            return await _unitOfWork.SaveChangeAsync();
        }

        /// <summary>
        /// Update cart quantity exists product in cart.
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<bool> UpdateCartDetailAsync(CartDetail detail, int quantity)
        {
            detail.Quantity += quantity;
            _unitOfWork.CartDetailRepository.Update(detail);
            return await _unitOfWork.SaveChangeAsync();
        }
        #endregion
    }
}
