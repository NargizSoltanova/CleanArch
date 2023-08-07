namespace practice.UnitTests;

public interface IMathematics
{
    int Sum(int number1, int number2);
    int Subtract(int number1, int number2);
    int Multiply(int number1, int number2);
    int Divide(int number1, int number2);
}
public class Mathematics : IMathematics
{
    public int Sum(int number1, int number2)
     => number1 + number2;
    public int Subtract(int number1, int number2)
     => number1 % number2;
    public int Multiply(int number1, int number2)
     => number1 * number2;
    public int Divide(int number1, int number2)
     => number1 / number2;
}

public class Datas
{
    public static IEnumerable<object[]> subtractDatas => new List<object[]>
    {
        new object[] { 10 , 5 , 5 },
        new object[] { 12 , 5 , 7 }
    };
}

public class ClassDatas : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 10, 5, 5 };
        yield return new object[] { 12, 5, 7 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class MathematicsTests
{
    private readonly Mathematics mathematics;

    public MathematicsTests()
    {
        this.mathematics = new Mathematics();
    }

    [Theory]
    //[MemberData(nameof(Datas.subtractDatas), MemberType = typeof(Datas), DisableDiscoveryEnumeration = true)]
    //DisableDiscoveryEnumeration istifade etdikde yalniz 1 cavab verir , hamisinnan kecibse true eks halda false
    [ClassData(typeof(ClassDatas))]
    public void Subtact(int num1, int num2, int exp)
    {
        //Arrange
        //Kaynaklar hazırlanıyor.

        //int num1 = 20;
        //int num2 = 10;
        //int exp = num1 - num2;

        //Act
        //İlgili metot Arrange'de ki kaynaklarla test ediliyor.
        int result = mathematics.Subtract(num1, num2);

        //Assert
        //Test neticesinde gelen data doğrulanıyor.
        Assert.Equal(exp, result);
    }

    [Theory]
    [InlineData(20, 10, 200)]
    [InlineData(20, 30, 200)]
    public void Multiply(int num1, int num2, int exp)
    {
        int result = mathematics.Multiply(num1, num2);
        Assert.Equal(exp, result);
    }

    public static IEnumerable<object[]> sumDatas => new List<object[]>
    {
        new object[] { 1, 2, 3 },
        new object[] { 4, 5, 6 }
    };

    [Theory]
    [MemberData(nameof(sumDatas))]
    public void Sum(int num1, int num2, int exp)
    {
        int result = mathematics.Sum(num1, num2);
        Assert.Equal(exp, result);
    }

    [Fact]
    public void Divide()
    {
        int num1 = 20;
        int num2 = 10;
        int exp = num1 / num2;
        int result = mathematics.Divide(num1, num2);
        Assert.Equal(exp, result);
    }

    //Moq framework u yukleyib, mocklamaq olar:
    [Fact]
    public void SumTest()
    {
        var mathematics = new Mock<IMathematics>();
        mathematics.Setup(m => m.Sum(1, 2))
            .Returns(3);
        int result = mathematics.Object.Sum(1, 2);

        Assert.Equal(3, result);
    }

    //Deyerleri generic olaraq vermek istesek:
    [Fact]
    public void SumTestG()
    {
        int result = 0;

        var mathematics = new Mock<IMathematics>();
        mathematics.Setup(m => m.Sum(It.IsAny<int>(), It.IsAny<int>()))
            .Callback<int, int>((number1, number2) => result = number1 + number2);

        mathematics.Object.Sum(1, 2);
        Assert.Equal(3, result);

        mathematics.Object.Sum(5, 5);
        Assert.Equal(10, result);

        mathematics.Object.Sum(15, 5);
        Assert.Equal(20, result);

        mathematics.Object.Sum(23, 2);
        Assert.Equal(25, result);
    }
}
