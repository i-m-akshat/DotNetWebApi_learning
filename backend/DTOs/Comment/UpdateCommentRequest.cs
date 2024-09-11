using System;



namespace backend.DTOs{


    public class UpdateCommentRequest{
        public string Title{get;set;}=string.Empty;
        public string Content{get;set;}=string.Empty;
        public DateTime CreatedOn{get;set;}
        public int? StockID { get; set; }
    }
}