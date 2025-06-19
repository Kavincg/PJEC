using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Data.IRepository;
using Supermarket.Models;
using Supermarket.RolesAndEmailSender;
using Supermarket.ViewModel;
using System.Security.Claims;

namespace Supermarket.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            bool isAdmin = User.IsInRole(SD.Role_Admin);

            List<OrderHeader> orders;

            if (isAdmin)
            {
                orders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
            }
            else
            {
                orders = _unitOfWork.OrderHeader
                                     .GetAll(u => u.ApplicationUserId == userId, includeProperties: "ApplicationUser").ToList();
            }
            return View(orders);
        }
    }
}
