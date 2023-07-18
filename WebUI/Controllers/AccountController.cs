using AutoMapper;
using Business.Abstract;
using Common.Enums;
using Common.Responses;
using Dtos.Concrete.AppUserDto;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _userCreateValidator;
        private readonly IAppUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IValidator<UserCreateModel> validator, IGenderService genderService, IMapper mapper, IAppUserService userService)
        {
            _userCreateValidator = validator;
            _genderService = genderService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            var genders = await _genderService.GetAllAsync();
            var userModel = new UserCreateModel
            {
                Genders = new SelectList(genders.Data, "Id", "Definition")
            };
            return View(userModel);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var genders = await _genderService.GetAllAsync();
            model.Genders = new SelectList(genders.Data, "Id", "Definition");
            var result = _userCreateValidator.Validate(model);
            if (result.IsValid)
            {
                var signIndto = _mapper.Map<AppUserCreateDto>(model);
                var res = await _userService.CreateWithRoleAsync(signIndto, (int)RoleType.member);
                if (res.ResponseType == ResponseType.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(model);
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserSignInDto signIndto)
        {

            var result = await _userService.SignInAsync(signIndto);
            if (result.ResponseType == ResponseType.Success)
            {
                var roleResult = await _userService.GetUserRolesAsync(result.Data.Id);
                // ilgili kullanıcının rollerini çekmemiz.
                var claims = new List<Claim>();

                if (roleResult.ResponseType == ResponseType.Success)
                {
                    foreach (var role in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Definition));
                    }
                }

                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = signIndto.RememberMe,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Kullanıcı adı veya şifre hatalı", result.Message);
            return View(signIndto);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
