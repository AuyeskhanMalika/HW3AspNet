using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW3AspNet.Models
{
    public class ViewModelToDo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ViewModelTag Tag { get; set; }
    }
}