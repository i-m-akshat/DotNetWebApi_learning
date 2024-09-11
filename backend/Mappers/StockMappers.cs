using System;
using backend.DTOs.Stocks;
using backend.Models;


namespace backend.Mappers{
    public static class StockMappers{
        public static StockDto ToStockDto(this Stocks stockModel){
            return new StockDto{
                Id=stockModel.Id,
                Symbol=stockModel.Symbol,
                CompanyName=stockModel.CompanyName,
                Purchase=stockModel.Purchase,
                LastDiv=stockModel.LastDiv,
                Industry=stockModel.Industry,
                MarketCap=stockModel.MarketCap
            };
        }
        public static Stocks ToStockFromCreateDto(this CreateStockRequest stockdto){
 return new Stocks{
                Symbol=stockdto.Symbol,
                CompanyName=stockdto.CompanyName,
                Purchase=stockdto.Purchase,
                LastDiv=stockdto.LastDiv,
                Industry=stockdto.Industry,
                MarketCap=stockdto.MarketCap
            };
        }
   
    }

}