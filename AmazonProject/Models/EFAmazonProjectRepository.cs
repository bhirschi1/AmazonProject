using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    public class EFAmazonProjectRepository : IAmazonProjectRepository
    {
        private BookstoreContext context { get; set; }

        public EFAmazonProjectRepository (BookstoreContext temp)
        {
            context = temp;
        }
        // This IQueryable object of type Books takes place of what used to be a List of type <Books>
        // for the Index.cshtml
        public IQueryable<Books> Books => context.Books;
    }
}
