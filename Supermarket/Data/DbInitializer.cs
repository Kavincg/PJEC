using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Supermarket.Data;
using Supermarket.Models;

namespace Supermarket.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public void Initialize()
        {
            // Apply migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error applying migrations: {ex.Message}");
            }

            // Create roles if they don't exist
            if (!_roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            }
            if (!_roleManager.RoleExistsAsync("Customer").GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole("Customer")).GetAwaiter().GetResult();
            }
            // Add other roles as needed, e.g., "Employee"
            // if (!_roleManager.RoleExistsAsync("Employee").GetAwaiter().GetResult())
            // {
            //     _roleManager.CreateAsync(new IdentityRole("Employee")).GetAwaiter().GetResult();
            // }


            // Seed Admin User if not exists
            if (_userManager.FindByEmailAsync("admin@admin.com").GetAwaiter().GetResult() == null)
            {
                // Create a new IdentityUser (or your custom ApplicationUser if you have one)
                // Assuming you have an ApplicationUser that inherits from IdentityUser
                // If not, just use IdentityUser directly.
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    // You might want to add other properties specific to your ApplicationUser
                    // For example: Name = "Admin User", PhoneNumber = "1234567890"
                };

                // Create the user with the specified password
                _userManager.CreateAsync(user, "Admin@123").GetAwaiter().GetResult();

                // Assign the "Admin" role to the newly created user
                _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
            }
        }
    }

    // Interface for DbInitializer to be injected into services
    public interface IDbInitializer
    {
        void Initialize();
    }
}