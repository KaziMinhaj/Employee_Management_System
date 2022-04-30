using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementTests.TestCode
{
    public class RepositoryTest
    {
        [Fact]
        public void TestGetEmployee()
        {
            //Arrange
            MockEmployeeRepository mockEmployeeRepository = new MockEmployeeRepository();

            //Act
            var result = mockEmployeeRepository.GetEmployee(1);
            var actualEmail = result.Email;
            var expectedEmail = "mary@g.bracu.ac.bd";

            //Assert
            Assert.Equal(expectedEmail,actualEmail);

        }

        [Fact]
        public void TestGetAllEmployee()
        {
            //Arrange
            MockEmployeeRepository mockEmployeeRepository = new MockEmployeeRepository();

            //Act
            var result = mockEmployeeRepository.GetAllEmployee();
            var actualLength = result.Count();
            var expectedLength = 3;

            //Assert
            Assert.True(actualLength == expectedLength);

        }

        [Fact]
        public void TestAddEmployee()
        {
            //Arrange
            Employee employee = new Employee()
            {
                Name = "Kazi",
                Id = 101,
                Email = "kazi@bracu.ac.bd",
                Department = Dept.IT
            };

            //Act
            MockEmployeeRepository mockEmployeeRepository = new MockEmployeeRepository();
            var result = mockEmployeeRepository.Add(employee);
            var actualEmail = result.Email;
            var expectedEmail= employee.Email;
            
            //Assert
            Assert.Equal(expectedEmail,actualEmail);

        }

        [Fact]
        public void TestUpdateEmployee()
        {
            //Arrange
            Employee employee = new Employee()

            { Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@g.bracu.ac.bd" };


            //Act
            MockEmployeeRepository mockEmployeeRepository = new MockEmployeeRepository();
            var result = mockEmployeeRepository.Update(employee);
            var actualEmail = result.Email;
            var expectedEmail = employee.Email;

            //Assert
            Assert.Equal(expectedEmail, actualEmail);

        }
    }
}
