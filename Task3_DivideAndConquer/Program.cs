namespace Task3_DivideAndConquer;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 10, 20, 30, 40, 50, 60 };
        
        int mid = array.Length / 2;
        int[] leftArr = array[0..(2+1)];
        int[] rightArr = array[(mid)..array.Length];

        Console.WriteLine("Left Array:");
        foreach (int i in leftArr)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        Console.WriteLine("Right Array:");
        foreach (int i in rightArr)
        {
            Console.WriteLine(i);
        }
    }
}