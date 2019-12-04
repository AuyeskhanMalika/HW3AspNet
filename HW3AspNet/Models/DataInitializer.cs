using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW3AspNet.Models
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<ContextToDo>
    {
        protected override void Seed(ContextToDo context)
        {

            var tag = new Tag
            {
                TagName = "TestTagName"
            };
            var todo = new ToDo
            {
                Name = "TestName",
                Description = "TestDescription"
            };
            tag.Todos.Add(todo);
            todo.Tags.Add(tag);


            context.ToDos.Add(todo);
            context.Tags.Add(tag);
            context.SaveChanges();
        }
    }
}