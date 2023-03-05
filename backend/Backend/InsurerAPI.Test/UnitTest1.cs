using API.Controllers;
using Backend.Shared;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InsurerAPI.Test
{
    public class InsurersControllerTests
    {
        [Fact]
        public async void GetInsurers_ListOfInsurers()
        {
            //Arrange 
            var mockRepository = new Mock<IInsurerRepository>();

            var insurers = new List<Insurer>
            {
                new Insurer{Id=1, Name="Aseguradora Humano", Commission=10.24M, IsApproved=true},
                new Insurer{Id=2, Name="Aseguradora Universal", Commission=24.99M, IsApproved=true}
            };

            mockRepository.Setup(x => x.RetrieveAllAsync()).ReturnsAsync(insurers);
            var mockValidator = new Mock<IValidator<Insurer>>();

            mockValidator.Setup(x => x.ValidateAsync(It.IsAny<ValidationContext<Insurer>>(), default))
                .ReturnsAsync(new ValidationResult());

            var controller = new InsurersController(mockRepository.Object, mockValidator.Object);

            //Act
            var result = await controller.GetInsurers();

            //Assert 
            var okObjectResult = Assert.IsType<List<Insurer>>(result);
           
            Assert.Equal(2, okObjectResult.Count);




        }

        [Fact]
        public async void GetInsurerById_ReturnsOkObjectResult_WithInsurer()
        {
            //Arrange
            int id = 1; 
            var mockRepository = new Mock<IInsurerRepository>();
            var insurer = new Insurer { Id=id, Name="Aseguradora Ramos", Commission=24.99M, IsApproved=true };

            mockRepository.Setup(x => x.RetrieveAsyncById(id)).ReturnsAsync(insurer);

            var mockValidator = new Mock<IValidator<Insurer>>();

            mockValidator.Setup(x => x.ValidateAsync(It.IsAny<ValidationContext<Insurer>>(), default))
                .ReturnsAsync(new ValidationResult());

            var controller = new InsurersController(mockRepository.Object, mockValidator.Object);

            //Act 
            var result = await controller.GetInsurerById(id);

            //Assert 
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnedInsurer = Assert.IsType<Insurer>(okObjectResult.Value);
            Assert.Equal(id, returnedInsurer.Id); 

        }



    }
}