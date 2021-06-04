using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using EmployeePayrollMultiThreading;
using System;

namespace EmployeeMultithreadingTest
{
    [TestClass]
    public class UnitTest1
    {

        public static EmpPayrollOperation employeePayroll = new EmpPayrollOperation();

        /// TC1 To test for addition of multiple data to the list without using the multi-thread

        [TestMethod]
        public void GivenListOfEmployeesMatchTheEntriesWithoutThreading()
        {
            //Arrange
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            employeeList.Add(new EmployeeModel(employeeName: "Prateek", startDate: new System.DateTime(2019, 08, 01), phoneNumber: 9439877858, address: "Bangalore", department: "Sales", gender: "M", basicPay: 50000, deductions: 2000, taxablePay: 48000, tax: 1000, netPay: 47000));
            employeeList.Add(new EmployeeModel(employeeName: "Shailesh", startDate: new System.DateTime(2021, 01, 01), phoneNumber: 4563784678, address: "Chennai", department: "Marketing", gender: "M", basicPay: 50000, deductions: 2000, taxablePay: 48000, tax: 1000, netPay: 47000));
            employeeList.Add(new EmployeeModel(employeeName: "Niraj", startDate: new System.DateTime(2019, 02, 01), phoneNumber: 7865678765, address: "Mumbai", department: "Hr", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            employeeList.Add(new EmployeeModel(employeeName: "Prabhat", startDate: new System.DateTime(2020, 02, 01), phoneNumber: 3456765434, address: "Delhi", department: "Marketing", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            employeeList.Add(new EmployeeModel(employeeName: "Bishal", startDate: new System.DateTime(2021, 04, 12), phoneNumber: 4567898754, address: "Bangalore", department: "Hr", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            bool expected = true;
            Stopwatch stopwatch = new Stopwatch();

            //Act
            stopwatch.Start();
            bool actual = employeePayroll.AddEmployeeListToDataBase(employeeList);
            stopwatch.Stop();
            Console.WriteLine("Elapsed time: " + stopwatch.ElapsedMilliseconds);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        /// TC2 To test for addition of multiple data to the list using the multi-threading concept

        [TestMethod]
        public void GivenEmployeeList_AddEmployeeListToDatabaseUsingThreads()
        {
            //Arrange
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            employeeList.Add(new EmployeeModel(employeeName: "Prateek", startDate: new System.DateTime(2019, 08, 01), phoneNumber: 9439877858, address: "Bangalore", department: "Sales", gender: "M", basicPay: 50000, deductions: 2000, taxablePay: 48000, tax: 1000, netPay: 47000));
            employeeList.Add(new EmployeeModel(employeeName: "Shailesh", startDate: new System.DateTime(2021, 01, 01), phoneNumber: 4563784678, address: "Chennai", department: "Marketing", gender: "M", basicPay: 50000, deductions: 2000, taxablePay: 48000, tax: 1000, netPay: 47000));
            employeeList.Add(new EmployeeModel(employeeName: "Niraj", startDate: new System.DateTime(2019, 02, 01), phoneNumber: 7865678765, address: "Mumbai", department: "Hr", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            employeeList.Add(new EmployeeModel(employeeName: "Prabhat", startDate: new System.DateTime(2020, 02, 01), phoneNumber: 3456765434, address: "Delhi", department: "Marketing", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            employeeList.Add(new EmployeeModel(employeeName: "Bishal", startDate: new System.DateTime(2021, 04, 12), phoneNumber: 4567898754, address: "Bangalore", department: "Hr", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            Stopwatch stopwatch = new Stopwatch();

            //Act
            stopwatch.Start();
            employeePayroll.AddEmployeeListToEmployeePayrollDataBaseWithThread(employeeList);
            stopwatch.Stop();
            Console.WriteLine("Elapsed time using the threads: " + stopwatch.ElapsedMilliseconds);
        }

        ///  TC3 To test for addition of multiple data to the list using the multi-threading concept with thread synchronization

        [TestMethod]
        public void AddingMultipleDataWithSynchronizedThreads_GettingTimeOfExecution()
        {
            //Arrange
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            employeeList.Add(new EmployeeModel(employeeName: "Prateek", startDate: new System.DateTime(2019, 08, 01), phoneNumber: 9439877858, address: "Bangalore", department: "Sales", gender: "M", basicPay: 50000, deductions: 2000, taxablePay: 48000, tax: 1000, netPay: 47000));
            employeeList.Add(new EmployeeModel(employeeName: "Shailesh", startDate: new System.DateTime(2021, 01, 01), phoneNumber: 4563784678, address: "Chennai", department: "Marketing", gender: "M", basicPay: 50000, deductions: 2000, taxablePay: 48000, tax: 1000, netPay: 47000));
            employeeList.Add(new EmployeeModel(employeeName: "Niraj", startDate: new System.DateTime(2019, 02, 01), phoneNumber: 7865678765, address: "Mumbai", department: "Hr", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            employeeList.Add(new EmployeeModel(employeeName: "Prabhat", startDate: new System.DateTime(2020, 02, 01), phoneNumber: 3456765434, address: "Delhi", department: "Marketing", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            employeeList.Add(new EmployeeModel(employeeName: "Bishal", startDate: new System.DateTime(2021, 04, 12), phoneNumber: 4567898754, address: "Bangalore", department: "Hr", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            Stopwatch stopwatch = new Stopwatch();

            //Act
            stopwatch.Start();
            employeePayroll.AddEmployeeListToDataBaseWithThreadSynchronization(employeeList);
            stopwatch.Stop();
            Console.WriteLine("Elapsed time using the threads: " + stopwatch.ElapsedMilliseconds);
        }
    }
}

