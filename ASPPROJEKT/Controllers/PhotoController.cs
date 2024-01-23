using ASPPROJEKT.Services;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> PagedIndex([FromQuery] int page = 1, [FromQuery] int size = 3)
        {
            var paginatedPhotos = await _photoService.FindPage(page, size);
            return View("PagedIndex", paginatedPhotos);
        }

        public async Task<IActionResult> PagedFilteredIndex(string filter, int page = 1, int size = 3)
        {
            var filteredPhotos = await _photoService.FindFilteredPage(filter, page, size);
            return View("FilteredIndex", filteredPhotos);
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.AuthorList = await _photoService.FindAllAuthorsForViewModel();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PhotoEntity model)
        {

            if (ModelState.IsValid)
            {
                await _photoService.CreatePhotoAsync(model);
                return RedirectToAction("Index");
            } else
            {
            return View(model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.AuthorList = await _photoService.FindAllAuthorsForViewModel();
            var photo = await _photoService.FindById(id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }
        [HttpPost]
        public async Task<IActionResult> Update(PhotoEntity photo)
        {
            if (ModelState.IsValid)
            {
                if (photo.PhotoId <= 0)
                {
                    return BadRequest("Invalid ID");
                }

                await _photoService.UpdatePhotoAsync(photo);
                return RedirectToAction("Index");
            }
            else
            {
                return View(photo);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var photo = await _photoService.GetPhotoDetailsAsync(id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(PhotoEntity photo)
        {
            await _photoService.DeletePhotoAsync(photo.PhotoId);
            return RedirectToAction("Index");
        }
    }
}
