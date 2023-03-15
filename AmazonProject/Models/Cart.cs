using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    // this class Cart is the basis for the user's purchasing session
    // will AddItems, remove items, and clear the cart when purchased.
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public virtual void AddItem (Books book, int qty)
        {
            CartItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new CartItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        
        public virtual void RemoveItem (Books book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearCart()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }

    //this class CartItem includes information about the qty of each book going ot be purchased
    public class CartItem
    {
        [Key]
        public int LineID { get; set; }
        public Books Book { get; set;  }
        public int Quantity { get; set; }
    }
}
