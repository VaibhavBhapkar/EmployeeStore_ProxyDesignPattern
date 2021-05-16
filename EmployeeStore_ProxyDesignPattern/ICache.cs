using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeStore_ProxyDesignPattern
{
    public interface ICache
    {
        string GetEmployeeValue(int employeeId);
        void SetEmployeeValue(int employeeId, string employeeName);
    }
}
