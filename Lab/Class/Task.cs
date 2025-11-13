using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Interface;
using Lab.Enum;

namespace Lab.Class
{
    public class Task : IPrintable, ICloneable
    {
        public string Name { get; set; }
        public TaskStat CurrentStatus { get; set; } = TaskStat.ToDo;
        public IUserInfo? Assignee { get; set; } = null;

        public Task()
        {
            Name = "Task";
        }
        public Task(string name) : this()
        {
            Name = name;
        }
        public Task(string name, IUserInfo assignee) : this(name)
        {
            Assignee = assignee;
        }

        public void AssignEmployee(IUserInfo sessionUser, IUserInfo assignee)
        {
            if (PermissionService.CanInteractWithProjectBoard(sessionUser))
            {
                Assignee = assignee;
            }
        }

        public void UnassignEmployee(IUserInfo assignee, IUserInfo sessionUser)
        {
            if (PermissionService.CanInteractWithProjectBoard(sessionUser))
            {
                Assignee = null;
            }
        }
        public void ChangeName(IUserInfo sessionUser, string name)
        {
            if (PermissionService.CanInteractWithProjectBoard(sessionUser))
            {
                Name = name;
            }
        }
        public void MoveTask(IUserInfo assaignee, TaskStat NewStatus)
        {
            if (PermissionService.CanInteractWithTask(assaignee))
            {
                CurrentStatus = NewStatus;
            }
        }

        public string GetInfo()
        {
            string assigneeName = (Assignee != null) ? Assignee.Name : "Unassigned";
            return $"[Task] - {Name} | Status: {CurrentStatus} | Assignee: {assigneeName}";
        }

        public object Clone()
        {
            return new Task(Name, Assignee);
        }
    }
}