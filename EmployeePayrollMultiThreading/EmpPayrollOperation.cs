using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollMultiThreading
{
    public class EmpPayrollOperation
    {

        /// Ensuring the established connection using the Sql Connection specifying the property.
        public static SqlConnection connection { get; set; }

        /// UC1 Adding the multiple employees record to data base without the threads.

        public bool AddEmployeeListToDataBase(List<EmployeeModel> employeeList)
        {
            foreach (var employee in employeeList)
            {
                Console.WriteLine("Employeee being added :", employee.EmployeeName);
                bool flag = AddEmployeeToDataBase(employee);
                Console.WriteLine("Employee Added :", employee.EmployeeName);
                if (flag == false)
                    return false;
            }
            return true;
        }

        /// Adding Employee To Database

        public bool AddEmployeeToDataBase(EmployeeModel emp)
        { /// Creates a new connection for every method to avoid "ConnectionString property not initialized" exception
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            try
            {
                using (connection)
                {
                    //Creating a stored Procedure for adding employees into database
                    SqlCommand command = new SqlCommand("dbo.SpAddEmployeeDetails", connection);
                    //Command type is set as stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    //Adding values from employeemodel to stored procedure using disconnected architecture
                    //connected architecture will only read the data
                    command.Parameters.AddWithValue("@EmpName", emp.EmployeeName);
                    command.Parameters.AddWithValue("@basic_Pay", emp.BasicPay);
                    command.Parameters.AddWithValue("@StartDate", emp.StartDate);
                    command.Parameters.AddWithValue("@gender", emp.Gender);
                    command.Parameters.AddWithValue("@phoneNumber", emp.PhoneNumber);
                    command.Parameters.AddWithValue("@department", emp.Department);
                    command.Parameters.AddWithValue("@address", emp.Address);
                    command.Parameters.AddWithValue("@deductions", emp.Deductions);
                    command.Parameters.AddWithValue("@taxable_pay", emp.TaxablePay);
                    command.Parameters.AddWithValue("@income_tax", emp.Tax);
                    command.Parameters.AddWithValue("@net_pay", emp.NetPay);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
