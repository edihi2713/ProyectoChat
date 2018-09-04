using CustomerChat.Models;
using CustomerChat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerChat.Controllers
{
    public class RequestController : Controller
    {
        //
        // GET: /Request/


        RepositoryRequest _repoRequest;

        public RequestController()
        {
            _repoRequest = new RepositoryRequest();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create() 
        {

            var viewModel = new RequestViewModel();



            viewModel.DocumentTypes = _repoRequest.getDocumentTypes();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(RequestViewModel model)
        {


            // Simulo tener un  id de BD
            Random rnd = new Random();
            var randomid = rnd.Next(1,100);

            model.IdRequestCustomer = randomid;
            model.idDocumentType = Convert.ToInt32(model.SelectedDocumentType);
            model.Date = DateTime.Now;
            model.DocumentTypes = _repoRequest.getDocumentTypes();


            return RedirectToAction("index","chat", new { idRequest = model.IdRequestCustomer, Name = model.CustomerName });

            //return View(model);
        }

    }
}
