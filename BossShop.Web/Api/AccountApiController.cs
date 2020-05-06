using BOSS.Common;
using BOSS.Model.Models;
using BOSS.Service;
using BossShop.Web.Infrastructure.Core;
using BossShop.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BossShop.Web.Api
{
    public class AccountApiController : ApiBaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IAccountService _accountService;
        public AccountApiController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IAccountService accountService, ErrorService errorService): base(errorService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            this._accountService = accountService;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current. GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public LoginViewModel Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return null;
            }
            else
            {
                var userName = model.Email;
                if (model.Email.IndexOf("@") > 0)
                {
                    userName = _accountService.GetUserNameByEmail(model.Email);
                }
                var result = SignInManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, false);
                if (result.Result == SignInStatus.Success)
                    return model;
                else return null;

            }
        }
        public async Task<VerifyCodeViewModel> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return null;
            }
            return new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe };
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<SignInStatus> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return SignInStatus.Failure;
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            return result;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<SignInStatus> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    return SignInStatus.Success;
                }
            }

            // If we got this far, something failed, redisplay form
            return SignInStatus.Failure;
        }
        public async Task<int> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return (int)StatusEnum.Failure;
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            
            return result.Succeeded ? (int)StatusEnum.Success : (int)StatusEnum.Failure;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<int> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return (int)StatusEnum.Failure;
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return (int)StatusEnum.Failure;
        }
    }
}
