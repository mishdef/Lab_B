using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Interface;

namespace Lab.Class
{
    public class Company
    {
        public string Name { get; set; }
        public List<IUserInfo> Employees { get; set; } = new List<IUserInfo>();
        public List<ProjectBoard> ProjectBoards { get; } = new List<ProjectBoard>();

        public Company(IUserInfo CEO)
        {
            Name = "Company";
            AddEmployee(CEO, CEO);
        }

        public Company(IUserInfo CEO, string name) : this(CEO)
        {
            Name = name;
        }

        public void CreateProjectBoard(IUserInfo sessionUser, string name)
        {
            if (sessionUser is CEO)
            {
                ProjectBoards.Add(new ProjectBoard(name));
            }

            else
            {
                throw new Exception("Only CEO can create project board");
            }
        }

        public void AddEmployee(IUserInfo sessionUser, IUserInfo newEmployee)
        {
            if (sessionUser is CEO)
            {
                Employees.Add(newEmployee);
            }
            else
            {
                throw new Exception("Only CEO can add employee");
            }
        }
        public void ChangeName(IUserInfo sessionUser, string name)
        {
            if (sessionUser is CEO)
            {
                Name = name;
            }
            else
            {
                throw new Exception("Only CEO can change name");
            }
        }
        public void RemoveEmployee(IUserInfo sessionUser, IUserInfo employee)
        {
            if (sessionUser == employee)
            {
                throw new Exception("You can't remove yourself");
            }
            if (sessionUser is CEO)
            {
                Employees.Remove(employee);
            }
            else
            {
                throw new Exception("Only CEO can remove employee");
            }
        }
        public void RemoveProjectBoard(IUserInfo sessionUser, ProjectBoard projectBoard)
        {
            if (sessionUser is CEO)
            {
                ProjectBoards.Remove(projectBoard);
            }
            else
            {
                throw new Exception("Only CEO can remove project board");
            }
        }
    }
}
