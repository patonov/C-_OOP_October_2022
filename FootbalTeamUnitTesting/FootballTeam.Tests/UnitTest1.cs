using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_WorksProperly()
        {
            FootballTeam team = new FootballTeam("Belasitsa", 22);

            Assert.That(team, Is.Not.Null);
            Assert.That(team.Name, Is.EqualTo("Belasitsa"));
            Assert.That(team.Capacity, Is.EqualTo(22));
            Assert.That(team.Players.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_ThrowsArgumentException_WhenNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(()=> new FootballTeam(null, 22), "Name cannot be null or empty!");
            Assert.Throws<ArgumentException>(() => new FootballTeam("", 22), "Name cannot be null or empty!");
        }

        [Test]
        public void Ctor_ThrowsArgumentException_WhenCapacityIsLessThan15()
        {
            Assert.Throws<ArgumentException>(() => new FootballTeam("Belasitsa", 10), "Capacity min value = 15");           
        }

        [Test]
        public void AddNewPlayer_WorksProperly()
        {
            FootballTeam team = new FootballTeam("Belasitsa", 15);
            FootballPlayer player = new FootballPlayer("Petko", 1, "Goalkeeper");

            Assert.That(team.AddNewPlayer(player), Is.EqualTo("Added player Petko in position Goalkeeper with number 1"));
            Assert.That(team.Players.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddNewPlayer_DoesNotAddMorePlayers_WhenCapacityIsFull()
        {
            FootballTeam team = new FootballTeam("Belasitsa", 15);
            FootballPlayer player1 = new FootballPlayer("Petko", 1, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Mitko", 2, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Ivan", 3, "Goalkeeper");
            FootballPlayer player4 = new FootballPlayer("Yanko", 4, "Midfielder");
            FootballPlayer player5 = new FootballPlayer("DrugYanko", 5, "Midfielder");
            FootballPlayer player6 = new FootballPlayer("BaiHui", 6, "Midfielder");
            FootballPlayer player7 = new FootballPlayer("PakAz", 7, "Midfielder");
            FootballPlayer player8 = new FootballPlayer("Murjo", 8, "Midfielder");
            FootballPlayer player9 = new FootballPlayer("Lechkov", 9, "Forward");
            FootballPlayer player10 = new FootballPlayer("PakPetko", 10, "Forward");
            FootballPlayer player11 = new FootballPlayer("GolemaTupnq", 11, "Forward");
            FootballPlayer player12 = new FootballPlayer("Dimitrichko", 12, "Forward");
            FootballPlayer player13 = new FootballPlayer("Gogi", 13, "Forward");
            FootballPlayer player14 = new FootballPlayer("Ylian", 14, "Forward");
            FootballPlayer player15 = new FootballPlayer("PosledenMajna", 15, "Forward");
            
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);
            team.AddNewPlayer(player4);
            team.AddNewPlayer(player5);
            team.AddNewPlayer(player6);
            team.AddNewPlayer(player7);
            team.AddNewPlayer(player8);
            team.AddNewPlayer(player9);
            team.AddNewPlayer(player10);
            team.AddNewPlayer(player11);
            team.AddNewPlayer(player12);
            team.AddNewPlayer(player13);
            team.AddNewPlayer(player14);
            team.AddNewPlayer(player15);

            FootballPlayer playerNew = new FootballPlayer("Gazar", 16, "Forward");

            Assert.That(team.AddNewPlayer(playerNew), Is.EqualTo("No more positions available!"));
            Assert.That(team.Players.Count, Is.EqualTo(15));
        }

        [Test]
        public void PickPlayer_WorksProperly()
        {
            FootballTeam team = new FootballTeam("Belasitsa", 15);
            FootballPlayer player1 = new FootballPlayer("Petko", 1, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Mitko", 2, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Ivan", 3, "Goalkeeper");
            FootballPlayer player4 = new FootballPlayer("Yanko", 4, "Midfielder");
            FootballPlayer player5 = new FootballPlayer("DrugYanko", 5, "Midfielder");
            FootballPlayer player6 = new FootballPlayer("BaiHui", 6, "Midfielder");
            FootballPlayer player7 = new FootballPlayer("PakAz", 7, "Midfielder");
            FootballPlayer player8 = new FootballPlayer("Murjo", 8, "Midfielder");
            FootballPlayer player9 = new FootballPlayer("Lechkov", 9, "Forward");
            FootballPlayer player10 = new FootballPlayer("PakPetko", 10, "Forward");
            FootballPlayer player11 = new FootballPlayer("GolemaTupnq", 11, "Forward");
            FootballPlayer player12 = new FootballPlayer("Dimitrichko", 12, "Forward");
            FootballPlayer player13 = new FootballPlayer("Gogi", 13, "Forward");
            FootballPlayer player14 = new FootballPlayer("Ylian", 14, "Forward");
            FootballPlayer player15 = new FootballPlayer("PosledenMajna", 15, "Forward");

            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);
            team.AddNewPlayer(player4);
            team.AddNewPlayer(player5);
            team.AddNewPlayer(player6);
            team.AddNewPlayer(player7);
            team.AddNewPlayer(player8);
            team.AddNewPlayer(player9);
            team.AddNewPlayer(player10);
            team.AddNewPlayer(player11);
            team.AddNewPlayer(player12);
            team.AddNewPlayer(player13);
            team.AddNewPlayer(player14);
            team.AddNewPlayer(player15);

            Assert.That(team.PickPlayer("PosledenMajna"), Is.EqualTo(player15));
        }

        [Test]
        public void PlayerScore_WorksProperly()
        {
            FootballTeam team = new FootballTeam("Belasitsa", 15);
            FootballPlayer player1 = new FootballPlayer("Petko", 1, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Mitko", 2, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Ivan", 3, "Goalkeeper");
            FootballPlayer player4 = new FootballPlayer("Yanko", 4, "Midfielder");
            FootballPlayer player5 = new FootballPlayer("DrugYanko", 5, "Midfielder");
            FootballPlayer player6 = new FootballPlayer("BaiHui", 6, "Midfielder");
            FootballPlayer player7 = new FootballPlayer("PakAz", 7, "Midfielder");
            FootballPlayer player8 = new FootballPlayer("Murjo", 8, "Midfielder");
            FootballPlayer player9 = new FootballPlayer("Lechkov", 9, "Forward");
            FootballPlayer player10 = new FootballPlayer("PakPetko", 10, "Forward");
            FootballPlayer player11 = new FootballPlayer("GolemaTupnq", 11, "Forward");
            FootballPlayer player12 = new FootballPlayer("Dimitrichko", 12, "Forward");
            FootballPlayer player13 = new FootballPlayer("Gogi", 13, "Forward");
            FootballPlayer player14 = new FootballPlayer("Ylian", 14, "Forward");
            FootballPlayer player15 = new FootballPlayer("PosledenMajna", 15, "Forward");

            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);
            team.AddNewPlayer(player4);
            team.AddNewPlayer(player5);
            team.AddNewPlayer(player6);
            team.AddNewPlayer(player7);
            team.AddNewPlayer(player8);
            team.AddNewPlayer(player9);
            team.AddNewPlayer(player10);
            team.AddNewPlayer(player11);
            team.AddNewPlayer(player12);
            team.AddNewPlayer(player13);
            team.AddNewPlayer(player14);
            team.AddNewPlayer(player15);

            Assert.That(team.PlayerScore(15), Is.EqualTo("PosledenMajna scored and now has 1 for this season!"));
            Assert.That(player15.ScoredGoals, Is.EqualTo(1));
        }

    }
}