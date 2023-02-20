using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class Matrix
  {
    int Dimension;
    int[,] Array;

    public void GeneratMatrix(int Dimension)
    {
      this.Dimension = Dimension;
      int[,] Array = new int[Dimension, Dimension];

      for(int Line = 0; Line < Dimension; ++Line)
      {
        for(int Column = 0; Column < Dimension; ++Dimension)
        {
          Random RandomNumber = new Random();
          Array[Line, Column] = RandomNumber.Next(0, 1000);
        }
      }
    }

    public void DisplayMatrix()
    {
      for (int Line = 0; Line < Dimension; ++Line)
      {
        for (int Column = 0; Column < Dimension; ++Column)
        {
          Console.WriteLine(Array[Line, Column]);
        }
      }
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Matrix m = new Matrix();
      m.GeneratMatrix(4);
      m.DisplayMatrix();

      Console.ReadKey();
    }
  }
}
