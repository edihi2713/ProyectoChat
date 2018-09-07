using CustomerChat.Helpers;
using CustomerChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerChat.Controllers
{
    public class AgentController : Controller
    {
        //
        // GET: /Agent/
        List<AgentAvailableModel> _agentes = new List<AgentAvailableModel>();
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Agent agent) {

           // Logic to login and make the agent available.


            Random rnd = new Random();
            var randomid = rnd.Next(1, 1000);


            string path = Server.MapPath("../JsonFilesTemporary/jsonAgentsAvailable.json");

            agent.AgentId = randomid;


            JsonFileManager.LoadJson(ref _agentes, path);

            _agentes.Add(new AgentAvailableModel { AgentId = agent.AgentId, AgentName = agent.AgentUser, Available = true });


            JsonFileManager.saveRequests(_agentes, path);


            return RedirectToAction("index", "chat", new { idRequest = 0, Name = agent.AgentUser, idAgent = agent.AgentId });

        }
    }
}
