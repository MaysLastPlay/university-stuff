using System;
using System.Collections.Generic;
using System.Text;
using Module3.zoo.animals;

namespace Module3.interfaces
{
    internal interface IAviary
    {
        int countedAnimals { get;  }
        bool IsFull { get;  }
        int Length { get; }
        void AddToAviary(params Animal[] animals);
    }
}
