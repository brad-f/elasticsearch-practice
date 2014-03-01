using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Models;
using Web.Search;

namespace Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly SearchService<Contact> service;

        public SearchController()
        {
            service = new SearchService<Contact>();
        }

        public ActionResult Index(string q)
        {
            IList<Contact> contacts = service.Search(q);
            return Json(contacts, JsonRequestBehavior.AllowGet);
        }
    }
}
