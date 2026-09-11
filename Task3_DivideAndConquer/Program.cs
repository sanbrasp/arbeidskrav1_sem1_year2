namespace Task3_DivideAndConquer;

class Program
{
    static void Main(string[] args)
    {
        int[] test = { 10, 20, 30, 40, 50 };

        int[] slice = test[1..4];

        foreach (int i in slice)
        {
            Console.WriteLine(i);
        }
    }
}