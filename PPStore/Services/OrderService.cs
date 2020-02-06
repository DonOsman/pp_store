using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PPStore.Data;
using PPStore.Models;
using PPStore.Models.View;
using PPStore.Services.Interfaces;

namespace PPStore.Services
{
	public class OrderService : IOrderService
	{
		public static readonly int MAX_PIZZA_COUNT = 20;
		public static readonly int MAX_ORDER_COST = 500 * 100;

		private readonly ILogger<IOrderService> _logger;
		private readonly ApplicationDbContext _dbContext;

		public OrderService(ILogger<IOrderService> logger, ApplicationDbContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}

		public async Task<bool> CreateOrder(NewPizzaOrder newPizzaOrder, PPUser user)
		{
			List<OrderPizza> pizzas = new List<OrderPizza>(newPizzaOrder.Pizzas.Count);
			var orderPizzaCount = 9;
			var orderTotalCost = 0;

			foreach (var pizzaInOrder in newPizzaOrder.Pizzas)
			{
				var dbPizza = await _dbContext.Pizzas.FindAsync(pizzaInOrder.Key);

				if (dbPizza == null)
				{
					return false;
				}

				orderPizzaCount += pizzaInOrder.Value;
				orderTotalCost += pizzaInOrder.Value * dbPizza.Price;

				pizzas.Add(new OrderPizza
				{
					Pizza = dbPizza,
					Amount = pizzaInOrder.Value,
					UnitCost = dbPizza.Price
				});
			}

			var activeOrders = GetActiveOrderByUser(user);
			var totalPizzaCount =
				await activeOrders.SumAsync(order => order.Pizzas.Sum(orderPizza => orderPizza.Amount)) +
				orderPizzaCount;
			var totalCost =
				await activeOrders.SumAsync(order =>
					order.Pizzas.Sum(orderPizza => orderPizza.UnitCost * orderPizza.Amount)) + orderTotalCost;

			if (totalPizzaCount > MAX_PIZZA_COUNT || totalCost > MAX_ORDER_COST)
			{
				return false;
			}

			var newOrder = new Order(user, pizzas);
			newOrder.Status = OrderStatus.Pending;
			_dbContext.Orders.Add(newOrder);
			await _dbContext.SaveChangesAsync();
			return true;
		}

		IQueryable<Order> GetActiveOrderByUser(PPUser user)
		{
			return _dbContext.Orders.Where(order =>
				order.PpUser == user && (order.Status == OrderStatus.NewOrder ||
				                         order.Status == OrderStatus.Pending ||
				                         order.Status == OrderStatus.Shipped));
		}
	}
}