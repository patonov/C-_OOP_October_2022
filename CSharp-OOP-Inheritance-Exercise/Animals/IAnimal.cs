using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public interface IAnimal
    {
        string Name { get; set; }
        int Age { get; set; }
        string Gender { get; set; }

        string ProduceSound();
    }
}
