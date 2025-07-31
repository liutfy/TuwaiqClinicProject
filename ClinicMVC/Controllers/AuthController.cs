using ClinicMVC.Helpers;
using ClinicMVC.Models;
using ClinicMVC.ModelVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUsers> userManager;
        private readonly SignInManager<AppUsers> signInManager;
        public ClinicContext context;

        public AuthController(UserManager<AppUsers> userManager, SignInManager<AppUsers> signInManager, ClinicContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;

        }
        public async Task<IActionResult> Index()
        {
       
            var users = context.Users.ToList();
            var usersVM = new List<UserVM>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault() ?? "No Role";

                usersVM.Add(user.ToUserVM(role)); 
            }

            return View(usersVM);
        }
        
        public IActionResult Login(string? returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string? returnUrl, LoginVM model)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                false,
                false
                );

            if (result.Succeeded)
            {
                return Redirect(returnUrl ?? "/");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles ="Admin")]
        public IActionResult CreateUser()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new AppUsers
            {
                UserName = model.Email,
                Email = model.Email
            };

            if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
            {

                if (model.ProfilePicture.Length > 1000 * 1024)
                {
                    ModelState.AddModelError("ProfilePicture", "Profile picture size should not exceed 256KB.");
                }

                var allowedTypes = new[] { "image/jpeg", "image/png" };
                if (!allowedTypes.Contains(model.ProfilePicture.ContentType))
                {
                    ModelState.AddModelError("ProfilePicture", "Only JPEG and PNG images are allowed.");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                using var memoryStream = new MemoryStream();
                await model.ProfilePicture.CopyToAsync(memoryStream);
                user.ProfilePicture = memoryStream.ToArray();
            }


            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }


            result = await userManager.AddToRoleAsync(user, model.Role);
            if (!result.Succeeded)
            {
               
                ModelState.AddModelError(string.Empty, "failed to add role!!");
                return View(model);
            }


            if (model.Role == AppRoles.Doctor.ToString())
            {
                return RedirectToAction("Create", "Doctor");
            }
           

            
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteUser(String UserName)
        {
            var User = context.Users.FirstOrDefault(d => d.Email == UserName);
            if (User == null)
            {
                return NotFound();
            }
            context.Users.Remove(User);
            context.SaveChanges();
            return Ok();
        }
    }
}
