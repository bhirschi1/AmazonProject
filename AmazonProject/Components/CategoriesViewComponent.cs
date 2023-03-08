using AmazonProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IAmazonProjectRepository repo { get; set; }
        public CategoriesViewComponent (IAmazonProjectRepository temp)
        {
            repo = temp;
        }
        //this is when a category is selected and we filter the results down to just that category
        public IViewComponentResult Invoke()
        {
            //ViewBag is connected to the catType as found on the list of categories on the Default.cshtml page
            ViewBag.catType = RouteData?.Values["catType"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            //this was for debugging
            //Console.WriteLine($"CategoriesViewComponent invoked. Selected category: {ViewBag.catType}");
            return View(categories);
        }
    }
}
