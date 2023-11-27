using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using reports = Reports_Builder.CRUD;

namespace reports_builder
{
    class Program
    {
        static void Main(string[] args)
        {
            reports.GetDailyReport("2023-01-03");
        }
    
   
    }

    //EOC
}