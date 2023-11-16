using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MintPsyBlog.Models;

namespace MintPsyBlog.Data
{
    public class MintPsyBlogContext : DbContext
    {
        public MintPsyBlogContext (DbContextOptions<MintPsyBlogContext> options)
            : base(options)
        {
        }

        public DbSet<MintPsyBlog.Models.Blog> Blog { get; set; } = default!;
    }
}
