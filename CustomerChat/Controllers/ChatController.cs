using CustomerChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerChat.Controllers
{
    public class ChatController : Controller
    {
        //
        // GET: /Chat/

        public ActionResult Index(int idRequest,string Name, int idAgent = 0)
        {
            return View(new CustomerRequestViewModel { RequestId = idRequest, CustomerName = Name, IdAgent = idAgent });
        }

        public ActionResult GetAvailableAgent(int idRequest)
        {

            // Make a query in the list of agents, checking if there is any available and selecting them if so...

            Agent data = null;
            var result = false;

            if (1 == 1)
            {
                 data = new Agent
                {
                    AgentId = Guid.NewGuid().ToString(),
                    AgentDocument = "12345",
                    AgentName = "Agente Number 1",
                    AgentUser = "agen007",
                    isAvailable = true
                };

                 result = true;

            }

            return Json(new { data = data, result = result},JsonRequestBehavior.AllowGet);
        }

    }
}
