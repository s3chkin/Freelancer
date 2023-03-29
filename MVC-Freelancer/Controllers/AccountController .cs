//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using MVC_Freelancer.Data.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
//using Identity.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using MVC_Freelancer.Data.Models;

namespace MVC_Freelancer.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr):base(userMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }

        // other methods

        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult GoogleLogin()
        {
            string redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return new ChallengeResult("Google", properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GoogleResponse()
        {
            ExternalLoginInfo info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
                return RedirectToAction(nameof(Login));

            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };
            if (result.Succeeded)
                return View(userInfo);
            else
            {
                AppUser user = new AppUser
                {
                    Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
                    UserName = info.Principal.FindFirst(ClaimTypes.Email).Value
                };

                IdentityResult identResult = await userManager.CreateAsync(user);
                if (identResult.Succeeded)
                {
                    identResult = await userManager.AddLoginAsync(user, info);
                    if (identResult.Succeeded)
                    {
                        await signInManager.SignInAsync(user, false);
                        return View(userInfo);
                    }
                }
                return AccessDenied();
            }
        }

        private object Login()
        {
            throw new NotImplementedException();
        }
    }
}

