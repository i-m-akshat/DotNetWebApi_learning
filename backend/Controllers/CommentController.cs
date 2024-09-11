using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using backend.Interfaces;
using backend.Mappers;
using backend.DTOs;


namespace backend.Controllers{


[Route("api/[controller]")]
[ApiController]
    public class CommentController:ControllerBase
    {
        private readonly ICommentRepo _repo;
        public CommentController(ICommentRepo repo)
        {
            _repo=repo;
        }
        public async Task<IActionResult> GetAll(){
            var comments=await _repo.getAllAsync();
            var _commentDto=comments.Select(x=>x.ToCommentDto());
            if(comments!=null){
                return Ok(_commentDto);
            }else{
                return NotFound();
            }
        }
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id){
            var comments=await _repo.GetByIdAsync(id);
            if(comments!=null){
                return Ok(comments.ToCommentDto());
            }else{
                return NotFound();
            }
        }
   
   
    }
}