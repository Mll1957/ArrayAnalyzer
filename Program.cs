using System;

public class ArrayAnalyzer
{
    private static ArrayAnalyzer _instance;
    private int[] _array;

    // Приватный конструктор
    private ArrayAnalyzer(int[] array)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array), "Массив не может быть null.");

        if (array.Length < 2)
            throw new ArgumentException("Массив должен содержать как минимум два элемента.", nameof(array));

        _array = array;
    }

    // Статический метод для получения экземпляра
    public static ArrayAnalyzer GetInstance(int[] array)
    {
        if (_instance == null)
        {
            _instance = new ArrayAnalyzer(array);
        }
        else
        {
            // Опционально: позволять обновление массива
            _instance.UpdateArray(array);
        }

        return _instance;
    }

    // Метод для обновления массива (если уже создан экземпляр)
    public void UpdateArray(int[] array)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array), "Массив не может быть null.");

        if (array.Length < 2)
            throw new ArgumentException("Массив должен содержать как минимум два элемента.", nameof(array));

        _array = array;
    }

    // Метод для получения суммы двух минимальных элементов
    public int SumOfTwoMin()
    {
        int min1 = int.MaxValue;
        int min2 = int.MaxValue;

        foreach (var num in _array)
        {
            if (num < min1)
            {
                min2 = min1;
                min1 = num;
            }
            else if (num < min2)
            {
                min2 = num;
            }
        }

        return min1 + min2;
    }
}
class Program
{
    static void Main()
    {
        int[] numbers = { 4, 0, 3, 19, 492, -10, 1 };

        try
        {
            // Получаем единственный экземпляр ArrayAnalyzer с массивом numbers
            ArrayAnalyzer analyzer = ArrayAnalyzer.GetInstance(numbers);
            int result = analyzer.SumOfTwoMin();
            Console.WriteLine($"Сумма двух минимальных элементов: {result}");

            // Если нужно, можно обновить массив и снова получить сумму
            int[] newNumbers = { -1, -3, -4, 5, 10 };
            analyzer.UpdateArray(newNumbers);
            result = analyzer.SumOfTwoMin();

            Console.WriteLine($"Сумма двух минимальных элементов после обновления: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
