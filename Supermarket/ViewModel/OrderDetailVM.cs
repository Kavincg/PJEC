using System.Collections.Generic;
using Supermarket.Models;

namespace Supermarket.ViewModel
{
    public class OrderDetailVM
    {
        public OrderHeader OrderHeader { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}