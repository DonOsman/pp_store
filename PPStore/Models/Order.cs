using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PPStore.Models
{
	public class Order : BaseModel
	{
		[Required] public PPUser PpUser { get; set; }
		[Required] public ICollection<OrderPizza> Pizzas { get; set; }
		[Required] public DateTime OrderTime { get; set; }
		[Required] public OrderStatus Status { get; set; }

		public Order(PPUser user, ICollection<OrderPizza> pizzas)
		{
			PpUser = user;
			Pizzas = pizzas;
			OrderTime = DateTime.Now.ToUniversalTime();
			Status = OrderStatus.NewOrder;
		}
	}

	public enum OrderStatus
	{
		NewOrder = 0,
		Pending = 1,
		Shipped = 2,
		Completed = 3,
		Cancelled = 4
	}
}