using System;
using System.Collections.Generic;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Constants;
using WarCroft.Entities.Items;
using System.Linq;
using System.Text;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private Stack<Item> items;

		public WarController()
		{
			this.party = new List<Character>();
			this.items = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			if (characterType != nameof(Priest) && characterType != nameof(Warrior))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}
			Character character;

			if (characterType == nameof(Priest))
			{
				character = new Priest(name);
			}
			else
			{
				character = new Warrior(name);
			}
			this.party.Add(character);
			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			if (itemName != nameof(HealthPotion) && itemName != nameof(FirePotion))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem));
			}

			Item item;
			if (itemName == nameof(HealthPotion))
			{
				item = new HealthPotion();
			}
			else
			{
				item = new FirePotion();
			}
			this.items.Push(item);
			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			var targetCharacter = this.party.FirstOrDefault(x => x.Name == characterName);

			if (targetCharacter == null)
			{
				throw new ArgumentException($"Character {characterName} not found!");
			}

			if (!this.items.Any())
			{
				throw new InvalidOperationException("No items left in pool!");
			}
			var lastItemInPool = this.items.Pop();
			targetCharacter.Bag.AddItem(lastItemInPool);

			return $"{characterName} picked up {lastItemInPool.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			var targetCharacter = this.party.FirstOrDefault(x => x.Name == characterName);

			if (targetCharacter == null)
			{
				throw new ArgumentException($"Character {characterName} not found!");
			}

			var targetItem = targetCharacter.Bag.Items.FirstOrDefault(x => x.GetType().Name == itemName);

			if (targetItem == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, itemName));
			}

			targetCharacter.UseItem(targetItem);
			return $"{targetCharacter.Name} used {itemName}.";
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

			foreach (var ch in this.party.OrderByDescending(x => x.IsAlive).ThenBy(x => x.Health))
			{
				sb.AppendLine($"{ch.Name} - HP: {ch.Health}/{ch.BaseHealth}, AP: {ch.Armor}/{ch.BaseArmor}, Status: {(ch.IsAlive ? "Alive" : "Dead")}");
			}
			return sb.ToString().Trim();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			if (this.party.FirstOrDefault(x => x.Name == attackerName) == null)
			{
				throw new ArgumentException($"Character {attackerName} not found!");
			}
			if (this.party.FirstOrDefault(x => x.Name == receiverName) == null)
			{
				throw new ArgumentException($"Character {receiverName} not found!");
			}

			var attacker = this.party.FirstOrDefault(x => x.Name == attackerName);

			if (attacker.GetType().Name != nameof(Warrior))
			{
				throw new ArgumentException($"{attacker.Name} cannot attack!");
			}

			IAttacker att = (Warrior)attacker;

			var receiver = this.party.FirstOrDefault(x => x.Name == receiverName);

			att.Attack(receiver);

			string result = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points!" + Environment.NewLine +
				$"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

			if (!receiver.IsAlive)
			{
				result = result + Environment.NewLine;
				result = result + $"{receiver.Name} is dead!";
			}
			return result;
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			if (this.party.FirstOrDefault(x => x.Name == healerName) == null)
			{
				throw new ArgumentException($"Character {healerName} not found!");
			}
			if (this.party.FirstOrDefault(x => x.Name == healingReceiverName) == null)
			{
				throw new ArgumentException($"Character {healingReceiverName} not found!");
			}

			var healer = this.party.FirstOrDefault(x => x.Name == healerName);

			if (healer.GetType().Name != nameof(Priest))
			{
				throw new ArgumentException($"{healer.Name} cannot heal!");
			}

			IHealer hea = (Priest)healer;

			var receiver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);

			hea.Heal(receiver);

			string result = $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
			
			return result;		
		}
	}
}
