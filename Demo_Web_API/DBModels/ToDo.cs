using System;
using System.Collections.Generic;

#nullable disable

namespace Demo_Web_API.DBModels
{
    public partial class ToDo
    {
        public string ToDoText { get; set; }
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
    }
}
