using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PagingSample.Services;

namespace PagingSample.Pages
{
    public class _TablePartialModel : PageModel
    {
        public void OnGet([FromServices] BooksService bs)
        {

        }
    }
}