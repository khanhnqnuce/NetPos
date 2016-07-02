using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FDI.Simple
{
    public class RegisteredAgencyItem : BaseSimple
    {
        public string UserName { get; set; }
        public string Code { get; set; }
        public string AgencyName { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsSMS { get; set; }

    }

    public class ModelRegisteredAgencyItem : BaseModelSimple
    {
        public ModelRegisteredAgencyItem()
        {
            ListSelect=new List<SelectListItem>();
            Item=new RegisteredAgencyItem();
        }
        public RegisteredAgencyItem Item { get; set; }
        public List<SelectListItem> ListSelect { get; set; }
        public IEnumerable<RegisteredAgencyItem> ListItem { get; set; }
    }

}
