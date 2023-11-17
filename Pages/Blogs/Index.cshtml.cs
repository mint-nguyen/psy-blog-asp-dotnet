using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MintPsyBlog.Data;
using MintPsyBlog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Categorys { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BlogCategory { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of categorys.
            IQueryable<string> categoryQuery = from m in _context.Blog
                                            orderby m.Category
                                            select m.Category;

            var blogs = from m in _context.Blog
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                blogs = blogs.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BlogCategory))
            {
                blogs = blogs.Where(x => x.Category == BlogCategory);
            }
            Categorys = new SelectList(await categoryQuery.Distinct().ToListAsync());
            Blog = await blogs.ToListAsync();
        }
    }
}
