using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeStore_ProxyDesignPattern
{
    public class CacheProxy:ICache
    {
        private Dictionary<int, string> CachedConfiguration;
        private RemoteDatabase databaseCache;
        public CacheProxy()
        {
            CachedConfiguration = new Dictionary<int, string>();
            databaseCache = new RemoteDatabase();
        }
        public string GetEmployeeValue(int key)
        {
            if (CachedConfiguration.ContainsKey(key))
            {
                Console.WriteLine($"CacheProxy<GetValue>: [PROXY-FETCH]  EmployeeId: {key}, EmployeeName: {CachedConfiguration[key]}");
                return CachedConfiguration[key];
            }
            else
            {
                var value = databaseCache.GetEmployeeValue(key);
                if (!string.IsNullOrEmpty(value))
                {
                    CachedConfiguration.Add(key, value);
                    Console.WriteLine($"CacheProxy<GetValue>: [PROXY-UPDATED] EmployeeId: {key}, EmployeeName: {CachedConfiguration[key]}");
                    return value;
                }
                else
                    Console.WriteLine($"Invalid key: {key}");
            }
            return string.Empty;
        }
        public void SetEmployeeValue(int key, string value)
        {
            databaseCache.SetEmployeeValue(key, value);
            CachedConfiguration[key] = value;
            Console.WriteLine($"CacheProxy<SetValue>: [PROXY-UPDATED] EmployeeId: {key}, EmployeeName: {CachedConfiguration[key]}");
        }

    }
}
