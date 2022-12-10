using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ChristmasPastryShop.Core.Contracts
{
    public class Controller : IController
    {
        private BoothRepository boothRepository;
        private CocktailRepository cocktailRepository;
        private DelicacyRepository delicacyRepository;

        public Controller()
        {
            this.boothRepository = new BoothRepository();
            this.cocktailRepository = new CocktailRepository();
            this.delicacyRepository = new DelicacyRepository();
        }



        public string AddBooth(int capacity)
        {
            var id = this.boothRepository.Models.Count + 1;

            IBooth booth = new Booth(id, capacity);

            this.boothRepository.AddModel(booth);

            return $"Added booth number {id} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }

            if (this.cocktailRepository.Models.All(x => x.Name == cocktailName && x.Size == size))
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }

            ICocktail cocktail;

            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            this.cocktailRepository.AddModel(cocktail);

            var target = this.boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);
            target.CocktailMenu.AddModel(cocktail);

            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }

            if (this.delicacyRepository.Models.Any(x => x.Name == delicacyName))
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }

            IDelicacy delicacy;

            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                delicacy = new Stolen(delicacyName);
            }
            this.delicacyRepository.AddModel(delicacy);
            var target = this.boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);
            target.DelicacyMenu.AddModel(delicacy);
            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string BoothReport(int boothId)
        {
            var target = this.boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);
            return target.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            Booth target = (Booth)this.boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);
            target.Charge();
            target.IsReserved = false;
            return $"Bill {(target.CurrentBill):f2} lv" + Environment.NewLine + $"Booth {target.BoothId} is now available!";

        }

        public string ReserveBooth(int countOfPeople)
        {
            var freeBooths = this.boothRepository.Models.Where(x => x.IsReserved == false && x.Capacity >= countOfPeople)
                .OrderBy(x => x.Capacity).ThenByDescending(x => x.BoothId);

            Booth booth = (Booth)freeBooths.First();

            if (booth == null)
            {
                return $"No available booth for {countOfPeople} people!";
            }
            booth.IsReserved = true;
            return $"Booth {booth.BoothId} has been reserved for {countOfPeople} people!";
        }

        public string TryOrder(int boothId, string order)
        {
            Booth booth = (Booth)this.boothRepository.Models.FirstOrDefault(x => x.BoothId == boothId);

            string[] orderArr = order.Split("/");
            var itemTypeName = orderArr[0];
            var itemName = orderArr[1];
            int countOrOrderedThings = int.Parse(orderArr[2]);
            if (orderArr.Length == 4)
            {
                string size = orderArr[3];
            }

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(c => c.Name == itemTypeName);
            if (type == null)
            {
                return $"{itemTypeName} is not recognized type!";
            }

            if (!this.cocktailRepository.Models.Any(x => x.Name == itemName) && this.delicacyRepository.Models.Any(x => x.Name == itemName))
            {
                return $"There is no {itemTypeName} {itemName} available!";
            }

            if (orderArr.Length == 3) // For Delicacy
            {
                if (!booth.DelicacyMenu.Models.Any(x => x.GetType().Name == itemTypeName && x.Name == itemName))
                {
                    return $"There is no {itemTypeName} {itemName} available!";
                }
                IDelicacy delicaaaaa = booth.DelicacyMenu.Models.FirstOrDefault(x => x.GetType().Name == itemTypeName && x.Name == itemName);

                booth.UpdateCurrentBill(delicaaaaa.Price * countOrOrderedThings);

                return $"Booth {boothId} ordered {countOrOrderedThings} {itemName}!";
            }

            else // For Coctail
            {
                string size = orderArr[3];
                if (!booth.CocktailMenu.Models.Any(x => x.GetType().Name == itemTypeName && x.Name == itemName))
                {
                    return $"There is no {size} {itemName} available!";
                }
                ICocktail cociiiii = booth.CocktailMenu.Models.FirstOrDefault(x => x.GetType().Name == itemTypeName && x.Name == itemName);
                booth.UpdateCurrentBill(cociiiii.Price * countOrOrderedThings);

                return $"Booth {boothId} ordered {countOrOrderedThings} {itemName}!";
            }

        }
    }
}
