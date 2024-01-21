using ASPPROJEKT.Services;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPPROJEKT.Controllers
{
    public class PhotoController : Controller
    {
        private readonly PhotoService _photoService;

        public PhotoController(PhotoService photoService)
        {
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            var photos = await _photoService.GetAllPhotosAsync();
            return View(photos);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _photoService.GetPhotoDetailsAsync(id.Value);

            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }
    }
}
