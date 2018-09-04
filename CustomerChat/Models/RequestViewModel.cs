using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerChat.Models
{
    public class RequestViewModel : RequestModel
    {


        [Display(Name = "Document Type")]
        public string SelectedDocumentType { get; set; }

        public IEnumerable<SelectListItem> DocumentTypes { get; set; }





    }
}