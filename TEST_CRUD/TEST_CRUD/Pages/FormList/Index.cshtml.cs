using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TEST_CRUD.Model;

namespace TEST_CRUD.Pages.FormList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public InfoList InfoList { get; set; }

        public IEnumerable<InfoList> InfoLists { get; set; }
        public async Task OnGet()
        {
            InfoLists = await _db.InfoList.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var infolist = await _db.InfoList.FindAsync(id);
            if (infolist == null)
            {
                return NotFound();
            }

            _db.InfoList.Remove(infolist);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");

        }

        
       
    }
}