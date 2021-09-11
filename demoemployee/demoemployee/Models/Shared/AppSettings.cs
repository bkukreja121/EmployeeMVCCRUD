using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoemployee.Models.Shared
{
    public class AppSettings
    {
        public static string ConnectionString()
        {
            return @"Data Source=IN-100N0F3;Initial Catalog=EmployeePayrollDB;Integrated Security=True";
        }
    }
}
