using Bemerkto.Helpers.Repositories;
using Bemerkto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bemerkto.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactFormRepository _formRepository;

        public ContactsController(ContactFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _formRepository.AddAsync(viewModel);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}
