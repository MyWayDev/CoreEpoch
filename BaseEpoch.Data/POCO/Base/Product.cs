using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Promotion;
using BaseEpoch.Data.POCO.TimeLine;



namespace BaseEpoch.Data.POCO.Base
{
    
   
   public class Product
    {
       public Product()
       {
        // ProductGroup =  new ProductGroup();
        // ProductPrices = new List<ProductPrice>();
       }
       public virtual IList<ProductPrice> ProductPrices { get; set; }

        public int GroupId { get; set; }
         public ProductGroup ProductGroup { get; set; }         
         public virtual IList<Promo> Promos { get; set; }       
        public virtual IList<SalesHistory> SalesHistories { get; set; }
         public virtual IList<PromoProduct> PromoProducts { get; set; }
         public virtual IList<ProductParam> ProductParams { get; set; }
         public virtual IList<ForcastParam> ForcastParams { get; set; } 
        public string Id { get; set; }
        
       
        public string ProductName { get; set; }
        
        public bool Active { get; set; }
       
        public DateTime AddDate { get; set; }
     
       public bool Booking { get; set; }
       public Type ProductType { get; set; } 
        public bool Discontnuied { get; set; }
     
       public enum Type
       {
           Sku=0,
           NonSku=1
       }
    }
}
