using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseEpoch.Data.POCO.Base;
using BaseEpoch.Data.POCO.Promotion;
using BaseEpoch.Data.POCO.TimeLine;

namespace Mvc.Models
{
    public class PGModel
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public string Id { get; set; }
        public string OldId { get; set; }

        public string ProductName { get; set; }

        public bool Active { get; set; }

        public DateTime? AddDate { get; set; }

        public bool Booking { get; set; }
        public Product.Type ProducType { get; set; }
        public bool Discontnuied { get; set; }
    }
}