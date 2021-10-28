using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace scriptureJournal.Pages.Journals
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournalContext _context;

        public IndexModel(ScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Journal> Journal { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from m in _context.Journal
                                           orderby m.Book
                                           select m.Book;

            var journals = from m in _context.Journal
                           select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                journals = journals.Where(s => s.Notes.ToLower().Contains(SearchString.ToLower()));
            }

            if (!string.IsNullOrEmpty(BookGenre))
            {
                journals = journals.Where(x => x.Book == BookGenre);
            }


            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Journal = await journals.ToListAsync();
        }
    }
}
