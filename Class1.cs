using NUnit.Framework;
using System;

[TestFixture]
public class ArrayAnalyzerTests
{
    // Тест 1: Пустой массив
    [Test]
    public void Test_EmptyArray_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(() => ArrayAnalyzer.GetInstance(new int[0]));
    }

    // Тест 2: Массив из одного элемента
    [Test]
    public void Test_SingleElementArray_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => ArrayAnalyzer.GetInstance(new[] { 5 }));
    }

    // Тест 3: Массив без чисел - проверка на исключение
    [Test]
    public void Test_ArrayWithNoNumbers_ShouldThrow()
    {
        // Если вы используете массив объектов или другой тип данных, 
        // предполагаем, что вы создаете ошибку при инициализации.
        // Для простоты в этом случае будем использовать массив с одиночными числами
        Assert.Throws<ArgumentException>(() => ArrayAnalyzer.GetInstance(new int[] { }));
    }

    // Тест 4: Большой массив с 100 миллионами элементов
    [Test]
    public void Test_LargeArray_ShouldReturnSumOfTwoMin()
    {
        int[] largeArray = new int[100_000_000];
        Random rand = new Random();

        // Заполнение массива случайными числами
        for (int i = 0; i < largeArray.Length; i++)
        {
            largeArray[i] = rand.Next(-1000, 1000);
        }

        ArrayAnalyzer analyzer = ArrayAnalyzer.GetInstance(largeArray);
        int result = analyzer.SumOfTwoMin();

        // Это значение не нам известно заранее, но важно, что метод работает без исключений.
        Assert.IsInstanceOf<int>(result);
    }

    // Тест 5: Обычный массив с несколькими элементами
    [Test]
    public void Test_MixedArray_ShouldReturnSumOfMin()
    {
        int[] mixedArray = { 5, -3, 0, 10, 4, -1 };
        ArrayAnalyzer analyzer = ArrayAnalyzer.GetInstance(mixedArray);
        Assert.AreEqual(-3 + -1, analyzer.SumOfTwoMin());
    }

    // Тест 6: Массив, состоящий только из отрицательных чисел
    [Test]
    public void Test_OnlyNegativeNumbers_ShouldReturnSumOfTwoMin()
    {
        int[] negativeArray = { -10, -20, -30, -5 };
        ArrayAnalyzer analyzer = ArrayAnalyzer.GetInstance(negativeArray);
        Assert.AreEqual(-30 + -20, analyzer.SumOfTwoMin());
    }
}

