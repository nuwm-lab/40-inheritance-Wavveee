using System;

class Line
{
    protected float coefficientA, coefficientB, coefficientC; // Коефіцієнти для прямої

    // Конструктор для ініціалізації коефіцієнтів 
    public Line(float coefficientA, float coefficientB, float coefficientC)
    {
        this.coefficientA = coefficientA;
        this.coefficientB = coefficientB;
        this.coefficientC = coefficientC;
    }

    // Метод для задання коефіцієнтів прямої
    public virtual void SetCoefficients(float coefficientA, float coefficientB, float coefficientC)
    {
        if (coefficientA == 0 && coefficientB == 0) // Перевірка на некоректні коефіцієнти
        {
            throw new ArgumentException("Коефіцієнти не можуть бути одночасно нульовими.");
        }
        
        this.coefficientA = coefficientA;
        this.coefficientB = coefficientB;
        this.coefficientC = coefficientC;
    }

    // Метод для виведення коефіцієнтів прямої
    public virtual void PrintCoefficients()
    {
        Console.WriteLine($"Line: {coefficientB}*x + {coefficientC}*y + {coefficientA} = 0");
    }

    // Метод для перевірки належності точки прямій
    public bool Belongs(float x, float y)
    {
        return Math.Abs(coefficientB * x + coefficientC * y + coefficientA) < 1e-6; // Перевірка з похибкою
    }
}

class HyperPlane : Line // Клас гіперплощини, що успадковує від Line
{
    private float coefficientD, coefficientE; // Додаткові коефіцієнти для 4D простору

    // Конструктор для ініціалізації коефіцієнтів гіперплощини
    public HyperPlane(float coefficientA, float coefficientB, float coefficientC, float coefficientD, float coefficientE)
        : base(coefficientA, coefficientB, coefficientC)  // Викликаємо конструктор базового класу
    {
        this.coefficientD = coefficientD;
        this.coefficientE = coefficientE;
    }

    // Перевантаження методу SetCoefficients для гіперплощини
    public void SetCoefficients(float coefficientA, float coefficientB, float coefficientC, float coefficientD, float coefficientE)
    {
        base.SetCoefficients(coefficientA, coefficientB, coefficientC); // Викликаємо метод базового класу для першої частини
        this.coefficientD = coefficientD;
        this.coefficientE = coefficientE;
    }

    // Перевантаження для виведення коефіцієнтів гіперплощини
    public override void PrintCoefficients()
    {
        Console.WriteLine($"HyperPlane: {coefficientB}*x1 + {coefficientC}*x2 + {coefficientD}*x3 + {coefficientE}*x4 + {coefficientA} = 0");
    }

    // Метод для перевірки належності точки в 4D просторі
    public bool Belongs(float x1, float x2, float x3, float x4)
    {
        return Math.Abs(coefficientB * x1 + coefficientC * x2 + coefficientD * x3 + coefficientE * x4 + coefficientA) < 1e-6;
    }
}

class Program
{
    static void Main()
    {
        // --- Пряма ---
        Line line = new Line(2, 3, -6); // 2 + 3x - 6y = 0
        line.PrintCoefficients();

        Console.WriteLine(line.Belongs(1, 1)
            ? "Point (1,1) belongs to the line"
            : "Point (1,1) does NOT belong to the line");

        // --- Гіперплощина ---
        HyperPlane hyper = new HyperPlane(1, 2, 3, 4, 5); 
        hyper.PrintCoefficients();

        Console.WriteLine(hyper.Belongs(1, -1, 0, 0)
            ? "Point (1,-1,0,0) belongs to the hyperplane"
            : "Point (1,-1,0,0) does NOT belong to the hyperplane");
    }
}