Console.WriteLine("1 - Korisnici");
Console.WriteLine("2 - Računi");
Console.WriteLine("3 - Izlaz iz aplikacije");
int operation_num;
while (true)
{
    Console.Write("Upišite broj željene operacije");
    int.TryParse(Console.ReadLine(), out operation_num);
    if (operation_num == 1 || operation_num == 2 || operation_num == 3)
    {
        break;
    }
    else
    {
        Console.WriteLine("Nemoguća operacija.");
    }
}
