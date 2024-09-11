using System;
using backend.Data;
using backend.DTOs.Stocks;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.Repository
{

    public class StockRepo : IStockRepo
    {
        private readonly ApplicationDBContext _context;
        public StockRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stocks> CreateAsync(Stocks _model)
        {
            await _context.AddAsync(_model);
            await _context.SaveChangesAsync();
            return _model;

        }

        public async Task<Stocks?> DeleteAsync(int id)
        {
            var stockModel=await _context.stocks.FirstOrDefaultAsync(x=>x.Id==id);
            if(stockModel==null){
                return null;
            }
            _context.Remove(stockModel);
            
            await _context.SaveChangesAsync();
            return stockModel;

        }

        public async Task<List<Stocks>> GetAllAsync()
        {
            return await _context.stocks.ToListAsync();
        }

        public async Task<Stocks?> GetByIdAsync(int id)
        {
            var stockModel=await _context.stocks.FindAsync(id);
            if(stockModel!=null){
                return stockModel;
            }else{
                return null;
            }
        }

        public async Task<Stocks?> UpdateAsync(int id, UpdateRequestDto _updateDto)
        {
            var stockModel=await _context.stocks.FirstOrDefaultAsync(x=>x.Id==id);
            if(stockModel==null){
                return null;
            }
            // stockModel.Symbol=_udpateDto.Symbol;
            // stockModel.CompanyName=_udpateDto.CompanyName;
            // stockModel.Purchase=_udpateDto.Purchase;
            // stockModel.LastDiv=_udpateDto.LastDiv;
            // stockModel.Industry=_udpateDto.Industry;
            // stockModel.MarketCap=_udpateDto.MarketCap;

            stockModel.Symbol=_updateDto.Symbol!=null? _updateDto.Symbol:stockModel.Symbol;
            stockModel.CompanyName=_updateDto.CompanyName!=null?_updateDto.CompanyName:stockModel.CompanyName;
            stockModel.Purchase=_updateDto.Purchase!=null? _updateDto.Purchase:stockModel.Purchase;
            stockModel.LastDiv=_updateDto.LastDiv!=null?_updateDto.LastDiv: stockModel.LastDiv;
            stockModel.Industry=_updateDto.Industry!=null?_updateDto.Industry:stockModel.Industry;
            stockModel.MarketCap=_updateDto.MarketCap!=null?  _updateDto.MarketCap:stockModel.MarketCap;

            await _context.SaveChangesAsync();
            return stockModel;

        }
    }
}