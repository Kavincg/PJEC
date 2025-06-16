using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Data.IRepository;
using Supermarket.Models;
using Supermarket.RolesAndEmailSender;
using Supermarket.ViewModel;
using System.Security.Claims; // Required for User.FindFirstValue

namespace Supermarket.Controllers
{
    // Authorize all users who are logged in to access this controller.
    // Role-specific filtering will happen inside the Index action.
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Action to display a list of orders based on user role.
        public IActionResult Index()
        {
            // Retrieve the ClaimsIdentity for the current user.
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            // Get the unique identifier (ID) of the logged-in user.
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            // Check if the current user belongs to the "Admin" role.
            // Ensure SD.Role_Admin holds the correct string value (e.g., "Admin").
            bool isAdmin = User.IsInRole(SD.Role_Admin);

            List<OrderHeader> orders;

            if (isAdmin)
            {
                // If the user is an Admin, retrieve all order headers.
                // Include the ApplicationUser navigation property to access user details
                // like Name and Email in the view.
                orders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
            }
            else
            {
                // If the user is a regular customer, retrieve only their orders.
                // Filter by ApplicationUserId matching the logged-in user's ID.
                // Also include ApplicationUser for displaying user details.
                orders = _unitOfWork.OrderHeader
                                     .GetAll(u => u.ApplicationUserId == userId, includeProperties: "ApplicationUser")
                                     .ToList();
            }

            // Pass the filtered list of orders to the view.
            return View(orders);
        }
    }
}
