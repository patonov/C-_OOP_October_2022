using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class CardsDeck
    {        
        private List<Card> cards = new List<Card>();

        public void Add(Card card)
        { 
            cards.Add(card);
        }

        public void Print()
        {
            Console.WriteLine("{0} {1}", cards[cards.Count - 1].Face, cards[cards.Count - 1].Suit);
        }

        public void GetAllCards()
        {
            foreach (Card card in cards) 
            {
                card.Print();
            }
        }

        public void Randomize()
        { 
            Random rnd = new Random();

            for(int i = 0; i < cards.Count; i++) 
            { 
                int rInx = rnd.Next(0, cards.Count);
                Card oldCard = cards[i];
                cards[i] = cards[rInx];
                cards[rInx] = oldCard;
            }

            this.GetAllCards();
        }

        public void Clear()
        { 
            cards.Clear(); 
        }

    }
}
