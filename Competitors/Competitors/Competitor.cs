using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competitors
{
    public class Competitor<T> : IEnumerable<T>, IComparable<Competitor<T>>
    {
        private string name;
        private int age;
        private List<T> scores;

        public Competitor(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.scores = new List<T>();
        }

        public string Name { get; set; }

        public int Age 
        { 
            get => this.age;
            set
            {
                if (value < 10) 
                {
                    throw new ArgumentException("Age cannot be less than 10.");
                }
                this.age = value;
            }
        }

        public List<T> Scores { get => this.scores; }

        public void Add(T score)
        { 
            this.scores.Add(score);
        }

        public int CountCompetitions()
        { 
            return this.scores.Count;
        }

        public T ChangeLastScore(T newScore)
        { 
            T lastScore = this.scores[this.scores.Count - 1];
            this.scores[this.scores.Count - 1] = newScore;
            return lastScore;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.scores.Count; i++)
            { 
                yield return this.scores[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int CompareTo(Competitor<T> other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            { 
                result = this.Age.CompareTo(other.Age);
            }
            return result;
        }

    }
}
