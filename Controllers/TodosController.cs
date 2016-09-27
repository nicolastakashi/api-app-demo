using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using apiapp.demo.Models;
using System.ComponentModel.DataAnnotations;

namespace apiapp.demo.Controllers
{
    [Route("api/todos")]
    public class TodoController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(Todo), 200)]
        public static IEnumerable<Todo> Get() => Todo.todos;

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Todo), 200)]
        [ProducesResponseType(typeof(Todo), 204)]
        public static Todo Get([FromRoute, Required] int id) => Todo.todos.Find(x => x.Id == id);

        [HttpPost]
        [ProducesResponseType(typeof(Todo), 201)]
        [ProducesResponseType(typeof(Todo), 400)]
        public IActionResult Post([FromBody, Required]Todo todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }

            todo = todo.Create(todo);
            return CreatedAtRoute(nameof(Get), new { id = todo.Id }, todo);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(Todo), 400)]
        [ProducesResponseType(typeof(Todo), 200)]
        public IActionResult Put([FromRoute, Required]int id, [FromBody, Required]Todo todo)
        {
            var actualTodo = Todo.todos.Find(x => x.Id == id);

            if (actualTodo == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Todo), 400)]
        [ProducesResponseType(typeof(Todo), 200)]
        public IActionResult Delete([FromRoute, Required]int id)
        {
            var todo = Todo.todos.Find(x => x.Id == id);

            if (todo == null)
            {
                return BadRequest();
            }

            Todo.todos.Remove(todo);
            return Ok();
        }
    }
}