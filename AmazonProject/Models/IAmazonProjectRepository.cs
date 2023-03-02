using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    public interface IAmazonProjectRepository
    {
        IQueryable<Books> Books { get; }
    }
}
