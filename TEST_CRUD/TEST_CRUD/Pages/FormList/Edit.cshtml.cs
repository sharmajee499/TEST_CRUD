using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TEST_CRUD.Model;

namespace TEST_CRUD.Pages.FormList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public InfoList InfoList { get; set; }
        public void OnGet(int Id)
        {
            InfoList = _db.InfoList.Find(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var InfoListFromDB = await _db.InfoList.FindAsync(InfoList.Id);
                InfoListFromDB.FirstName = InfoList.FirstName;
                InfoListFromDB.LastName = InfoList.LastName;
                InfoListFromDB.Age = InfoList.Age;

                await _db.SaveChangesAsync();
               return RedirectToPage("Index");
            }


        return RedirectToPage();

        }

    }
} 