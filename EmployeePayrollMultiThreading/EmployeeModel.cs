using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollMultiThreading
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public double BasicPay { get; set; }
        public double Deductions { get; set; }
        public double TaxablePay { get; set; }
        public double Tax { get; set; }
        public double NetPay { get; set; }
        public DateTime StartDate { get; set; }
        public EmployeeModel(string employeeName, DateTime startDate, long phoneNumber, string address, string department, string gender, double basicPay, double deductions, double taxablePay, double tax, double netPay)
        {
            this.EmployeeName = employeeName;
            this.StartDate = startDate;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Department = department;
            this.Gender = gender;
            this.BasicPay = basicPay;
            this.Deductions = deductions;
            this.TaxablePay = taxablePay;
            this.Tax = tax;
            this.NetPay = netPay;
        }
    }
}
