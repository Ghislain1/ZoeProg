using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoeProg.WebApi.Models;

namespace ZoeProg.WebApi.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly ISerializeService serializeService;

        public BookRepository(ISerializeService serializeService)
        {
            this.serializeService = serializeService;
            var item = this.serializeService.Deserialize(@"./Data/xxx.xml");
            this.BookStoreList = new List<BookStore>();
            this.BookStoreList.Add(item);

            this.Books = new List<Book>(item.Books);
        }

        public List<Book> Books { get; set; }

        public List<BookStore> BookStoreList { get; set; }
    }
}