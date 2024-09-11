using System;
using backend.Data;
using backend.DTOs.Stocks;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers{
    [Route("api/stock")]
    [ApiController]
    public class StockControllers:ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockControllers(ApplicationDBContext context)
        {
            _context=context;
        }
        [HttpGet]
        public IActionResult GetAll(){
            // var stocks=_context.stocks.ToList();
            var stocks=_context.stocks.ToList().Select(x=>x.ToStockDto());
            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            var stock=_context.stocks.Find(id);
            if(stock!=null)
            {
                return Ok(stock.ToStockDto());
            }
            else{
                return NotFound();
            }
            
        }
       [HttpPost]
        public IActionResult Create([FromBody]CreateStockRequest stockRequestDto){
                var stockModel=stockRequestDto.ToStockFromCreateDto();
                _context.stocks.Add(stockModel);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetById),new{id=stockModel.Id},stockModel.ToStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateRequestDto _updateStockRequestDto){
            var stockModel=_context.stocks.FirstOrDefault(x=>x.Id==id);
            if(stockModel==null){
                return NotFound();
            }
            stockModel.Symbol=_updateStockRequestDto.Symbol;
            stockModel.CompanyName=_updateStockRequestDto.CompanyName;
            stockModel.Purchase=_updateStockRequestDto.Purchase;
            stockModel.LastDiv=_updateStockRequestDto.LastDiv;
            stockModel.Industry=_updateStockRequestDto.Industry;
            stockModel.MarketCap=_updateStockRequestDto.MarketCap;
            _context.SaveChanges();
            return Ok(stockModel.ToStockDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id){
            var stockModel=_context.stocks.FirstOrDefault(x=>x.Id==id);
            if(stockModel!=null){
                _context.stocks.Remove(stockModel);
                _context.SaveChanges();
                return NoContent();
            }else{
                return NotFound();
            }
        }
    
    }
}