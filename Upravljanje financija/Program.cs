var Accounts = new Dictionary<int, Tuple<string, string, DateTime>>()
    {
        {0, Tuple.Create("Mujo", "Mujić", new DateTime(1996, 1, 31))},
        {1, Tuple.Create("Haso", "Hasić", new DateTime(1994, 4, 7)) }
    };
while (true)
{
    Console.Clear();
    Console.WriteLine("1 - Korisnici \n2 - Računi \n3 - Izlaz");
    int operation_num;
    while (true)
    {
        Console.Write("Upišite broj željene operacije: ");
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
    if (operation_num == 1)
    {
        Console.Clear();
        Console.WriteLine("1 - Unos novog korisnika \n2 - Brisanje korisnika \n3 - Uređivanje korisnika \n4 - Pregled korisnika");
        Console.Write("Upišite broj željene operacije: ");
        int.TryParse(Console.ReadLine(), out var operation_num_accounts);
        switch(operation_num_accounts)
        {
            case 1:
                while(true)
                {
                    Console.Clear();
                    Console.Write("Upišite ime novog korisnika: ");
                    string new_name = Console.ReadLine();
                    Console.Write("Upišite prezime novog korisnika: ");
                    string new_surname = Console.ReadLine();
                    Console.Write("Upišite datum rođenja novog korisnika: ");
                    DateTime.TryParse(Console.ReadLine(), out DateTime new_birthdate);
                    if (new_birthdate is DateTime && new_name is string && new_surname is string)
                    {
                        Accounts.Add(Accounts.Count, Tuple.Create(new_name, new_surname, new_birthdate));
                        Console.WriteLine("Korisnik uspješno dodan, vraćamo vas na početni zaslon");
                        Thread.Sleep(2000);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Korisnik nije dodan zbog pogreška u unošenju podataka. Molimo ponovno unesite podatke");
                        Thread.Sleep(2000);
                    }
                }
                break;
            case 2:
                Console.Clear ();
                break;
            case 3:
                Console.Clear ();
                break;
            case 4:
                Console.Clear ();
                for(var i=0; i<Accounts.Count; i++)
                {
                    Console.WriteLine(Accounts[i]);
                }
                Console.WriteLine("Pritisnite ENTER za povratak na početni zaslon");
                var home_input=Console.ReadLine();
                if(home_input is not null)
                {
                    break;
                }
                return;
        }
    }
    if(operation_num == 3)
    {
        break;
    }
}