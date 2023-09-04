

using System;

namespace ProjectLogic.BLL.Entities
{
    public class dtProducts
    {
        public int? Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public bool Status { get; set; }
        public string Author { get; set; }
        public string CreationDate { get; set; } 
        public string UpdateDate { get; set; }
        public int IdCategory { get; set; }
        public virtual dtCategories Category { get; set; } = new dtCategories();
    }
}
