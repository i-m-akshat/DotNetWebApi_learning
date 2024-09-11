using System;
using backend.Data;
using backend.DTOs.Stocks;
using backend.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult>  GetAll(){
            // var stocks=_context.stocks.ToList();
            var stocks=await _context.stocks.ToListAsync();
            var stockDto=stocks.Select(x=>x.ToStockDto());
            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var stock=await _context.stocks.FindAsync(id);
            if(stock!=null)
            {
                return Ok(stock.ToStockDto());
            }
            else{
                return NotFound();
            }
            
        }
       [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateStockRequest stockRequestDto){
                var stockModel=stockRequestDto.ToStockFromCreateDto();
                await _context.stocks.AddAsync(stockModel);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById),new{id=stockModel.Id},stockModel.ToStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateRequestDto _updateStockRequestDto){
            var stockModel=await _context.stocks.FirstOrDefaultAsync(x=>x.Id==id);
            if(stockModel==null){
                return NotFound();
            }
            stockModel.Symbol=_updateStockRequestDto.Symbol;
            stockModel.CompanyName=_updateStockRequestDto.CompanyName;
            stockModel.Purchase=_updateStockRequestDto.Purchase;
            stockModel.LastDiv=_updateStockRequestDto.LastDiv;
            stockModel.Industry=_updateStockRequestDto.Industry;
            stockModel.MarketCap=_updateStockRequestDto.MarketCap;
            await _context.SaveChangesAsync();
            return Ok(stockModel.ToStockDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var stockModel=await _context.stocks.FirstOrDefaultAsync(x=>x.Id==id);
            if(stockModel!=null){
                 _context.stocks.Remove(stockModel);
                await _context.SaveChangesAsync();
                return NoContent();
            }else{
                return NotFound();
            }
        }
    
    }
}