using System;
using backend.Data;
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
        public Task<List<Stocks>> GetAllAsync()
        {
            return _context.stocks.ToListAsync();
        }
    }
}