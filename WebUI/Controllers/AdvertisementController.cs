using AutoMapper;
using Business.Abstract;
using Common.Enums;
using Common.Responses;
using Dtos.Concrete.AdvertisementAppUserDto;
using Dtos.Concrete.MilitaryStatusDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly IAdvertisementAppUserService _advertisementAppUserService;
        private readonly IMapper _mapper;

        public AdvertisementController(IAppUserService userService, IAdvertisementAppUserService advertisementAppUserService, IMapper mapper)
        {
            _userService = userService;
            _advertisementAppUserService = advertisementAppUserService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="Member")]
        public IActionResult Send(int id)
        {
            //MilitaryStatus
            var enumTypes = Enum.GetValues(typeof(MilitaryStatusType));
            List<MilitaryStatusListDto> dtos = new();
            foreach (var item in enumTypes)
            {
                dtos.Add(new()
                {
                    Id = Convert.ToInt32(item),
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                });
            }
            ViewBag.militaryStatus = new SelectList(dtos,"Id","Definition");
            TempData["advertisementId"] = id;

            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            ViewBag.genderId = _userService.GetByIdAsync(userId).Result.Data.GenderId;
            AdvertisementUserCreateModel model = new()
            {
                AdvertisementId = id,
                AppUserId = userId,
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Send(AdvertisementUserCreateModel model)
        {
            var enumTypes = Enum.GetValues(typeof(MilitaryStatusType));
            List<MilitaryStatusListDto> dtos = new();
            foreach (var item in enumTypes)
            {
                dtos.Add(new()
                {
                    Id = Convert.ToInt32(item),
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                });
            }
            ViewBag.militaryStatus = new SelectList(dtos, "Id", "Definition");


            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            ViewBag.genderId = _userService.GetByIdAsync(userId).Result.Data.GenderId;
            model.AdvertisementId = (int)TempData["advertisementId"];
            model.AppUserId = userId;
            if (model.CvPath != null)
            {
                var fileName = Guid.NewGuid().ToString();
                var extName = Path.GetExtension(model.CvPath.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","cvFiles",fileName + extName);
                var stream = new FileStream(path, FileMode.Create);
                await model.CvPath.CopyToAsync(stream);
                var dto = _mapper.Map<AdvertisementAppUserDto>(model);
                dto.CvPath = path;
                var response = await _advertisementAppUserService.CreateAsync(dto);
                if (response.ResponseType == ResponseType.NotFound)
                {
                    ModelState.AddModelError("", response.Message);
                    return View(model);
                }
                else if (response.ResponseType == ResponseType.ValidationError)
                {
                    foreach (var item in response.ValidationErrors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Lütfen geçerli bir cv ekleyin.");
            return View(model);
        }

        //Admin
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            var result = await _advertisementAppUserService.GetAdvertisementAppUserListDtoAsync();
            return View(result.Data);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PositiveApplication(int id)
        {
            var result = await _advertisementAppUserService.PositiveApplicationAsync(id);
            return RedirectToAction("List", "Advertisement");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> NegativeApplication(int id)
        {
            var result = await _advertisementAppUserService.NegativeApplicationAsync(id);
            return RedirectToAction("List", "Advertisement");
        }
        private void GetAdvertisementUserCreateOptions()
        {
            var enumTypes = Enum.GetValues(typeof(MilitaryStatusType));
            List<MilitaryStatusListDto> dtos = new();
            foreach (var item in enumTypes)
            {
                dtos.Add(new()
                {
                    Id = Convert.ToInt32(item),
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                });
            }
            ViewBag.militaryStatus = new SelectList(dtos, "Id", "Definition");


            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            ViewBag.genderId = _userService.GetByIdAsync(userId).Result.Data.GenderId;
        }
    }
    
}
