using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MintPsyBlog.Data;
using MintPsyBlog.Models;

namespace MintPsyBlog.Pages.Blogs
{
    public class IndexModel : PageModel
    {
        private readonly MintPsyBlog.Data.MintPsyBlogContext _context;

        public IndexModel(MintPsyBlog.Data.MintPsyBlogContext context)
        {
            _context = context;
        }

        public IList<Blog> Blog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Blog = await _context.Blog.ToListAsync();
        }
    }
}
