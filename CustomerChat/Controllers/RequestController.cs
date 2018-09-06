using CustomerChat.Helpers;
using CustomerChat.Models;
using CustomerChat.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        List<RequestViewModel> requests = new List<RequestViewModel>();

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

            string path = Server.MapPath("../JsonFilesTemporary/jsonRequest.json");

            JsonFileManager.LoadJson(ref requests, path);



            // Simulo tener un  id de BD
            Random rnd = new Random();
            var randomid = rnd.Next(1, 100);

            model.IdRequestCustomer = randomid;
            model.idDocumentType = Convert.ToInt32(model.SelectedDocumentType);
            model.Date = DateTime.Now;
            model.DocumentTypes = null;

            // Save the request
            requests.Add(model);


            JsonFileManager.saveRequests(requests, path);





            return RedirectToAction("index", "chat", new { idRequest = model.IdRequestCustomer, Name = model.CustomerName });

            //return View(model);
        }




    }
}
