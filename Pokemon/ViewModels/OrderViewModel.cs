using Pokemon.Models;

namespace Pokemon.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public int Count { get; set; }
        public OrderViewModel(Order order, int count)
        {
            this.Order = order;
            this.Count = count;
        }
    }
}
