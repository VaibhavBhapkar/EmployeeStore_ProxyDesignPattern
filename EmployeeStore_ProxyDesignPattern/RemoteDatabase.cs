using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeStore_ProxyDesignPattern
{
    public class RemoteDatabase:ICache
    {
        private Dictionary<int, string> Configuration;
        public RemoteDatabase()
        {
            Configuration = new Dictionary<int, string>();
            SetConfiguration();
        }
        public string GetEmployeeValue(int key)
        {
            if (Configuration.ContainsKey(key))
            {
                Console.WriteLine($"RemoteDatabase<GetValue>: [FETCH]  EmployeeId: {key}, EmployeeName: {Configuration[key]}");
                return Configuration[key];
            }
            else
            {
                return string.Empty;
            }
        }
        public void SetEmployeeValue(int key, string value)
        {
            if (Configuration.ContainsKey(key))
            {
                Console.WriteLine($"RemoteDatabase<SetValue> [UPDATED]: EmployeeId: {key}, EmployeeName: {Configuration[key]}");
                Configuration[key] = value;
            }
            else
            {
                Configuration.Add(key, value);
                Console.WriteLine($"RemoteDatabase<SetValue> [ADDED]: EmployeeId: {key}, EmployeeName: {Configuration[key]}");
            }
        }
        private void SetConfiguration()
        {
            Configuration.Add(1,"Vaibhav");
        }
    }
}
