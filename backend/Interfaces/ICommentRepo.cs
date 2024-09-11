using System;
using backend.DTOs;
using backend.Models;


namespace backend.Interfaces{

    public interface ICommentRepo{
        Task<List<Comments>> getAllAsync();
        Task<Comments?> CreateAsync(Comments comments);
        Task<Comments?> UpdateAsync(int id, UpdateCommentRequest _updateDto);
        Task<Comments> GetByIdAsync(int id);
    }
}