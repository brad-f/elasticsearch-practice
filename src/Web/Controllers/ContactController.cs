using System.Web.Mvc;
using Web.Models;
using Web.Search;

namespace Web.Controllers
{
    public class ContactController : Controller
    {
        private SearchService<Contact> service;

        public ContactController()
        {
            service = new SearchService<Contact>();
        }

        [HttpPost]
        public ActionResult Index(string email, string name)
        {
            service.IndexEntity(new Contact
                {
                    Email = email,
                    Name = name
                });
            return RedirectToAction("Index", "Home");
        }
    }
}
