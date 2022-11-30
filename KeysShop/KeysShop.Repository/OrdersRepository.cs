using KeysShop.Core;
using KeysShop.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Repository
{
    public class OrdersRepository
    {
        private readonly KeysShopContext _context;
        private readonly KeysRepository keysRepository;
        private readonly SessionManager sessionManager;

        public OrdersRepository(KeysShopContext context, SessionManager sessionManager, KeysRepository keysRepository)
        {
            this.keysRepository = keysRepository;
            _context = context;
            this.sessionManager = sessionManager;
        }

        public void createOrder(OrderDto orderDto)
        {
            var order = new Order
            {
                Surname = orderDto.Surname,
                Name = orderDto.Name,
                Email = orderDto.Email,
                Phone = orderDto.Phone,
                Delivery = orderDto.Delivery,
                Adress = orderDto.Adress
            };
            order.DateTime = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();
            var items = sessionManager.GetCartItems();

            foreach (var el in items)
            {
                var key = keysRepository.GetKey(el.Key.Id);
                var order1 = _context.Orders.FirstOrDefault(x => x.Id == order.Id);
                var orderDetail = new OrderDetail()
                {
                    KeyId = el.Key.Id,
                    OrderId = order.Id,
                    Price = el.Key.Price,
                    Key = key,
                    Order = order1
                };
                _context.OrderDetails.Add(orderDetail);
            }
            _context.SaveChanges();
        }
    }
}