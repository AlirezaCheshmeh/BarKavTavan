using BarKavTavan.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarKavTavan.Services.Component
{
    public class ListOfBlogViewComponent : ViewComponent
    {
        private readonly DataContext _db;

        public ListOfBlogViewComponent(DataContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _db.Blog.ToListAsync());
    }
}
