using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.DDD1
{
    public enum PriorityEnum
    {
        High,
        Medium,

    }
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public Priority Priority { get; set; }
        public DueDate DueDate { get; set; }
    }

    public class Priority
    {
        public string Name { get; set; }
        public int Value { get; set; }
        
    }

    public class DueDate
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }


    public class ToDoList
    {
        public List<Task> Tasks { get; set; }

        public ToDoList()
        {
            Tasks = new List<Task>();

            // Add some tasks to the to-do list.
            Tasks.Add(new Task
            {
                Name = "Buy groceries",
                Description = "Milk, eggs, bread, etc.",
                Priority =  new Priority(),
                DueDate = new DueDate
                {
                    Date = DateTime.Now.AddDays(1),
                    Time = TimeSpan.FromHours(12)
                }
            });

            Tasks.Add(new Task
            {
                Name = "Clean the house",
                Description = "Vacuum, dust, mop, etc.",
                Priority = new Priority(),
                DueDate = new DueDate
                {
                    Date = DateTime.Now.AddDays(2),
                    Time = TimeSpan.FromHours(10)
                }
            });

            Tasks.Add(new Task
            {
                Name = "Do the laundry",
                Description = "Wash, dry, fold, etc.",
                Priority = new Priority(),
                DueDate = new DueDate
                {
                    Date = DateTime.Now.AddDays(3),
                    Time = TimeSpan.FromHours(8)
                }
            });
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public void RemoveTask(Task task)
        {
            Tasks.Remove(task);
        }

        public void MarkTaskComplete(Task task)
        {
            task.Completed = true;
        }

        public void UnmarkTaskComplete(Task task)
        {
            task.Completed = false;
        }

        public void SortTasksByPriority()
        {
            Tasks.Sort((t1, t2) => t1.Priority.Value - t2.Priority.Value);
        }

        public void SortTasksByDueDate()
        {
            Tasks.Sort((t1, t2) => t1.DueDate.Date.CompareTo(t2.DueDate.Date));
        }
    }
}
