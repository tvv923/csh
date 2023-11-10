using AspNetCoreHero.ToastNotification.Abstractions;
using InternetShopAspNetCoreMvc.Data;
using InternetShopAspNetCoreMvc.Models;
using InternetShopAspNetCoreMvc.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace InternetShopAspNetCoreMvc.Controllers
{
    public class OrdersController : Controller
    {
        private readonly InternetShopDbContext _context;
        private readonly IOrdersRepository ordersRepository;
        private readonly ICartRepository cartRepository;
        private readonly INotyfService notifyService;
        private const int UserId = 1;

        public OrdersController(InternetShopDbContext context, IOrdersRepository ordersRepository, ICartRepository cartRepository, INotyfService notifyService)
        {
            _context = context;
            this.ordersRepository = ordersRepository;
            this.cartRepository = cartRepository;
            this.notifyService = notifyService;
        }

        public async Task<IActionResult> Index()
        {
            return View(ordersRepository.GetUserOrdersWithDetails(UserId)); 
        }

        public IActionResult Details(int id)
        {
            var order = ordersRepository.GetOrderWithDetails(id);

            if (order != null)
            {
                return View(order);
            }

            return View("DoesNotExist");
        }

        [HttpGet]
        public IActionResult PlaceOrder()
        {
            var cartItems = cartRepository.GetUserCartItems(UserId);

            ViewData["total"] = cartItems.Select(c => c.Product.Price * c.Quantity).Sum() + 10;

            return View(cartItems);
        }

        public async Task<IActionResult> PlaceOrderConfirmed()
        {
            ordersRepository.ConfirmOrder(UserId);
            notifyService.Success("Order created!");

            return RedirectToAction("Index");
        }

        public IActionResult Manage()
        {
            var orders = ordersRepository.GetUserOrders(UserId); 

            return View(orders);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = ordersRepository.GetOrderById(id);

            if (order != null)
            {
				ViewData["UserId"] = new SelectList(ordersRepository.GetUsersById(order.UserId), "Id", "Fullname", order.UserId);                
                return View(order);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Order item)
        {
            ordersRepository.EditOrderItems(item);
            notifyService.Success("Changed successfully!");

            return RedirectToAction("Manage");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var order = _context.Orders.Include(o => o.User).FirstOrDefault(o => o.Id == id); 

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]   
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var orderItem = ordersRepository.GetOrderById(id);
            if (orderItem != null)
            {
                ordersRepository.DeleteUserOrderItem(orderItem);
                notifyService.Success("Deleted successfully!");
            }

            return RedirectToAction("Index");
        }

    }
}
