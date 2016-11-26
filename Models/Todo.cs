using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace apiapp.demo.Models
{
    public class Todo
    {
        public static List<Todo> todos = new List<Todo>
        {
            new Todo
            {
                Id = 1,
                Name = "Lavar o carro"
            },
            new Todo
            {
                Id = 2,
                Name = "Fazer almoço"
            },
            new Todo
            {
                Id = 3,
                Name = "Fazer a compa do mês"
            },
            new Todo
            {
                Id = 4,
                Name = "Gravar mais vídeos sobre Azure Api Apps"
            },
            new Todo
            {
                Id = 5,
                Name = "Demo Azure Api Apps"
            }
        };

        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsComplete { get; set; }

        public Todo Create(Todo todo)
        {
            todo.Id = todos.Count + 1;
            todos.Add(todo);
            return todo;
        }
    }
}