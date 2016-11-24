using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeddingWCF.Class
{
    public class Hall
    {
        public int hallId { get; set; }
        public int CH_ID { get; set; }
        public string ID_Email  { get; set; }
        public string hallName { get; set; }
        public string hallDesc { get; set; }
        public double price { get; set; }
        public string Img { get; set; }
        public string phone { get; set; }
        public int City_Id { get; set; }
        public string Dis_Hall { get; set; }
        public string Street { get; set; }
        public string Services_Hall { get; set; }
        public double Latitle { get; set; }
        public double Logtii { get; set; }
        public double Men_Capacity { get; set; }
        public double Women_Capacity { get; set; }
        public bool IsActive { get; set; }
       


    }
}