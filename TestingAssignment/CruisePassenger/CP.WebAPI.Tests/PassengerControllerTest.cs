using CP.WebAPI.Controllers;
using CP.WebAPI.Models;
using CP.WebAPI.Repository;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http.Results;
using Xunit;

namespace CP.WebAPI.Tests
{
    public class PassengerControllerTest
    {
        private readonly Mock<IDataRepository> mokDataRepo = new Mock<IDataRepository>();
        private readonly PassengerController _passengerController;

        public PassengerControllerTest()
        {
            _passengerController = new PassengerController(mokDataRepo.Object);
        }
        [Fact]
        public void Testing_GeAlltPassengers()
        {
            //Arrange
            var result = mokDataRepo.Setup(x => x.GetAllPassenger()).Returns(GetPassengers());
            
            //Act
            var response = _passengerController.Get();

            //Assert
            Assert.Equal(3, response.Count);
        }
        [Fact]
        public void Testing_GeAlltPassengers_NegativeWay()
        {
            //Arrange
            var result = mokDataRepo.Setup(x => x.GetAllPassenger()).Returns(GetPassengers());

            //Act
            var response = _passengerController.Get();

            //Assert
            Assert.NotEqual(5, response.Count);
        }


        [Fact]
        public void Testing_GetPassengerById()
        {
            //Arrange
            var passenger = new PassengerModel()
            {
                Id = 1,
                FirstName = "Nemish",
                LastName = "Sheth",
                ContactNumber = "9999999999"
            };
            var result = mokDataRepo.Setup(x => x.GetPassengerById(passenger.Id)).Returns(passenger);

            //Act
            var response = _passengerController.Get(passenger.Id);
            var isNull = Assert.IsType<OkNegotiatedContentResult<PassengerModel>>(response);

            //Assert
            Assert.NotNull(isNull);
        }

        [Fact]
        public void Testing_AddPAssenger()
        {
            //Arrange
            var newPassengerMustBe = new PassengerModel()
            {
                Id = 4,
                FirstName = "Ramesh",
                LastName = "Suresh",
                ContactNumber = "6666666666"
            };

            var newPassenger = new PassengerModel()
            {
                FirstName = "Ramesh",
                LastName = "Suresh",
                ContactNumber = "6666666666"
            };


            //Act
            var result = mokDataRepo.Setup(x => x.AddPassenger(newPassenger)).Returns(newPassengerMustBe);
            var response = _passengerController.Add(newPassenger);

            //Assert
            Assert.Equal(newPassengerMustBe, response);
        }

        [Fact]
        public void Testing_UpdatePasenger()
        {
            //Arrange
            var UpdatedPassenger = new PassengerModel()
            {
                Id = 1,
                FirstName = "Ramesh",
                LastName = "Suresh",
                ContactNumber = "6666666666"
            };


            //Act
            var result = mokDataRepo.Setup(x => x.UpdatePassenger(UpdatedPassenger)).Returns(UpdatedPassenger);
            var response = _passengerController.Put(UpdatedPassenger);

            //Assert
            Assert.Null(response);
        }

        [Fact]
        public void Tesing_DeletePassenger()
        {
            //Arrange
            int passengerId = 2;

            //Act
            var result = mokDataRepo.Setup(x => x.DeletePassenger(passengerId)).Returns(true);
            var response = _passengerController.Delete(passengerId);

            //Assert
            Assert.True(response);
        }




        private static List<PassengerModel> GetPassengers()
        {
            return new List<PassengerModel>()
            {
                new PassengerModel() { Id = 1, FirstName = "Nemish", LastName = "Sheth", ContactNumber = "9999999999" },
                new PassengerModel() { Id = 2, FirstName = "Naimish", LastName = "Sheth", ContactNumber = "8888888888" },
                new PassengerModel() { Id = 3, FirstName = "Namish", LastName = "Sheth", ContactNumber = "7777777777" }
            };
        }
    }
}
