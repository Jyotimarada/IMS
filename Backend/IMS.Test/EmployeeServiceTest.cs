using AutoMapper;
using IMS.Application.DTO;
using IMS.Application.Repositories;
using IMS.Application.Services;
using IMS.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;

namespace IMS.Test1
{
    [TestClass]
    public class EmployeeServiceTest
    {

        private EmployeeService _employeeService;
        private Mock<IEmployeeRepository> _repositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<ILogger<EmployeeService>> _loggerMock;
        private Mock<IMapper> _mapperMock;
        CancellationToken cancellationToken = new CancellationToken();

        public EmployeeServiceTest()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _loggerMock = new Mock<ILogger<EmployeeService>>();
            _mapperMock = new Mock<IMapper>();

            _employeeService = new EmployeeService(_loggerMock.Object, _repositoryMock.Object, _unitOfWorkMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public async Task AddEmployee_ShouldCallRepositoryCreateAndUnitOfWorkSave()
        {
            // Arrange
            var employee = new EmployeeDTO();

            // Act
            await _employeeService.AddEmployee(employee, cancellationToken);

            // Assert
            _repositoryMock.Verify(r => r.Create(It.IsAny<Employee>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.Save(cancellationToken), Times.Once);
        }

        [TestMethod]
        public async Task AddEmployee_ShouldCreateEmployeeAndSaveChanges()
        {
            // Arrange
            var employeeDTO = new EmployeeDTO
            {
                FirstName = "Jyoti",
                LastName = "Marada"
            };

            _mapperMock.Setup(m => m.Map<Employee>(employeeDTO)).Returns(new Employee());

            // Act
            await _employeeService.AddEmployee(employeeDTO, cancellationToken);

            // Assert
            _repositoryMock.Verify(r => r.Create(It.IsAny<Employee>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.Save(cancellationToken), Times.Once);
        }

        [TestMethod]
        public async Task AddEmployee_ShouldThrowException_WhenEmployeeIsNull()
        {

            var service = new EmployeeService(_loggerMock.Object, _repositoryMock.Object, _unitOfWorkMock.Object, _mapperMock.Object);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => service.AddEmployee(null, CancellationToken.None));
        }
    }
}