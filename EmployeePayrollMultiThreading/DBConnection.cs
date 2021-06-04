using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollMultiThreading
{
    public class DBConnection
    {
        public SqlConnection GetConnection()
        {

            //Specifying the connection string from the sql server connection
            string connectionString = @"Data Source=BISHAL\SQLBISHAL;Initial Catalog=payroll_service;Persist Security Info=True;User ID=sa;Password=9439433808";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
