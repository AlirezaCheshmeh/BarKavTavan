using AdminBarKavTavan.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminBarKavTavan.Services.Component
{
    public class ListOfBlogsViewComponent : ViewComponent
    {
        private readonly DataContext _db;

        public ListOfBlogsViewComponent(DataContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _db.Blog.ToListAsync());
    }
}
