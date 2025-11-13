using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Interface;
using Lab.Enum;

namespace Lab.Class
{
    public static class PermissionService
    {
        static public bool CanInteractWithCompany(IUserInfo userInfo)
        {
            return userInfo is CEO;
        }

        static public bool CanInteractWithProjectBoard(IUserInfo userInfo)
        {
            return userInfo is CEO || userInfo is ProjectManager;
        }

        static public bool CanInteractWithTask(IUserInfo userInfo)
        {
            return userInfo is CEO || userInfo is ProjectManager || userInfo is Employee;
        }
    }
}
