using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace backend.Models
{
    public class Comments
    {
        public int ID{get;set;}
        public string Title{get;set;}=string.Empty;
        public string Content{get;set;}=string.Empty;
        public DateTime CreatedOn{get;set;}
        public int? StockID { get; set; }
        //Navigational Property
        public Stocks? Stocks{get;set;}
    }
}