using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace backend.Models
{
    public class Stocks
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;


        [Column(TypeName = "decimal(10,2)")]
        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }
        public string Industry { get; set;} = string.Empty;
        public long MarketCap { get; set; }

        public List<Comments> Comments{get;set;}= new List<Comments>(); 

    }
}