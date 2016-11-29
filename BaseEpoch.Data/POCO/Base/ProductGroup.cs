using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.TimeLine;

namespace BaseEpoch.Data.POCO.Base
{
    public class ProductGroup
    {
        public ProductGroup()
        {
           // ProductTrees = new List<ProductTree>();
        }
        public IList<Product> Products { get; set; }
        public  IList<ProductTree> ProductTrees { get; set; }
        public  IList<SalesHistory> SalesHistories { get; set; }

        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public int? Parentid { get; set; }


    }
}
