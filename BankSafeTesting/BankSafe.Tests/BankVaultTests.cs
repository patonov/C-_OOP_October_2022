using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_WorksProperly()
        {
            BankVault bankVault = new BankVault();
            Assert.That(bankVault, Is.Not.Null);
            Assert.That(bankVault.VaultCells.Count, Is.EqualTo(12));
        }

        [Test]
        public void Ctor_CreatesDictionaryOfVaultCellsOfItemType()
        {
            BankVault bankVault = new BankVault();

            bankVault.AddItem("A1", new Item("Nikolay", "033K"));

            var typeOfCell = bankVault.VaultCells["A1"].GetType().Name;

            Assert.That(typeOfCell, Is.EqualTo("Item"));
            Assert.That(bankVault.VaultCells.Count, Is.EqualTo(12));
        }

        [Test]
        public void AddItem_WorksProperly()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Nikolay", "033K");

            bankVault.AddItem("A1", item);

            var result = bankVault.VaultCells["A1"];
            Assert.That(result, Is.EqualTo(item));
        }

        [Test]
        public void AddItem_ThrowsArgumentException_WhenKeyDoesNotExist()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Nikolay", "033K");

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("D33", item), "Cell doesn't exists!");
        }

        [Test]
        public void AddItem_ThrowsArgumentException_WhenCellIsAlreadyTaken()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Nikolay", "033K");
            Item item2 = new Item("Pesho", "044K");

            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", item2), "Cell is already taken!");
        }

        [Test]
        public void AddItem_ThrowsInvalidOperationException_WhenItemIsAlreadyPut()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Nikolay", "033K");
            
            bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item), "Cell is already taken!");
        }

        [Test]
        public void RemoveItem_WorksProperly()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Nikolay", "033K");

            bankVault.AddItem("A1", item);

            Assert.That(bankVault.RemoveItem("A1", item), Is.EqualTo("Remove item:033K successfully!"));
            Assert.That(bankVault.VaultCells["A1"], Is.Null);
        }

        [Test]
        public void RemoveItem_ThrowsArgumentExcepttion_WhenCellDoesNotExist()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Nikolay", "033K");

            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(()=> bankVault.RemoveItem("J16", item), "Cell doesn't exists!");           
        }

        [Test]
        public void RemoveItem_ThrowsArgumentExcepttion_WhenItemDoesNotExistInTheSellPointedOut()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Nikolay", "033K");
            Item item2 = new Item("Pesho", "044K");

            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", item2), "Item in that cell doesn't exists!");
        }



    }
}