using ASPPROJEKT.Services;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPPROJEKT.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return View(authors);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _authorService.GetAuthorDetailsAsync(id.Value);

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.AddressList = await _authorService.FindAllAddressForViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorEntity model)
        {

            if (ModelState.IsValid)
            {
                await _authorService.CreateAuthorAsync(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.AddressList = await _authorService.FindAllAddressForViewModel();
            var author = await _authorService.GetAuthorDetailsAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AuthorEntity author)
        {
            if (ModelState.IsValid)
            {
                if (author.Id <= 0)
                {
                    return BadRequest("Invalid ID");
                }

                await _authorService.UpdateAuthorAsync(author);
                return RedirectToAction("Index");
            }
            else
            {
                return View(author);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorService.GetAuthorDetailsAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(AuthorEntity author)
        {
            await _authorService.DeleteAuthorAsync(author.Id);
            return RedirectToAction("Index");
        }
    }
}
