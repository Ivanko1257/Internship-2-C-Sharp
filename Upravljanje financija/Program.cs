using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Channels;
var Accounts = new Dictionary<int, Tuple<string, string, DateTime, double, double, double>>()
    {
        {0, Tuple.Create("Mujo", "Mujić", new DateTime(1996, 1, 31), 100.00, 0.00, 0.00)},
        {1, Tuple.Create("Haso", "Hasić", new DateTime(1994, 4, 7), 100.00, 0.00, 0.00)}
    };
var Transactions = new List<List<string>>();
Transactions.Add(new List<string> { "0" });
Transactions.Add(new List<string> { "1" });
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
        Console.WriteLine("Bilo kad upišite /HOME kako biste se vratili na početni zaslon.");
        Console.WriteLine("1 - Unos novog korisnika \n2 - Brisanje korisnika \n3 - Uređivanje korisnika \n4 - Pregled korisnika");
        Console.Write("Upišite broj željene operacije: ");
        int.TryParse(Console.ReadLine(), out var operation_num_accounts);
        switch(operation_num_accounts)
        {
            case 1:
                while(true)
                {
                    Console.Clear();
                    Console.WriteLine("Bilo kad upišite /HOME kako biste se vratili na početni zaslon.");
                    Console.Write("Upišite ime novog korisnika: ");
                    string new_name = Console.ReadLine();
                    if (new_name=="/HOME")
                    {
                        break;
                    }
                    Console.Write("Upišite prezime novog korisnika: ");
                    string new_surname = Console.ReadLine();
                    if (new_surname == "/HOME")
                    {
                        break;
                    }
                    Console.Write("Upišite datum rođenja novog korisnika: ");
                    var birthdate=Console.ReadLine();
                    if (birthdate == "/HOME")
                    {
                        break;
                    }
                    if (new_name != "" && new_surname != "" && birthdate is not null)
                    {
                        DateTime.TryParse(birthdate, out var new_birthdate);
                        Accounts.Add(Accounts.Count, Tuple.Create(new_name, new_surname, new_birthdate, 100.00, 0.00, 0.00));
                        Transactions.Add(new List<string> { Accounts.Count.ToString() });
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
                        Console.WriteLine("Upišite /HOME kako biste se vratili na početni zaslon.");
                        Console.WriteLine("Upišite ID ako želite brisati korsinika preko ID-a ili IME I PREZIME ako želite brisati korisnika preko toga:  ");
                        var delete_input = Console.ReadLine();
                        if (delete_input=="/HOME")
                        {
                            break;
                        }
                        if (delete_input == "ID")
                        {
                            Console.Write("Upišite ID korisnika");
                            var delete_homecheck = Console.ReadLine();
                            if (delete_homecheck == "/HOME")
                            {
                                break;
                            }
                            int.TryParse(delete_homecheck, out var delete_input_id);
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
                            if (delete_name=="/HOME")
                            {
                                break;
                            }
                            Console.Write("Upišite Prezime korisnika: ");
                            var delete_surname=Console.ReadLine();
                            if (delete_surname=="/HOME")
                            {
                                break;
                            }
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
                    Console.WriteLine("Upišite /HOME kako biste se vratili na početni zaslon.");
                    Console.Write("Upišite ID korisnika kojeg želite urediti: ");
                    var edit_enter = Console.ReadLine();
                    if (edit_enter=="/HOME")
                    {
                        break;
                    }
                    int.TryParse(edit_enter, out var edit_id);
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
                            Accounts[keys] = Tuple.Create( new_name, new_surname, new_birthdate, Accounts[keys].Item4, Accounts[keys].Item5, Accounts[keys].Item6);
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
    else if(operation_num == 2)
    {
        while(true)
        {
            Console.Clear();
            bool new_affirmation = false;
            Console.WriteLine("Unesite ime korisnika: ");
            var name_check = Console.ReadLine();
            if (name_check=="/HOME")
            {
                break;
            }
            Console.WriteLine("Unesite prezime korisnika: ");
            var surname_check = Console.ReadLine();
            if (surname_check == "/HOME")
            {
                break;
            }
            int picked_account=-1;
            foreach(var key in Accounts.Keys)
            {
                if (Accounts[key].Item1 == name_check && Accounts[key].Item2 == surname_check)
                    picked_account = key;

            }
            if(picked_account==-1)
            {
                Console.WriteLine("Korisnik kojeg tražite ne postoji. Vraćamo vas na početni zaslon");
                Thread.Sleep(2000);
                break;
            }
            int bill_place;
            Console.WriteLine("Unesite 1 ako želite pogledati tekući račun, 2 ako želite žiro i 3 ako želite prepaid: ");
            var bill_check = Console.ReadLine();
            if (bill_check == "/HOME")
            {
                break;
            }
            int.TryParse(bill_check, out bill_place);
            Console.Clear();
            Console.WriteLine("1 - Unos nove transakcije \n2 - Brisanje transakcije \n3 - Uređivanje transakcije \n4 - Pregled transakcija \n5 - Financijsko izvješće");
            int.TryParse(Console.ReadLine(), out var operation_num_bills);
            switch (operation_num_bills)
            {
                case 1:
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Upišite /HOME kako biste se vratili na početni zaslon.");
                        Console.Write("Unesite Tip transakcije (PRIHOD, RASHOD): ");
                        var new_type = Console.ReadLine();
                        Console.Write("Upišite iznos: ");
                        double.TryParse(Console.ReadLine(), out var new_amount);
                        Console.Write("Upišite opis transakcije: ");
                        var new_description = Console.ReadLine();
                        if (new_description == "")
                        {
                            new_description = "standardna transakcija";
                        }
                        Console.Write("Upišite kategoriju transakcije: ");
                        var new_category=Console.ReadLine();
                        Console.Write("Upišite Datum transakcije (ako želite današnji datum, samo pritisnite ENTER)");
                        var date=Console.ReadLine();
                        DateTime new_date;
                        if (date =="")
                        {
                            new_date = DateTime.Now;
                        }
                        else
                        {
                            DateTime.TryParse(date, out new_date);
                        }
                        if(new_type =="PRIHOD" || new_type=="RASHOD")
                        {
                            Console.Write($"Želite li provesti transakicju ({new_type}, {new_amount}, {new_description}, {new_category}, {new_date}) na vaš račun?");
                            var Transaction_affirmation = Console.ReadLine();
                            if (Transaction_affirmation=="YES")
                            {
                                for(int i = 0; i < Transactions.Count; i++)
                                {
                                    if (Transactions[i][0]==picked_account.ToString())
                                    {
                                        Transactions[i].Add(new_type);
                                        Transactions[i].Add(new_description);
                                        Transactions[i].Add(new_category);
                                        Transactions[i].Add(new_date.ToString());
                                        if(bill_place==1)
                                        {
                                            Accounts[picked_account] = Tuple.Create(Accounts[picked_account].Item1, Accounts[picked_account].Item2, Accounts[picked_account].Item3, Accounts[picked_account].Item4 - new_amount, Accounts[picked_account].Item5, Accounts[picked_account].Item6);
                                        }
                                        if(bill_place==2)
                                        {
                                            Accounts[picked_account] = Tuple.Create(Accounts[picked_account].Item1, Accounts[picked_account].Item2, Accounts[picked_account].Item3, Accounts[picked_account].Item4, Accounts[picked_account].Item5-new_amount, Accounts[picked_account].Item6);
                                        }
                                        if(bill_place==3)
                                        {
                                            Accounts[picked_account] = Tuple.Create(Accounts[picked_account].Item1, Accounts[picked_account].Item2, Accounts[picked_account].Item3, Accounts[picked_account].Item4, Accounts[picked_account].Item5, Accounts[picked_account].Item6 - new_amount);
                                        }
                                        new_affirmation= true;
                                        Console.WriteLine("Transakcija uspiješno provedena, vračamo vas na početni zaslon");
                                        Thread.Sleep(2000);
                                        break;
                                    }
                                }
                            }
                        }
                        if(new_affirmation)
                        {
                            break;
                        }
                    }
                    break;
            }
        }
    }
    else if(operation_num == 3)
    {
        break;
    }
}