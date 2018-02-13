using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoeProg.WebApi.Models;

namespace ZoeProg.WebApi.Services
{
    public interface IBookRepository
    {
        List<Book> Books { get; set; }
        List<BookStore> BookStoreList { get; set; }
    }
}