using KeysShop.Core;
using KeysShop.Repository;
using KeysShop.Shared.Dtos;
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

        /// <summary>
        /// Method creates final order
        /// </summary>
        /// <param name="paymethod">method of payment which user have to choose</param>
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