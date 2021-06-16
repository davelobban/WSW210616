using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using WSW210616;

namespace WSW210616Test
{
    public class Tests
    {

        //BDD 
        //As a petrol station transaction
        //When it is between 2300 and 0700 local time
        //Then a 5% off peak discount is applied to the fuel.

        [Test]
        public void Test2300()
        {
            //Arrange the petrol station and the transaction
            var sut = new PetrolStation();
            var t = sut.NewTransaction();
            t.Add(new FuelLine(50.5m));
            //Act: 
            var actual = t.GetTotal(new DateTime(2021, 6, 16, 23, 00, 00));
            var expectedFuelCost = 50.5 * 1.25 * .95;
            //Assert
            Assert.AreEqual(expectedFuelCost, actual);
        }
        [Test]
        public void Test065959()
        {
            //Arrange the petrol station and the transaction
            var sut = new PetrolStation();
            var t = sut.NewTransaction();
            t.Add(new FuelLine(50.5m));
            //Act: 
            var actual = t.GetTotal(new DateTime(2021, 6, 16, 6, 59, 59));
            var expectedFuelCost = 50.5 * 1.25 * .95;
            //Assert
            Assert.AreEqual(expectedFuelCost, actual);
        }
        [Test]
        public void Test065959Tmrw()
        {
            //Arrange the petrol station and the transaction
            var sut = new PetrolStation();
            var t = sut.NewTransaction();
            t.Add(new FuelLine(50.5m));
            //Act: 
            var actual = t.GetTotal(new DateTime(2021, 6, 17, 6, 59, 59));
            var expectedFuelCost = 50.5 * 1.25 * .95;
            //Assert
            Assert.AreEqual(expectedFuelCost, actual);
        }

        [Test]
        public void Test225959()
        {
            //Arrange the petrol station and the transaction
            var sut = new PetrolStation();
            var t = sut.NewTransaction();
            t.Add(new FuelLine(50.5m));
            //Act: 
            var actual = t.GetTotal(new DateTime(2021, 6, 16, 22, 59, 59));
            var expectedFuelCost = 50.5 * 1.25;
            //Assert
            Assert.AreEqual(expectedFuelCost, actual);
        }
        [Test]
        public void Test0700()
        {
            //Arrange the petrol station and the transaction
            var sut = new PetrolStation();
            var t = sut.NewTransaction();
            t.Add(new FuelLine(50.5m));
            //Act: 
            var actual = t.GetTotal(new DateTime(2021, 6, 16, 07, 0, 0));
            var expectedFuelCost = 50.5 * 1.25;
            //Assert
            Assert.AreEqual(expectedFuelCost, actual);
        }


        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }

    
}