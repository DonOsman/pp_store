using System.Threading.Tasks;
using PPStore.Models;
using PPStore.Models.View;

namespace PPStore.Services.Interfaces
{
	public interface IOrderService
	{
		Task<bool> CreateOrder(NewPizzaOrder newPizzaOrder, PPUser user);
	}
}