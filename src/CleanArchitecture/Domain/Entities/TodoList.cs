using Domain.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Libs.DirectShowLib;

namespace Domain.Entities
{
    public class TodoList : BaseAuditableEntity
    {
        public string? Title { get; set; }
        public Colour Colour { get; set; }

        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}
