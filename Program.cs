using System;

class Line
{
    protected float a0, a1, a2; // коефіцієнти

    public Line(float a0, float a1, float a2)
    {
        this.a0 = a0;
        this.a1 = a1;
        this.a2 = a2;
    }

    public virtual void SetCoefficients(float a0, float a1, float a2)
    {
        this.a0 = a0;
        this.a1 = a1;
        this.a2 = a2;
    }

    // метод для виведення коефіцієнтів
    public virtual void PrintCoefficients()
    {
        Console.WriteLine($"Line: {a1}*x + {a2}*y + {a0} = 0");
    }

    // метод для перевірки належності точки
    public bool Belongs(float x, float y)
    {
        return Math.Abs(a1 * x + a2 * y + a0) < 1e-6; // перевірка з похибкою
    }
}

class HyperPlane : Line // наслідуваний клас
{
    private float a3, a4; // додаткові коефіцієнти

    public HyperPlane(float a0, float a1, float a2, float a3, float a4)
        : base(a0, a1, a2)  // констуктор базового класу
    {
        this.a3 = a3;
        this.a4 = a4;
    }

    // перевантаження методу SetCoefficients
    public void SetCoefficients(float a0, float a1, float a2, float a3, float a4)
    {
        base.SetCoefficients(a0, a1, a2); // викликаємо метод базового класу
        this.a3 = a3;
        this.a4 = a4;
    }

    // перевантаження для виводу коефіцієнтів
    public override void PrintCoefficients()
    {
        Console.WriteLine($"HyperPlane: {a1}*x1 + {a2}*x2 + {a3}*x3 + {a4}*x4 + {a0} = 0");
    }

    // метод для перевірки належності точки у 4D
    public bool Belongs(float x1, float x2, float x3, float x4)
    {
        return Math.Abs(a1 * x1 + a2 * x2 + a3 * x3 + a4 * x4 + a0) < 1e-6;
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