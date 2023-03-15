using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    //The new Controller Buy uses this file
    public interface IBuyRepository
    {
        IQueryable<Buy> Buys { get; }

        void SaveBuy(Buy buy)
        {

        }
    }
}
