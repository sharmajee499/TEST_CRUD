using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TEST_CRUD.Model;

namespace TEST_CRUD.Pages.FormList
{
    public class CreateModel : PageModel
    {
        //Initialized the db component
        private readonly ApplicationDbContext _db;

        //constructing the new db 
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public InfoList InfoList { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.InfoList.Add(InfoList);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");


        }
    }
}