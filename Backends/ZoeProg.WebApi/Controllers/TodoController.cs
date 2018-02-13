using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoeProg.WebApi.Models;

namespace ZoeProg.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext context;

        public TodoController(TodoContext context)
        {
            this.context = context;

            if (!this.context.TodoItems.Any())
            {
                this.context.TodoItems.Add(new TodoItem { Name = "Item1" });
                this.context.SaveChanges();
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            this.context.TodoItems.Add(item);
            this.context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = this.context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            this.context.TodoItems.Remove(todo);
            this.context.SaveChanges();
            return new NoContentResult();
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return this.context.TodoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = this.context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}