using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DataAccess;
using System.Data;

namespace Business
{
    public static class BookBusiness
    {
        //获取所以图书
        public static DataTable GetBookTable()
        {
            return BookDA.GetDataTable("select * from tb_book", CommandType.Text, null, null);
        }
        /// <summary>
        /// 按bookId查找图书
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static BookEntity GetBookById(string bookId)
        {
            string cmdText = "select * from tb_book where BookId=@BookId";
            string[] paramNames = { "@BookId" };
            object[] paramValues = { bookId };
            DataTable dt = BookDA.GetDataTable(cmdText, CommandType.Text, paramNames, paramValues);
            if (dt.Rows.Count == 0)
                return null;
            BookEntity book= new BookEntity();
            book.BookId = dt.Rows[0]["BookId"].ToString();
            book.Title = dt.Rows[0]["Title"].ToString();
            book.Author = dt.Rows[0]["Author"].ToString();
            book.Press = dt.Rows[0]["Press"].ToString();
            book.Descriptions = dt.Rows[0]["Descriptions"].ToString();
            book.Price = double.Parse(dt.Rows[0]["Price"].ToString());
            book.Stock = int.Parse(dt.Rows[0]["Stock"].ToString());
            book.SaleCounts = int.Parse(dt.Rows[0]["SaleCounts"].ToString());
            book.IsOnline = bool.Parse(dt.Rows[0]["IsOnline"].ToString());
            book.Photo = dt.Rows[0]["Photo"].ToString();
            return book;
        }
    }
}
