using ASPPROJEKT.Models;
using ASPPROJEKT.Services;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Loader;

namespace ASPPROJEKT.Controllers
{
    public class AddressController : Controller
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<IActionResult> Index()
        {
            var address = await _addressService.GetAllAddressAsync();
            return View(address);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(AddressEntity model)
        {
            if (ModelState.IsValid)
            {
                await _addressService.CreateAddressAsync(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(int id)
        {
            var address = await _addressService.GetAddressDetailsAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(AddressEntity address)
        {
            if (ModelState.IsValid)
            {
                await _addressService.UpdateAddressAsync(address);
                return RedirectToAction("Index");
            }
            else
            {
                return View(address);
            }
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var address =await _addressService.GetAddressDetailsAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(AddressEntity address)
        {
            await _addressService.DeleteAddressAsync(address.Id);
            return RedirectToAction("Index");
        }
    }
}
