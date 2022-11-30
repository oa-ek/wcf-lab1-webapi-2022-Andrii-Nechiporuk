using KeysShop.Core;
using KeysShop.Repository;
using KeysShop.Repository.Dto;
using Microsoft.AspNetCore.Mvc;

namespace KeysShop.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrdersRepository ordersRepository;

        public OrderController(OrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        [HttpPost("createorder")]
        public void Checkout(OrderDto order, string paymethod)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>("cart");
            order.Delivery = paymethod;
            if (cart.Count == 0)
            {
                return;
            }
            if (ModelState.IsValid)
            {
                ordersRepository.createOrder(order);
            }
        }
    }
}