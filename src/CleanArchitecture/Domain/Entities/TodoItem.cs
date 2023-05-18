﻿using Domain.Common;
using Domain.Enums;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TodoItem : BaseAuditableEntity
    {
        public int ListId { get; set; }

        public string? Title { get; set; }

        public string? Note { get; set; }

        public PriorityLevel Priority { get; set; }

        public DateTime? Reminder { get; set; }

        private bool _done;
        public bool Done
        {
            get => _done;
            set
            {
                if (value && !_done)
                {
                   AddDomainEvent(new TodoItemCompletedEvent(this));
                }

                _done = value;
            }
        }

        public TodoList List { get; set; } = null!;
    }
}
