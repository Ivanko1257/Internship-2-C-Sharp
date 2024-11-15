using System.Runtime.InteropServices;

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
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Upišite ID ako želite brisati korsinika preko ID-a ili IME I PREZIME ako želite brisati korisnika preko toga, a ako se želite vratiti na početni zaslon upišite HOME:  ");
                        var delete_input = Console.ReadLine();
                        if (delete_input=="HOME")
                        {
                            break;
                        }
                        if (delete_input == "ID")
                        {
                            Console.Write("Upišite ID korisnika");
                            int.TryParse(Console.ReadLine(), out var delete_input_id);
                            foreach (var keys in Accounts.Keys)
                            {
                                if (keys==delete_input_id)
                                {
                                    Console.WriteLine($"Jeste li sigurni da želite izbrisati {Accounts[delete_input_id]}? Upišite YES ako da, NO ako ne");
                                    var delete_affirmation = Console.ReadLine();
                                    if (delete_affirmation == "YES")
                                    {
                                        delete_input = "done";
                                        Accounts.Remove(delete_input_id);
                                        Console.WriteLine("Korisnik uspiješno izbrisan. Vračamo vas na početni zaslon");
                                        Thread.Sleep(2000);
                                        break;

                                    }
                                    else if (delete_affirmation == "NO")
                                    {
                                        Console.WriteLine("Zahtjev odbijen. Vrračamo vas na početni zaslon");
                                        delete_input = "done";
                                        break;
                                    }
                                }
                            }
                            if(delete_input!="done")
                            {
                                Console.WriteLine("Korisnik ne postoji te je brisanje bilo neuspiješno. Pokušajte ponovo.");
                                Thread.Sleep(2000);
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (delete_input=="IME I PREZIME")
                        {
                            Console.Write("Upišite Ime korisnika: ");
                            var delete_name= Console.ReadLine();
                            Console.Write("Upišite Prezime korisnika: ");
                            var delete_surname=Console.ReadLine();
                            foreach(var key in Accounts.Keys)
                            {
                                if (Accounts[key].Item1 == delete_name && Accounts[key].Item2 == delete_surname)
                                {
                                    Console.WriteLine($"Jeste li sigurni da želite izbrisati {Accounts[key]}? Upišite YES ako da, NO ako ne");
                                    var delete_affirmation = Console.ReadLine();
                                    if (delete_affirmation == "YES")
                                    {
                                        delete_input = "done";
                                        Accounts.Remove(key);
                                        Console.WriteLine("Korisnik uspiješno izbrisan. Vračamo vas na početni zaslon");
                                        Thread.Sleep(2000);
                                        break;

                                    }
                                    else if (delete_affirmation == "NO")
                                    {
                                        Console.WriteLine("Zahtjev odbijen. Vrračamo vas na početni zaslon");
                                        break;
                                    }
                                }
                            }
                            if (delete_input!="done")
                            {
                                Console.WriteLine("Brisanje je bilo neuspiješno. Pokušajte ponovo.");
                                Thread.Sleep(2000);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    break;
                }
            case 3:
                while (true)
                {
                    Console.Clear();
                    Console.Write("Upišite ID korisnika kojeg želite urediti: ");
                    int.TryParse(Console.ReadLine(), out var edit_id);
                    bool edit_affirmation=false;
                    foreach(var keys in  Accounts.Keys)
                    {
                        if (keys==edit_id)
                        {
                            Console.Write($"Trenutno ime je {Accounts[keys].Item1}. Upišite novo koje želite dodati: ");
                            var new_name = Console.ReadLine();
                            if (new_name==null)
                            {
                                Console.WriteLine("Netočno upisan podatak. Pokušajte ponovno.");
                                Thread.Sleep(2000);
                                break;
                            }
                            Console.Write($"Trenutno prezime je {Accounts[keys].Item2}. Upišite novo koje želite dodati: ");
                            var new_surname = Console.ReadLine();
                            if (new_surname == null)
                            {
                                Console.WriteLine("Netočno upisan podatak. Pokušajte ponovno.");
                                Thread.Sleep(2000);
                                break;
                            }
                            Console.Write($"Trenutni datum rođenja je {Accounts[keys].Item3}. Upišite novi koji želite dodati: ");
                            DateTime.TryParse(Console.ReadLine(), out var new_birthdate);
                            if (new_birthdate == null)
                            {
                                Console.WriteLine("Netočno upisan podatak. Pokušajte ponovno.");
                                Thread.Sleep(2000);
                                break;
                            }
                            Accounts[keys] = Tuple.Create( new_name, new_surname, new_birthdate);
                            Console.WriteLine("Uređivanje je uspiješno, vraćamo vas na početni zaslon");
                            Thread.Sleep(2000);
                            edit_affirmation = true;
                            break;

                        }
                    }
                    if (edit_affirmation)
                    {
                        break;
                    }
                }
                break;
            case 4:
                Console.Clear ();
                foreach (var account in Accounts)
                {
                    Console.WriteLine(account);
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