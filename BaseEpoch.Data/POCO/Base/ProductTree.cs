using System;
using System.Collections.Generic;
using System.Data.Entity.Hierarchy;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEpoch.Data.POCO.Base
{
    public class ProductTree
    {
        public ProductTree()
        {
            ProductGroup=new ProductGroup();
        }
        public int GroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
       
        public HierarchyId OrgNode { get; set; }
        public int OrgLevel { get; private set; }
        //note: delete from stored proc script 'addgroup'
        //public string TreeName { get; set; }
        public int? ParentId { get; set; }
    }
}
