using InternetShopAspNetCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternetShopAspNetCoreMvc.Repositories.Interfaces
{
	public interface IOrdersRepository
	{
		List<Order> GetUserOrders(int id);                

		List<Order> GetUserOrdersWithDetails(int id);     

        Order GetOrderWithDetails(int id);

		void ConfirmOrder(int userId);            

        Order GetOrderById(int id);                

        void EditOrderItems(Order item);            

        void DeleteUserOrderItem(Order orderItem);   

        List<User> GetUsersById(int id);         
    }
}
