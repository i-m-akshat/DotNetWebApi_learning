using System;
using backend.DTOs.Stocks;
using backend.Models;


namespace backend.Interfaces{
    public interface IStockRepo{
        Task<List<Stocks>> GetAllAsync();
        Task<Stocks?> GetByIdAsync(int id);
        Task<Stocks> CreateAsync(Stocks _model);
        Task<Stocks?> UpdateAsync(int id, UpdateRequestDto _udpateDto);
        Task<Stocks?> DeleteAsync(int id);
    }
}