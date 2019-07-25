using PagingSample.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PagingSample.Services
{
    public class BooksService
    {
        public List<catalogBook> BuchListe { get; set; }
        public BooksService()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(catalog));
            var pfad = AppDomain.CurrentDomain.GetData("WWWBaseDirectory").ToString() +
                   "\\wwwroot\\app_data\\books.xml";
            using (var myFileStream = new FileStream(pfad, FileMode.Open))
            {
              var Bucharray = (catalog)mySerializer.Deserialize(myFileStream);
                BuchListe = Bucharray.book.ToList<catalogBook>();
            }


        }
    }
}
