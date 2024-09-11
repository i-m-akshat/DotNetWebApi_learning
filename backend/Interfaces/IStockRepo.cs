using System;
using backend.Models;


namespace backend.Interfaces{
    public interface IStockRepo{
        Task<List<Stocks>> GetAllAsync();
    }
}