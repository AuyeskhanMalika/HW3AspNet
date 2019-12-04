using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW3AspNet.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public ToDo()
        {
            Tags = new List<Tag>();
        }
    }
}