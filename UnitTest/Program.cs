using System.Reflection;
using MathLibrary;
namespace UnitTest;

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Unit tests");
        System.Console.WriteLine("adding and subtracting");
        System.Console.WriteLine("{0}+{1}={2}",Utilities.Add(1,30));
        System.Console.WriteLine("{0}-{1}={2}",Utilities.Subtract(1,30));

    }

}
