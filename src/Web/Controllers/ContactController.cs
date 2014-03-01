using System.Web.Mvc;
using Web.Models;
using Web.Search;

namespace Web.Controllers
{
    public class ContactController : Controller
    {
        private SearchService service;

        public ContactController()
        {
            service = new SearchService();
        }

        [HttpPost]
        public ActionResult Index(string email, string name)
        {
            service.Index(new Contact
                {
                    Email = email,
                    Name = name
                });
            return RedirectToAction("Index", "Home");
        }
    }
}
