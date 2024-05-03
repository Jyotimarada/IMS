using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class EmployeesControllerTests
    {
        public EmployeesControllerTests()
    {
        // Initialize your mock service and controller here
        _mockEmployeeService = new Mock<EmployeeService>();
        _controller = new EmployeesController(_mockEmployeeService.Object);
    }

        [TestMethod]
         public async Task GetEmployees_ReturnsListOfEmployees()
    {
        // Arrange
        _mockEmployeeService.Setup(service => service.SearchByName(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<EmployeeDTO>());

        // Act
        var result = await _controller.GetEmployees(null, CancellationToken.None);

        // Assert
        Assert.IsInstanceOf<IEnumerable<EmployeeDTO>>(result);
    }
    }
}
