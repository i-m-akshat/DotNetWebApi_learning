using System;
using backend.Models;
using backend.DTOs;
namespace backend.Mappers{


    public static class CommentMapper{


        public static CommentDto ToCommentDto(this Comments model){
            return new CommentDto{
                Title=model.Title,
                Content=model.Content,
                CreatedOn=model.CreatedOn,
                StockID=model.StockID
            };
        }
        public static Comments FromCommentDtoToModel(this CreateCommentRequest _commentRequestDto){
            return new Comments{
                Title=_commentRequestDto.Title,
                Content=_commentRequestDto.Content,
                CreatedOn=_commentRequestDto.CreatedOn,
                StockID=_commentRequestDto.StockID
            };
        }
    }
}