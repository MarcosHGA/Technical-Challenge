using api.Controllers;
using Dtos;
using Entitys;
using Infra.Util;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Services;
using System.Collections.Generic;

namespace UnitTest
{
    public class Tests
    {
        private readonly Mock<IDivisorService> _divisorControllerMock = new Mock<IDivisorService>();

        private readonly DivisorController _divisorController;

        public Tests()
        {
            _divisorController = new DivisorController(_divisorControllerMock.Object);
        }

        [Test]
        public void Get_ShouldReturnDivisorApi_Success()
        {
            //Arrange
            List<int> list = new List<int> { 1, 2, 5, 10 };

            DivisorDto expectedDivisorDto = new DivisorDto
            {
                Divisors = list,
                Error = string.Empty,
                Ok = true
            };

            //Mock
            _divisorControllerMock.Setup(m => m.CalcDivisor(It.IsAny<DivisorEntity>())).Returns(expectedDivisorDto);

            var result = _divisorController.Get(10, false);

            var request = result.Result as OkObjectResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedDivisorDto.Error, string.Empty);
            Assert.AreEqual(200, request.StatusCode);
        }

        [Test]
        public void Get_ShouldReturnDivisorApi_Fail()
        {
            //Arrange
            DivisorDto expectedDivisorDto = new DivisorDto
            {
                Error = "Error",
                Ok = false
            };

            //Mock
            _divisorControllerMock.Setup(m => m.CalcDivisor(It.IsAny<DivisorEntity>())).Returns(expectedDivisorDto);

            //Act
            var result = _divisorController.Get(10, false);

            var badRequest = result.Result as BadRequestObjectResult;

            //Assert
            Assert.IsNotNull(badRequest);
            Assert.AreEqual(expectedDivisorDto.Error, badRequest.Value);
            Assert.AreEqual(400, badRequest.StatusCode);
        }

        [Test]
        public void CalcDivisor_ShouldReturnDivisors()
        {
            //Arrange
            DivisorService divisorService = new DivisorService();
            DivisorEntity divisor = new DivisorEntity
            {
                Number = 10,
                Prime = false
            };

            List<int> expectedList = new List<int> { 1, 2, 5, 10 };

            //Act
            DivisorDto result = divisorService.CalcDivisor(divisor);

            //Assert
            Assert.IsTrue(result.Ok);
            Assert.IsNull(result.Error);
            Assert.AreEqual(expectedList, result.Divisors);
        }

        [Test]
        public void CalcDivisor_ShouldReturnPrimeDivisors()
        {
            //Arrange
            DivisorService divisorService = new DivisorService();
            DivisorEntity divisor = new DivisorEntity
            {
                Number = 10, 
                Prime = true
            };

            List<int> expectedList = new List<int> { 2, 5 };

            //Act
            DivisorDto result = divisorService.CalcDivisor(divisor);

            //Assert
            Assert.IsTrue(result.Ok);
            Assert.IsNull(result.Error);
            Assert.AreEqual(expectedList, result.Divisors);
        }

        [Test]
        public void CheckPrime_ShouldReturnFalse()
        {
            //Act
            var result = Util.CheckPrime(4);

            //Assert
            Assert.IsFalse(result);
        }
        
        [Test]
        public void CheckPrime_ShouldReturnTrue()
        {
            //Act
            var result = Util.CheckPrime(3);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckDivisor_ShouldReturnFalse()
        {
            //Act
            var result = Util.CheckDivisor(10, 3);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckDivisor_ShouldReturnTrue()
        {
            //Act
            var result = Util.CheckDivisor(10, 2);

            //Assert
            Assert.IsTrue(result);
        }
    }
}