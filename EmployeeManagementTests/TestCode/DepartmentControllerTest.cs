using EmployeeManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementTests.TestCode
{
    public class DepartmentControllerTest
    {
        [Fact]
        public void TestList() 
        {
            //Arrange
            var controller = new DepartmentsController();

            //Act
            var result = controller.List();

            //Assert
            Assert.Equal("List() of DepartmentsController", result);
        }
        [Fact]
        public void TestDetails()
        {
            //Arrange
            var controller = new DepartmentsController();

            //Act
            var result = controller.Details();

            //Assert
            Assert.Equal("Details() of DepartmentsController", result);
        }
    }
}
