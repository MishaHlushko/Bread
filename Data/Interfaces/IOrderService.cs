using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beads_Store.Data.Models;
using Beads_Store.ViewModels;

namespace Beads_Store.Data.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order, string userId);
        Task<OrderListViewModel> GetOrderByUserIdAsync(string userId);
        Task<OrderViewModel> GetOrderDetailViewModelAsync(int id);
        Task SetOrderStatusAsync(int orderId, int status);
        Task<OrderDetailListViewModel> GetOrdersAsync();
        Task<OrderListViewModel> FilterByStatusAsync(int? statusOrderId);
        Task<OrderListViewModel> FilterByStatusUserOrderAsync(int? statusOrderId, string userId);
        Task<OrderListViewModel> GetOrderListViewModelAsync();
        Task<List<OrderViewModel>> GetOrderListAsync();
    }
}
