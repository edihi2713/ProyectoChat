using CustomerChat.Helpers;
using CustomerChat.Models;
using Newtonsoft.Json;
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

        public List<AgentAvailableModel> agentsAvailable = new List<AgentAvailableModel>();
        public List<RequestAgentModel> requestAgents = new List<RequestAgentModel>();

        public List<MessagesModel> _messages = new List<MessagesModel>();


        public ActionResult Index(int idRequest, string Name, int idAgent = 0)
        {
            return View(new CustomerRequestViewModel { RequestId = idRequest, CustomerName = Name, IdAgent = idAgent });
        }



        public ActionResult GetMessages(int idConversation, string sender)
        {

            // variables to return;

            bool result = true;

            string messagesClient = "";


            List<MessagesModel> allMessages = new List<MessagesModel>();
             List<MessagesModel> newMessages = new List<MessagesModel>();

            var messagesPath = Server.MapPath("../JsonFilesTemporary/jsonMessages.json");
            JsonFileManager.LoadJson(ref allMessages, messagesPath);


            try
            {
                newMessages = (from message in allMessages
                               where message.IdConversation == idConversation
                                   && message.Read == false && message.Sender != sender
                               select message).ToList<MessagesModel>();


                allMessages.Where(m => m.IdConversation == idConversation && m.Read == false && m.Sender != sender).ToList<MessagesModel>().ForEach(mes => mes.Read = true);
                JsonFileManager.saveRequests(allMessages, messagesPath);
                messagesClient = JsonConvert.SerializeObject(newMessages);
            }
            catch (Exception)
            {

                result = false;
            }



            return Json(new { isSuccess = result, newMessages = messagesClient }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAvailableAgent(int idRequest)
        {
                
            bool isAgentFound = false;


            RequestAgentModel requestAgent = new RequestAgentModel();

            requestAgent.idRequestAgent = 0;

            AgentAvailableModel assignedAgent = null;
            var agentsAvailablePath = Server.MapPath("../JsonFilesTemporary/jsonAgentsAvailable.json");
            var requestAgentsPath = Server.MapPath("../JsonFilesTemporary/requestAgents.json");

            JsonFileManager.LoadJson(ref agentsAvailable, agentsAvailablePath);

            var items = agentsAvailable.Where(a => a.Available == true).Count();

            if (items > 0)
            {
                assignedAgent = agentsAvailable.Where(a => a.Available == true).First();

                isAgentFound = true;

                agentsAvailable.First(a => a.AgentId == assignedAgent.AgentId).Available = false;

                JsonFileManager.saveRequests(agentsAvailable, agentsAvailablePath);

                JsonFileManager.LoadJson(ref requestAgents, requestAgentsPath);


                Random rnd = new Random();
                var randomid = rnd.Next(1, 1000);


                requestAgent = new RequestAgentModel
               {
                   idRequestAgent = randomid,
                   idAgent = assignedAgent.AgentId,
                   idCustomerRequest = idRequest,
                   isFinished = false
               };

                requestAgents.Add(requestAgent);

                JsonFileManager.saveRequests(requestAgents, requestAgentsPath);

            }

            return Json(new { data = assignedAgent, result = isAgentFound, idRequestAgent = requestAgent.idRequestAgent }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getCustomer(int idAgent)
        {

            RequestAgentModel agentRequested = new RequestAgentModel();
            RequestViewModel customerRequest = new RequestViewModel();

            // conversation Id, this set of varibles are sent back to the client...
            int requestAgent = 0;
            string customerName = "";
            bool isAgentRequested = false;

            var requestPath = Server.MapPath("../JsonFilesTemporary/jsonRequest.json");
            var requestAgentsPath = Server.MapPath("../JsonFilesTemporary/requestAgents.json");

            List<RequestViewModel> requests = new List<RequestViewModel>();
            List<RequestAgentModel> requestAgents = new List<RequestAgentModel>();

            JsonFileManager.LoadJson(ref requests, requestPath);
            JsonFileManager.LoadJson(ref requestAgents, requestAgentsPath);

            agentRequested = requestAgents.Where(r => r.idAgent == idAgent).FirstOrDefault();

            if (agentRequested != null)
            {
                isAgentRequested = true;

                requestAgent = agentRequested.idRequestAgent;

                customerRequest = requests.Where(r => r.IdRequestCustomer == agentRequested.idCustomerRequest).FirstOrDefault();

                customerName = customerRequest.CustomerName + " " + customerRequest.Email;
            }

            return Json(new { isAgentRequested = isAgentRequested, requestAgent = requestAgent, customerName = customerName }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BroadCastMessage(MessagesModel message) 
        {

            bool result = true;
             var messagesPath = Server.MapPath("../JsonFilesTemporary/jsonMessages.json");

            Random rnd = new Random();
            var randomid = rnd.Next(1, 1000);
            message.IdMessage = randomid;
            try 
	        {	        
		        JsonFileManager.LoadJson(ref _messages, messagesPath);      
                _messages.Add(message);
                JsonFileManager.saveRequests(_messages, messagesPath);

	        }
	        catch (Exception)
	        {
                result = false;
		        
	        }
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }

    }
}
