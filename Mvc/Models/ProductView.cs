using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseEpoch.Data.POCO.Base;

namespace Mvc.Models
{
    public class ProductView
    {
        public IEnumerable<ProductGroup> ProductGroups { get; set; }    
      
        public Product Product { get; set; }
    }
}