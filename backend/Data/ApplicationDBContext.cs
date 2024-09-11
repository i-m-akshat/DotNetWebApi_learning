using System;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        :base(dbContextOptions)//this passing here our created application db context into the real db context 
        {
            
        }
        public DbSet<Stocks> stocks{get;set;}
        public DbSet<Comments> comments{get;set;}
    }
}