using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models.ViewModels
{
    public class PageInfo
    {
        //This info gives us the number of pages needed as well as how many books are on each page

        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalNumBooks / BooksPerPage);

    }
}
