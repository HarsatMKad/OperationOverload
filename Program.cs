using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SquareMatrix
  {
    private int Dimension;
    public SquareMatrix(int Dimension)
    {
      this.Dimension = Dimension;
    }
    public int[,] Matrix = new int[100, 100];

    public void CreateMatrix()
    {
      Random RandomNumber = new Random();
      for (int Line = 0; Line < Dimension; ++Line)
      {
        for (int Column = 0; Column < Dimension; ++Column)
        {
          Matrix[Line, Column] = RandomNumber.Next(0, 10);
        }
      }
    }

    public static SquareMatrix operator + (SquareMatrix MatrixA, SquareMatrix MatrixB)
    {
      SquareMatrix Answer = new SquareMatrix(MatrixA.Dimension);
      for (int Line = 0; Line < MatrixA.Dimension; ++Line)
      {
        for (int Column = 0; Column < MatrixA.Dimension; ++Column)
        {
          Answer.Matrix[Line, Column] = MatrixA.Matrix[Line, Column] + MatrixB.Matrix[Line, Column];
        }
      }
      return Answer;
    }

    public static SquareMatrix operator * (SquareMatrix MatrixA, SquareMatrix MatrixB)
    {
      SquareMatrix Answer = new SquareMatrix(MatrixA.Dimension);
      for (int Line = 0; Line < MatrixA.Dimension; ++Line)
      {
        for (int Column = 0; Column < MatrixA.Dimension; ++Column)
        {
          for(int k = 0; k < MatrixA.Dimension; ++k)
          {
            Answer.Matrix[Line, Column] = MatrixA.Matrix[Line, k] * MatrixB.Matrix[k, Column];
          }
        }
      }
      return Answer;
    }

    public static explicit operator double[][](SquareMatrix MatrixA)
    {
      double[][] Answer = new double[MatrixA.Dimension][];
      for (int Line = 0; Line < MatrixA.Dimension; ++Line)
      {
        for (int Column = 0; Column < MatrixA.Dimension; ++Column)
        {
          Answer[Line][Column] = MatrixA.Matrix[Line, Column];
        }
      }
      return Answer;
    }

    public static bool operator > (SquareMatrix MatrixA, SquareMatrix MatrixB)
    {
      double[][] doubMatrix1 = (double[][])MatrixA;
      double[][] doubMatrix2 = (double[][])MatrixB;
      double detA = ConsoleApp2.Gaus.MatrixDeterminant(doubMatrix1);
      double detB = ConsoleApp2.Gaus.MatrixDeterminant(doubMatrix2);

      if(detA > detB)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static bool operator < (SquareMatrix MatrixA, SquareMatrix MatrixB)
    {
      double[][] doubMatrix1 = (double[][])MatrixA;
      double[][] doubMatrix2 = (double[][])MatrixB;
      double detA = ConsoleApp2.Gaus.MatrixDeterminant(doubMatrix1);
      double detB = ConsoleApp2.Gaus.MatrixDeterminant(doubMatrix2);

      if (detA < detB)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static bool operator >= (SquareMatrix MatrixA, SquareMatrix MatrixB)
    {
      double[][] doubMatrix1 = (double[][])MatrixA;
      double[][] doubMatrix2 = (double[][])MatrixB;
      double detA = ConsoleApp2.Gaus.MatrixDeterminant(doubMatrix1);
      double detB = ConsoleApp2.Gaus.MatrixDeterminant(doubMatrix2);

      if (detA >= detB)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static bool operator <= (SquareMatrix MatrixA, SquareMatrix MatrixB)
    {
      double[][] doubMatrix1 = (double[][])MatrixA;
      double[][] doubMatrix2 = (double[][])MatrixB;
      double detA = ConsoleApp2.Gaus.MatrixDeterminant(doubMatrix1);
      double detB = ConsoleApp2.Gaus.MatrixDeterminant(doubMatrix2);

      if (detA <= detB)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static bool operator == (SquareMatrix MatrixA, SquareMatrix MatrixB)
    {
      for (int Line = 0; Line < MatrixA.Dimension; ++Line)
      {
        for (int Column = 0; Column < MatrixA.Dimension; ++Column)
        {
          if(MatrixA.Matrix[Line, Column] != MatrixB.Matrix[Line, Column])
          {
            return false;
          }
        }
      }
      return true;
    }

    public static bool operator != (SquareMatrix MatrixA, SquareMatrix MatrixB)
    {
      for (int Line = 0; Line < MatrixA.Dimension; ++Line)
      {
        for (int Column = 0; Column < MatrixA.Dimension; ++Column)
        {
          if (MatrixA.Matrix[Line, Column] == MatrixB.Matrix[Line, Column])
          {
            return false;
          }
        }
      }
      return true;
    }

    public static bool operator true (SquareMatrix MatrixA)
    {
      for (int Line = 0; Line < MatrixA.Dimension; ++Line)
      {
        for (int Column = 0; Column < MatrixA.Dimension; ++Column)
        {
          if(MatrixA.Matrix[Line, Column] != 1)
          {
            return false;
          }
        }
      }
      return true;
    }


    public static bool operator false (SquareMatrix MatrixA)
    {
      for (int Line = 0; Line < MatrixA.Dimension; ++Line)
      {
        for (int Column = 0; Column < MatrixA.Dimension; ++Column)
        {
          if (MatrixA.Matrix[Line, Column] != 0)
          {
            return false;
          }
        }
      }
        return true;
    }

    public static double Detdeterminant(SquareMatrix MatrixA)
    {
        double Answer;
        double[][] mat = (double[][])MatrixA;
        Answer = ConsoleApp2.Gaus.MatrixDeterminant(mat);
      return Answer;
    }

    public static double[][] InversesMatrix(SquareMatrix MatrixA)
    {
      double[][] Answer = new double[MatrixA.Dimension][];
      for (int Line = 0; Line < MatrixA.Dimension; ++Line)
      {
        for (int Column = 0; Column < MatrixA.Dimension; ++Column)
        {
          Answer[Line][Column] = MatrixA.Matrix[Column, Line];
        }
      }

      double Detdeterminant = ConsoleApp2.Gaus.MatrixDeterminant(Answer);

      for (int Line = 0; Line < MatrixA.Dimension; ++Line)
      {
        for (int Column = 0; Column < MatrixA.Dimension; ++Column)
        {
          Answer[Line][Column] /= Detdeterminant;
        }
      }
      return Answer;
    }

    public override bool Equals(Object obj1)
    {
      if (obj1 is SquareMatrix)
        {
        return true;
      }
      else
      {
        return false;
      }
    }

    public override int GetHashCode()
    {
      return (int)this.Dimension;
    }

    public override string ToString()
    {
      string strResult = "";

      for (int Line = 0; Line < Dimension; ++Line)
      {
        for (int Column = 0; Column < Dimension; ++Column)
        {
          strResult += Matrix[Line, Column].ToString();
        }
      }
      return strResult;
    }

    public int CompareTo(object other)
    {
      if (other is SquareMatrix)
      {
        if (Matrix[0, 0] > Matrix[1, 0]) return -1;
        if (Matrix[0, 0] == Matrix[1, 0]) return 0;
        if (Matrix[0, 0] < Matrix[1, 0]) return 1;
      }
      return -1;
    }

    public void Display()
    {
      for (int Line = 0; Line < Dimension; ++Line)
      {
        for (int Column = 0; Column < Dimension; ++Column)
        {
          Console.Write(Matrix[Line, Column] + " ");
        }
        Console.WriteLine("\n");
      }
    }
  }

  public class Singleton
  {
    public static Singleton Instance
    {
      get
      {
        if (instance == null) instance = new Singleton();
        return instance;
      }
    }
    public void MatrixCalculator()
    {
      int Dimension;
      Console.WriteLine("введите размерность матриц: ");
      Dimension = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("первая матрица:");
      SquareMatrix matrix1 = new SquareMatrix(Dimension);
      matrix1.CreateMatrix();
      matrix1.Display();

      Console.WriteLine("вторая матрица:");
      SquareMatrix matrix2 = new SquareMatrix(Dimension);
      matrix2.CreateMatrix();
      matrix2.Display();

      string Operation;
      Console.WriteLine("какую операцию необходимо выполнить: ");
      Operation = Convert.ToString(Console.ReadLine());

      switch (Operation)
      {
        case "+":
          SquareMatrix SumMatrix = matrix1 + matrix2;
          SumMatrix.Display();
          break;

        case "*":
          SquareMatrix MultipliedMatrix = matrix1 * matrix2;
          MultipliedMatrix.Display();
          break;

        case "determ":
          double det1 = SquareMatrix.Detdeterminant(matrix1);
          Console.WriteLine(det1);
          break;

        case "invers":
          double[][] invers = SquareMatrix.InversesMatrix(matrix1);
          for (int Line = 0; Line < Dimension; ++Line)
          {
            for (int Column = 0; Column < Dimension; ++Column)
            {
              Console.Write(invers[Line][Column] + " ");
            }
            Console.WriteLine("\n");
          }
          break;

        case ">":
          Console.WriteLine(matrix1 > matrix2);
          break;

        case "<":
          Console.WriteLine(matrix1 < matrix2);
          break;

        case ">=":
          Console.WriteLine(matrix1 >= matrix2);
          break;

        case "<=":
          Console.WriteLine(matrix1 <= matrix2);
          break;

        case "==":
          Console.WriteLine(matrix1 == matrix2);
          break;

        case "!=":
          Console.WriteLine(matrix1 != matrix2);
          break;
          
        case "true":
          if (matrix1)
          {
            Console.WriteLine(true);
          }
          else
          {
            Console.WriteLine(false);
          }
          break;

        case "false":
          if (matrix1)
          {
            Console.WriteLine(false);
          }
          else
          {
            Console.WriteLine(true);
          }
          break;

        case "equals":
          Console.WriteLine(Equals(matrix1));
          break;

        case "hash":
          Console.WriteLine(GetHashCode());
          break;

        case "string":
          Console.WriteLine(matrix1.ToString());
          break;

        case "compare":
          Console.WriteLine(matrix2.CompareTo(matrix1));
          break;

        default:
          Console.WriteLine("некорректно указана операция");
          break;
      }
    }
    private Singleton() { }
    private static Singleton instance;
  }

  class Program
  {
    static void Main(string[] args)
    {
      Singleton.Instance.MatrixCalculator();
      Console.ReadKey();
    }
  }
}
