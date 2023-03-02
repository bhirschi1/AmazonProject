using AmazonProject.Models;
using AmazonProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Controllers
{
    public class HomeController : Controller
    {

        private IAmazonProjectRepository repo;

        public HomeController (IAmazonProjectRepository temp)
        {
            repo = temp;
        }
        //this Index action will create the BooksViewModel used in the Index.cshtml
        
        public IActionResult Index(int pageNum = 1)
        {
            //Determining how many books are displayed on each page

            int pageSize = 10;

            var x = new BooksViewModel
            {
                //Info on the books, when on a page that isn't page 1, we want to skip 
                // displaying all the books that are on the previous pages.
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                // Info on the page used in the dynamically created <a> tags w hrefs on the Index.cshtml page
                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            
            return View(x);
        }
    }
}
