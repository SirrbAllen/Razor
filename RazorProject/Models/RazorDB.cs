using System;
using System.Data.Entity;
using System.Linq;

namespace RazorProject.Models
{    
    public class RazorDB : DbContext
    {
        public RazorDB()
            : base("name=RazorDB")
        {
        }

        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }

    public class Technology
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Priority { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
    }

    public class Account
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Verified { get; set; }
    }
}