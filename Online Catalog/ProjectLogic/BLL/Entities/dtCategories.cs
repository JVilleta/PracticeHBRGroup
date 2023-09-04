

using System;
using System.Collections.Generic;

namespace ProjectLogic.BLL.Entities
{
    public class dtCategories
    {
        public int Id { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public string Descriptions { get; set; }
        public bool Status { get; set; }
        public string Author { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public virtual ICollection<dtProducts> Products { get; set; }

    }
}
