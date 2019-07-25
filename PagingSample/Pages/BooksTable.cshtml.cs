using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PagingSample.Model;
using PagingSample.Services;

namespace PagingSample.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class BooksTableModel : PageModel
    {
        public List<catalogBook> PagedBuchListe { get; set; }
        public void OnGet()
        {

        }
        public ActionResult OnPostLade([FromServices] BooksService bs)
        {
            
            var q = Request.QueryString.Value; //?par1=wert
            NameValueCollection q1 =HttpUtility.ParseQueryString(q);
            var page = int.Parse(q1[0]);
            PagedBuchListe = bs.BuchListe.Skip(page * 5).Take(5).ToList();
            page++;

            HttpContext.Response.Headers.Add("x-"+q1.Keys[0],page.ToString());

            return Partial("_TablePartial",this);
        }

    }
}