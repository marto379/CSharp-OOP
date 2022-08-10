namespace Aquariums.Tests
{

    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        public void FishConstructorShouldReturnTheNameRight()
        {
            Fish fish = new Fish("gosho");
            string actualName = fish.Name;
            string expectedName = "gosho";
            Assert.AreEqual(actualName, expectedName);
            Assert.That(fish.Available, Is.True);
        }

        [Test]

        public void AquariumCtorShouldReturnNameAndCapacity()
        {
            Aquarium aqua = new Aquarium("voda", 20);

            Assert.That(aqua.Name, Is.EqualTo("voda"));
            Assert.That(aqua.Capacity, Is.EqualTo(20));
        }

        [Test]
        public void AquaNameShouldReturnExceptionWhenIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
                {
                    Aquarium aqua = new Aquarium("", 5);
                }, "Invalid aquarium name!");
        }

        [Test]

        public void AquaNameShouldReturnExceptionWhenIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aqua = new Aquarium(null, 5);
            }, "Invalid aquarium name!");
        }

        [Test]
        public void ConstructorShouldCreateEmptyList()
        {
            Aquarium aquarium = new Aquarium("FishWorld", 10);
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]

        public void ShouldThrowExceptionWhenCapacityIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aqua = new Aquarium("test", -1);
            }, "Invalid aquarium capacity!");
        }

        [Test]
        public void AquariumCountShouldReturnCount()
        {
            Aquarium aqua = new Aquarium("voda", 20);
            Fish gosho = new Fish("gosho");
            Fish pesho = new Fish("pesho");

            aqua.Add(gosho);
            aqua.Add(pesho);

            Assert.That(aqua.Count, Is.EqualTo(2));
        }

        [Test]

        public void RemoveMethodShouldRemoveCurrentItem()
        {
            Aquarium aqua = new Aquarium("voda", 20);
            Fish gosho = new Fish("gosho");
            Fish pesho = new Fish("pesho");

            aqua.Add(gosho);
            aqua.Add(pesho);

            aqua.RemoveFish("gosho");

            Assert.That(aqua.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenNameDoesntExist()
        {
            Aquarium aqua = new Aquarium("voda", 20);
            Fish gosho = new Fish("gosho");
            Fish pesho = new Fish("pesho");
            var name = "pesho";

            aqua.Add(gosho);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aqua.RemoveFish(name);
            }, $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void SellFishMethodShouldSellCurrFish()
        {
            Aquarium aqua = new Aquarium("voda", 20);
            Fish gosho = new Fish("gosho");
            Fish pesho = new Fish("pesho");
            Fish test = new Fish("pesho");

            aqua.Add(gosho);
            aqua.Add(pesho);

            aqua.SellFish("pesho");
            pesho.Available = false;

            Assert.That(pesho.Available, Is.False);
        }

        [Test]
        public void SellFishMethodShouldSThrowExceptionWhenNoFish()
        {
            Aquarium aqua = new Aquarium("voda", 20);
            Fish gosho = new Fish("gosho");
            Fish pesho = new Fish("pesho");
            var name = "pesho";

            aqua.Add(gosho);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aqua.RemoveFish(name);
            }, $"Fish with the name {name} doesn't exist!");
        }
        [Test]
        public void ReportShouldReturnValidString()
        {
            Aquarium aqua = new Aquarium("voda", 20);
            Fish gosho = new Fish("gosho");
            Fish pesho = new Fish("pesho");


            aqua.Add(gosho);
            aqua.Add(pesho);
            string repoActual = aqua.Report();
            string expected = "Fish available at voda: gosho, pesho";
            Assert.AreEqual(expected, repoActual);
        }
        [Test]
        public void SellFishShouldReturnTheRequestedFish()
        {
            Aquarium aquarium = new Aquarium("FishWorld", 3);
            aquarium.Add(new Fish("Dory"));
            aquarium.Add(new Fish("Nemo"));
            aquarium.Add(new Fish("Melvin"));

            Fish requestedFish = aquarium.SellFish("Nemo");

            Assert.AreEqual("Nemo", requestedFish.Name);
        }

    }
}
