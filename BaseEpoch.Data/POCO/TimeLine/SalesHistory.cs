﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Base;
using BaseEpoch.Data.POCO.Promotion;

namespace BaseEpoch.Data.POCO.TimeLine
{
    public class SalesHistory
    {
        
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int GroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public int PromoId { get; set; }
        public virtual Promo Promo { get; set; }

        public int Units { get; set; }
        public int Value { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public int Forecast { get; set; }
        public int CountOutDays { get; set; }
        public bool Booking { get; set; }
        public float Price { get; set; }

    }
}
