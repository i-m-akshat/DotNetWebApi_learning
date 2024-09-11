using System;
using backend.Data;
using backend.DTOs;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace backend.Repository
{

    public class CommentRepo : ICommentRepo
    {

        private readonly ApplicationDBContext _context;
        public CommentRepo(ApplicationDBContext context)
        {
            _context = context;

        }
        public async Task<Comments?> CreateAsync(Comments comments)
        {
            try
            {
                await _context.comments.AddAsync(comments);
                await _context.SaveChangesAsync();
                return comments;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Comments>> getAllAsync()
        {
            return await _context.comments.ToListAsync();
        }

        public async Task<Comments> GetByIdAsync(int id)
        {
            var commentModel = await _context.comments.FindAsync(id);
            if (commentModel != null)
            {
                return commentModel;
            }
            else
            {

                return null;
            }

        }

        public async Task<Comments?> UpdateAsync(int id, UpdateCommentRequest _updateDto)
        {
            var commentModel = await _context.comments.FindAsync(id);
            if (commentModel != null)
            {
                commentModel.Title = _updateDto.Title != null ? _updateDto.Title : commentModel.Title;
                commentModel.Content = _updateDto.Content != null ? _updateDto.Content : commentModel.Content;
                commentModel.CreatedOn = _updateDto.CreatedOn != null ? _updateDto.CreatedOn : commentModel.CreatedOn;
                commentModel.StockID = _updateDto.StockID != null ? _updateDto.StockID : commentModel.StockID;

                await _context.SaveChangesAsync();
                return commentModel;
            }
            else
            {
                return null;
            }
        }
    }
}