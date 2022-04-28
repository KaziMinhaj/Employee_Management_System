using EmployeeManagement.Controllers;
using EmployeeManagement.Models;
using EmployeeManagement.Security;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagementTests.TestCode
{
    public class HomeControllerTest
    {
        private readonly HomeController controlller;
        private readonly Mock<IEmployeeRepository> _employeeRepository = new Mock<IEmployeeRepository>();
        private readonly Mock<IWebHostEnvironment> _hostingEnvironment = new Mock<IWebHostEnvironment>();
        private readonly Mock<ILogger<HomeController>> _loggerMock = new Mock<ILogger<HomeController>>();
        private readonly Mock<IDataProtectionProvider> _dataProtectionProvider = new Mock<IDataProtectionProvider>();
        private readonly Mock<DataProtectionPurposeStrings> _dataProtectionPurposeStrings = new Mock<DataProtectionPurposeStrings>();

        public HomeControllerTest()
        {
            controlller = new HomeController(_employeeRepository.Object,
                                      _hostingEnvironment.Object,
                                      _loggerMock.Object,
                                      _dataProtectionProvider.Object,
                                      _dataProtectionPurposeStrings.Object);
        }

        [Fact]
        public void TestIndex_Should_Not_Return_Null()
        {
            //Act
            var actualResult = controlller.Index();

            //Assert
            Assert.NotNull(actualResult);
        }

        [Fact]
        public void TestIndex_Should_Return_Employee_List() 
        {
            //Act
            var actualResult = controlller.Index();
            var expectedResult = new List<Employee>();

            //Assert
            Assert.Equal(expectedResult, actualResult.Model);
        }

        
        [Fact]
        public void TestDelete_Should_Not_Return_Null()
        {
            //Arrange
            var id = 1;
            _employeeRepository.Setup(x => x.Delete(id));

            //Act
            var result = controlller.Delete(id);
            
            //Assert
            Assert.NotNull(result);

            //check the method is called
            //_employeeRepository.Verify(x => x.Delete(id),Times.Once);
            

        }

        [Fact]
        public void TestDelete_Should_Return_Action_Name()
        {
            //Arrange
            var id = 1;
            _employeeRepository.Setup(x => x.Delete(id));

            //Act
            var result = controlller.Delete(id);
            var actualActionName = result.GetType().Name;
            var expectedActionName = "RedirectToActionResult";

            //Assert
            Assert.Equal(expectedActionName, actualActionName);

        }


        [Fact]
        public void TestCreate_Should_Not_Return_Null()
        {
            //Act
            var result = controlller.Create();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestEdit_Should_Not_Return_Null() 
        {
            int id = 1;
            _employeeRepository.Setup(x => x.GetEmployee(id)).Returns(new Employee());

            var result = controlller.Edit(id);

            Assert.NotNull(result);
        }

        [Fact]
        public void TestEdit_Should_Return_EmployeeEditViewModel()
        {
            int id = 1;
            _employeeRepository.Setup(x => x.GetEmployee(id)).Returns(new Employee());

            var result = controlller.Edit(id);

            var model = result.Model;

            Assert.IsType<EmployeeEditViewModel>(model);
        }

        [Fact]
        public void TestDetails_Should_Not_Return_Null()
        {
            int id = 1;
            _employeeRepository.Setup(x => x.GetEmployee(id)).Returns(new Employee());

            //
            var result = controlller.Details(id.ToString());

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestDetails_Should_Return_ViewResult_Type()
        {
            //Arrange
            int id = 1;
            _employeeRepository.Setup(x => x.GetEmployee(id)).Returns(new Employee());

            //Act
            var result = controlller.Details(id.ToString());
            var actualType= result.GetType().Name;
            var expectedType = "ViewResult";

            //Assert
            Assert.Equal(expectedType, actualType);           
        }
    }
}