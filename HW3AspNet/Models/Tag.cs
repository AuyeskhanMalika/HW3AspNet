using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW3AspNet.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<ToDo> Todos { get; set; }

        public Tag()
        {
            Todos = new List<ToDo>();
        }
    }
}