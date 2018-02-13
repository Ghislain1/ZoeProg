using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoeProg.WebApi.Models;
using ZoeProg.WebApi.Services;

namespace ZoeProg.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        // GET api/books
        [HttpGet]
        public IEnumerable<Book> GetAlls()
        {
            return this.bookRepository.Books;
        }

        [HttpGet("{id}", Name = "GetTodo1")]
        public IEnumerable<Book> GetById(long id)
        {
            var item = this.bookRepository.BookStoreList.FirstOrDefault();

            return this.bookRepository.Books;
        }

        //[HttpGet("{id}", Name = "GetTodo1")]
        //public IActionResult GetById(long id)
        //{
        //    var item = this.bookRepository.BookStoreList.FirstOrDefault();
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return new ObjectResult(item);
        //}
    }
}