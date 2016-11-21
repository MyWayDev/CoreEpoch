using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BaseEpoch.Data.POCO.Base;


namespace BaseEpoch.Dtos
{
    public class ProductDto
    {
       

        public int GroupId { get; set; }
       

        public string Id { get; set; }
        public string OldId { get; set; }

        public string ProductName { get; set; }

        public bool Active { get; set; }

        public DateTime? AddDate { get; set; }

        public bool Booking { get; set; }
        //public ProductType Type { get; set; }
        public bool Discontnuied { get; set; }

      

      

      
     
    }
}
