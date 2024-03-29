﻿using BirdTrading.DataAccess;
using BirdTrading.Interface;
using BirdTrading.Interface.Repositories;

namespace BirdTrading.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private readonly ICartRepository cartRepository;
        private readonly ICartDetailRepository cartDetailRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICategoryTypeRepository categoryTypeRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository ordersDetailRepository;
        private readonly IProductRepository productRepository;
        private readonly IShippingInformationRepository shippingInformationRepository;
        private readonly IShippingSessionRepository shippingSessionRepository;
        private readonly IShopRepository shopRepository;
        private readonly IUserRepository userRepository;

        public UnitOfWork(AppDbContext context, ICartRepository cartRepository,
            ICartDetailRepository cartDetailRepository, ICategoryRepository categoryRepository,
            ICategoryTypeRepository categoryTypeRepository, IOrderRepository orderRepository,
            IOrderDetailRepository ordersDetailRepository, IProductRepository productRepository,
            IShippingInformationRepository shippingInformationRepository,
            IShippingSessionRepository shippingSessionRepository, IShopRepository shopRepository,
            IUserRepository userRepository)
        {
            this.context = context;
            this.cartRepository = cartRepository;
            this.cartDetailRepository = cartDetailRepository;
            this.categoryRepository = categoryRepository;
            this.categoryTypeRepository = categoryTypeRepository;
            this.orderRepository = orderRepository;
            this.ordersDetailRepository = ordersDetailRepository;
            this.productRepository = productRepository;
            this.shippingInformationRepository = shippingInformationRepository;
            this.shippingSessionRepository = shippingSessionRepository;
            this.shopRepository = shopRepository;
            this.userRepository = userRepository;
        }

        public ICategoryRepository CategoryRepository => categoryRepository;
        public IOrderDetailRepository OrderDetailRepository => ordersDetailRepository;
        public IOrderRepository OrderRepository => orderRepository;
        public IProductRepository ProductRepository => productRepository;
        public IShippingInformationRepository ShippingInformationRepository => shippingInformationRepository;
        public IShippingSessionRepository ShippingSessionRepository => shippingSessionRepository;
        public IShopRepository ShopRepository => shopRepository;
        public IUserRepository UserRepository => userRepository;
        public ICategoryTypeRepository CategoryTypeRepository => categoryTypeRepository;
        public ICartRepository CartRepository => cartRepository;
        public ICartDetailRepository CartDetailRepository => cartDetailRepository;

        public async Task<bool> SaveChangeAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
