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
        private readonly SearchService service;

        public SearchController()
        {
            service = new SearchService();
        }

        public ActionResult Index(string q)
        {
            IList<Contact> contacts = service.Search<Contact>(q).ToList();
            return Json(contacts, JsonRequestBehavior.AllowGet);
        }
    }
}
