using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerChat.Repository
{
    public class RepositoryRequest
    {
            
        

        public IEnumerable<SelectListItem> getDocumentTypes()
        {
            List<SelectListItem> documentTypes = new List<SelectListItem>();


            documentTypes.Add(new SelectListItem { Selected = true, Value = "0", Text = "Select Option" });
            documentTypes.Add(new SelectListItem { Selected = false, Value = "1", Text = "Document" });
            documentTypes.Add(new SelectListItem { Selected = false, Value = "2", Text = "Passport" });


            return new SelectList(documentTypes, "Value", "Text");


        }

          
    }
}