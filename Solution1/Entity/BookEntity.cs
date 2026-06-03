using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BookEntity
    {
        string bookId;

        public string BookId
        {
            get { return bookId; }
            set { bookId = value; }
        }
        string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        string press;

        public string Press
        {
            get { return press; }
            set { press = value; }
        }
        double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        int stock;

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        int saleCounts;

        public int SaleCounts
        {
            get { return saleCounts; }
            set { saleCounts = value; }
        }
        string photo;

        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }
        string descriptions;

        public string Descriptions
        {
            get { return descriptions; }
            set { descriptions = value; }
        }
        bool isOnline;

        public bool IsOnline
        {
            get { return isOnline; }
            set { isOnline = value; }
        }
    }
}
