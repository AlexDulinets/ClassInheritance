class CCircle
{
    protected double r;

    public CCircle(double r)
    {
        this.r = r;
    }

    public virtual double GetArea()
    {
        return Math.PI * r * r;
    }

    public double GetCircleLength()
    {
        return 2 * Math.PI * r;
    }

    public virtual void GetProperties()
    {
        Console.WriteLine($"Радиус окружности:  {r}");
        Console.WriteLine($"Площадь окружности: {GetArea()}");
        Console.WriteLine($"Длина окружности:   {GetCircleLength()}");
    }
}
class CRSCylinder : CCircle
{
    private double h;

    public CRSCylinder(double r, double h) : base(r)
    {
        this.h = h;
    }

    public double GetVolume()
    {
        return base.GetArea() * h;
    }
    public override double GetArea()
    {
        return ((2 * Math.PI * r * h) + (2 * Math.PI * r * r));//площадь полной поверхности цилиндра
    }

    public override void GetProperties()
    {
        Console.WriteLine($"Радиус цилиндра:  {r}");
        Console.WriteLine($"Высота цилиндра:  {h}");
        Console.WriteLine($"Площадь цилиндра: {GetArea()}");
        Console.WriteLine($"Объём цилиндра:   {GetCircleLength()}");
    }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///
class Lab7
{
    static void Main(string[] args)
    {
        int n, m;
        double r, h;
        //поиск окружности максимальной площади
        Console.WriteLine("Введите количество окружностей(N): ");

        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Введите целое положительное число!");
        }

        List<CCircle> circles = new List<CCircle>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Введите радиус окружности(r): ");

            while (!double.TryParse(Console.ReadLine(), out r) || r <= 0)
            {
                Console.WriteLine("Введите число большое нуля!");
            }
            circles.Add(new CCircle(r));
        }
        

        double maxArea = 0;
        CCircle maxCircle = null;
        foreach (CCircle circle in circles)
        {
            if (circle.GetArea() > maxArea)
            {
                maxArea = circle.GetArea();
                maxCircle = circle;
            }
        }
        Console.WriteLine("Окружность максимальной площади: ");
        maxCircle.GetProperties();
        Console.WriteLine();
        //поиск среднего объема M цилиндров

        Console.WriteLine("Введите количество цилиндров(M): ");

        while (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
        {
            Console.WriteLine("Введите целое положительное число!");
        }

        List<CRSCylinder> cylinders = new List<CRSCylinder>();

        for (int i = 0; i < m; i++)
        {
            Console.WriteLine("Введите радиус цилиндра(r): ");

            while (!double.TryParse(Console.ReadLine(), out r) || r <= 0)
            {
                Console.WriteLine("Введите число большое нуля!");
            }
            Console.WriteLine("Введите высоту цилиндра(h): ");

            while (!double.TryParse(Console.ReadLine(), out h) || h <= 0)
            {
                Console.WriteLine("Введите число большое нуля!");
            }
            cylinders.Add(new CRSCylinder(r, h));
        }
        

        double totalVolume = 0;
        foreach (CRSCylinder cylinder in cylinders)
        {
            totalVolume += cylinder.GetVolume();
        }
        double avgVolume = totalVolume / cylinders.Count;
        Console.WriteLine($"средний объем M цилиндров: {avgVolume}");
    }
}