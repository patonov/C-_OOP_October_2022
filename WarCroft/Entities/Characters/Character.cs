using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private double baseHealth;
		private double health;
		private double baseArmor;
		private double armor;
		private double abilityPoints;
		private Bag bag;

		public Character(string name, double health, double armor, double abilityPoints, Bag bag)
		{
			this.Name = name;
			this.baseHealth = health;
			this.Health = health;
			this.baseArmor = armor;
			this.Armor = armor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag; 
		}

		public string Name
		{
			get => this.name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be null or whitespace!");
				}
				this.name = value;
			}
		}

		public double BaseHealth => this.baseHealth;

		public double Health
		{
			get => this.health;
			set
			{
				this.health = value;

				if (this.health < 0)
				{
					this.health = 0;
				}
				if (this.health > this.BaseHealth)
				{
					this.health = this.BaseHealth;
				}
			}
		}

		public double BaseArmor => this.baseArmor;

		public double Armor
		{
			get => this.armor;
			private set
			{
				this.armor = value;
				if (this.armor < 0)
				{
					this.armor = 0;
				}
			}
		}

		public double AbilityPoints
		{
			get => this.abilityPoints;
			private set
			{
				this.abilityPoints = value;
			}
		}

		public Bag Bag
		{
			get => this.bag;
			private set
			{
				this.bag = value;
			}
		}

		public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public void TakeDamage(double hitPoints)
		{
			if (this.IsAlive)
			{
				if (this.Armor >= hitPoints)
				{
					this.Armor -= hitPoints;
				}
				else
				{
					double difference = hitPoints - this.Armor;
					this.Armor = 0;
					this.Health -= difference;
					if (this.Health <= 0)
					{
						this.IsAlive = false;
					}
				}
			}
		}

		public void UseItem(Item item)
		{
			item.AffectCharacter(this);
		}


	}
}