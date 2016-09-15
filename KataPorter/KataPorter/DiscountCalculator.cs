using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPorter
{
    public class DiscountCalculator
    {
        public Dictionary<int,double>  DiscountMap = new Dictionary<int, double>();

        private int _numberOfBooks = 5;

        public DiscountCalculator()
        {
                DiscountMap.Add(1,1);
                DiscountMap.Add(2,0.95);
                DiscountMap.Add(3,0.9);
                DiscountMap.Add(4,0.8);
                DiscountMap.Add(5,0.75);
        }

        public double GetBestPrice(int[] books)
        {
            if (books == null) throw new ArgumentNullException($"Argument{nameof(books)} cannot be null");

            if (books.Length == 0) throw new ArgumentException($"Invalid number of books");

            double price = double.MaxValue;

            var distinctBooks = books.Distinct();

            if(distinctBooks.Count() == _numberOfBooks)
            {

            }

            for(var i=5;i<=5;i++)
            {
                var newPrice = this.GetBestPrice(books, i);
                if(newPrice<price)
                {
                    price = newPrice;
                }
            }
            return price;
        }

        private double GetBestPrice(int[] books, int capacity)
        {
            var listOfOrderedBooks = new List<List<int>>();

            foreach(var book in books)
            {
                bool flag = false;

                foreach (var listOfBooks in listOfOrderedBooks)
                {
                    if(!listOfBooks.Contains(book) && listOfBooks.Capacity > listOfBooks.Count)
                    {
                        listOfBooks.Add(book);
                        flag = true;
                        break;
                    }
                }
                if(!flag)
                {
                    var listOfBooks = new List<int>(capacity);
                    listOfBooks.Add(book);
                    listOfOrderedBooks.Add(listOfBooks);
                }
            }

            //Compute the Price
            var price = 0.0;

            foreach(var listOfBooks in listOfOrderedBooks)
            {
                price = price + listOfBooks.Count() * 8 * DiscountMap[listOfBooks.Count()]; 
            }

            //Resizing the Lists
            //1.Find the list with More room
            var listsWithRoom = listOfOrderedBooks.Where(listOfBooks => listOfBooks.Count() < capacity);
            var listsWithNoRoom = listOfOrderedBooks.Where(listOfBooks => listOfBooks.Count() == capacity);

            foreach (var listWithNoRoom in listsWithNoRoom)
            {
                foreach (var book in listWithNoRoom)
                {
                    bool flag = false;
                    foreach (var listWithRoom in listsWithRoom)
                    {
                        if (!listWithRoom.Contains(book) && listWithRoom.Count() != listsWithNoRoom.Count())
                        {
                            listWithRoom.Add(book);
                            listWithNoRoom.Remove(book);
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                        break;
                }
            }

            //ReCompute Price
            var newPrice = 0.0;
            foreach (var listOfBooks in listOfOrderedBooks)
            {                
                newPrice = newPrice + listOfBooks.Count() * 8 * DiscountMap[listOfBooks.Count()];
            }

            if (newPrice < price)
            {
                price = newPrice;
            }

            return price;
        }
    }
}
