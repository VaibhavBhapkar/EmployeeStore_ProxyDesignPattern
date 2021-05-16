using System;

namespace EmployeeStore_ProxyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ICache cache = new CacheProxy();
            Console.WriteLine($"User: {cache.GetEmployeeValue(1)}");
            Console.WriteLine();           
            cache.SetEmployeeValue(2, "VB");
            Console.WriteLine($"User: {cache.GetEmployeeValue(2)}");
            Console.WriteLine();            
        }
    }
}
