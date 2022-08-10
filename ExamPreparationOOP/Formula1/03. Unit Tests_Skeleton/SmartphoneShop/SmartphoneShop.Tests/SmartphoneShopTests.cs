using NUnit.Framework;
using System;
using System.Linq;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        //private Shop shop;
        //[SetUp]
        //public void SetUp()
        //{
        //    shop = new Shop(10);
        //}


        [Test]

        public void ConstructorShouldReturnCapacity()
        {
            var capacity = 5;

            Shop shop = new Shop(capacity);

            Assert.AreEqual(capacity, shop.Capacity);
        }
        [Test]
        public void ShopShoulReturnExeptionWhenCapacityIsAboveZere()
        {
            var capacity = -1;

            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(capacity);
            }, "Invalid capacity.");


        }
        [Test]

        public void ShopCountShouldReturnAccurateCount()
        {
            Smartphone smart1 = new Smartphone("test1", 50);
            Smartphone smart2 = new Smartphone("test2", 100);

            Shop shop = new Shop(2);
            shop.Add(smart1);
            shop.Add(smart2);

            Assert.That(shop.Count, Is.EqualTo(2));
        }
        [Test]
        public void AddShouldReturnExceptionWhenCapacityIsFull()
        {
            Smartphone smart1 = new Smartphone("test1", 50);
            Smartphone smart2 = new Smartphone("test2", 100);

            Shop shop = new Shop(1);
            shop.Add(smart1);


            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smart2);
            }, "The shop is full.");
        }

        [Test]
        public void AddShouldReturnExceptionWhenThePhoneExist()
        {
            Smartphone smart1 = new Smartphone("test1", 50);
            Smartphone smart2 = new Smartphone("test2", 100);
            Smartphone smart3 = new Smartphone("test1", 50);
            var modelName = smart1.ModelName;
            Shop shop = new Shop(3);
            shop.Add(smart1);


            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smart3);
            }, $"The phone model {modelName} already exist.");
        }
        [Test]
        public void ShopRemoveShouldRemoveThisPhone()
        {
            Smartphone smart1 = new Smartphone("test1", 50);
            Smartphone smart2 = new Smartphone("test2", 100);
            Smartphone smart3 = new Smartphone("test1", 50);

            Shop shop = new Shop(3);
            shop.Add(smart1);
            shop.Add(smart2);

            shop.Remove("test1");

            Assert.That(shop.Count == 1);
            Assert.That(smart2.ModelName, Is.EqualTo("test2"));
        }
        [Test]
        public void ShopRemoveShouldReturnExceptionWhenPhoneIsMissing()
        {
            Smartphone smart1 = new Smartphone("test1",100);
            Smartphone smart2 = new Smartphone("test2", 100);
            Smartphone smart3 = new Smartphone("test1", 50);

            Shop shop = new Shop(10);
            shop.Add(smart2);
            shop.Add(smart3);

            string name = "noname";
            Smartphone currPhone = new Smartphone(name, 10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove(name);
            }, ($"The phone model {name} doesn't exist."));
        }

        [Test]
        public void TestPhoneShouldThrowExceptionWhenPhoneIsMissing()
        {
            Smartphone smart1 = new Smartphone("test1", 100);
            Smartphone smart2 = new Smartphone("test2", 100);
            Smartphone smart3 = new Smartphone("test1", 50);

            Shop shop = new Shop(10);
            shop.Add(smart2);
            shop.Add(smart3);

            string name = "noname";
            Smartphone currPhone = new Smartphone(name, 10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(name,10);
            }, ($"The phone model {name} doesn't exist."));
        }
        [Test]
        public void TestPhoneShouldThrowExceptionWhenBatteryIsLow()
        {
            Smartphone smart1 = new Smartphone("test1", 90);
            Smartphone smart2 = new Smartphone("test2", 100);
            Smartphone smart3 = new Smartphone("test1", 50);

            Shop shop = new Shop(10);
            shop.Add(smart2);
            shop.Add(smart3);

            
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("test1", 91);
            }, $"The phone model {smart1.ModelName} is low on batery."); 
        }
        [Test]
        public void TestPhoneShouldDecreaseBatteryUssage()
        {
            Smartphone smart1 = new Smartphone("test1", 100);
            Smartphone smart2 = new Smartphone("test2", 100);
            Smartphone smart3 = new Smartphone("test3", 50);

            Shop shop = new Shop(10);
            shop.Add(smart1);
            shop.Add(smart2);
            shop.Add(smart3);

            shop.TestPhone("test1", 10);

            Assert.That(smart1.CurrentBateryCharge, Is.EqualTo(90));
        }
        [Test]
        public void ChargePhoneMethodShouldChargePhoneToMaximumCharge()
        {
            var shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Apple", 100);

            shop.Add(smartphone);
            shop.TestPhone("Apple", 40);

            Assert.AreEqual(60, smartphone.CurrentBateryCharge);

            shop.ChargePhone("Apple");

            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
        }
        [Test]
        public void ChargePhoneShouldThrowExceptionWhenPhoneIsMissing()
        {
            Smartphone smart1 = new Smartphone("test1", 100);
            Smartphone smart2 = new Smartphone("test2", 100);
            Smartphone smart3 = new Smartphone("test1", 50);

            Shop shop = new Shop(10);
            shop.Add(smart2);
            shop.Add(smart3);

            string name = "noname";
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone(name);
            }, ($"The phone model {name} doesn't exist."));
        }
    }
}