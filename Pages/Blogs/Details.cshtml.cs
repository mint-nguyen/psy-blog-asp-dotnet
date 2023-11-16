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
    public class DetailsModel : PageModel
    {
        private readonly MintPsyBlog.Data.MintPsyBlogContext _context;

        public DetailsModel(MintPsyBlog.Data.MintPsyBlogContext context)
        {
            _context = context;
        }

        public Blog Blog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog.FirstOrDefaultAsync(m => m.ID == id);
            if (blog == null)
            {
                return NotFound();
            }
            else
            {
                Blog = blog;
            }
            return Page();
        }
    }
}
