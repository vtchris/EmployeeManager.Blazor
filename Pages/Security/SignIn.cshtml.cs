using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Blazor.Models;
using EmployeeManager.Blazor.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManager.Blazor.Pages.Security
{
    public class SignInModel : PageModel
    {
        private readonly SignInManager<AppIdentityUser> signInManager;

        [BindProperty]
        public SignIn SignInData { get; set; }

        public SignInModel(SignInManager<AppIdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    SignInData.UserName, SignInData.Password, SignInData.RememberMe, false);

                if (result.Succeeded)
                    // route must match route on the @page List.razor
                    return Redirect("/Employees/List");
                else
                    ModelState.AddModelError("", "Invalid username or password");
            }

            return Page();
        }
    }
}
