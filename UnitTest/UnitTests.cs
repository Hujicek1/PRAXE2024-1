using MathLibrary;
using Xunit;
namespace UnitTests;

public class UnitTest1
{
   [Fact]
    public void TestAddMethod01()
    {
        int res1 = Utilities.Add(1, 5);
        Assert.Equal(6, res1);
    }
    [Fact]
    public void TestSubstractMethod() 
    {
        int res2 = Utilities.Subtract(30,15);
        Assert.Equal(15,res2);
    }
    [Fact]
    public void TestMultiplyMethod()
    {
        int res3 = Utilities.Multiply(2,5);
        Assert.Equal(10,res3);
    }
    [Fact]
    public void TestDevisionMethod()
    {
        int res4 = Utilities.Devision(20,2);
        Assert.Equal(10,res4);
    }
}   
