using System;

namespace ESERCIZIO_3_BACKEND
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("APRIRE IL CONTO!");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Cognome: ");
            string surname = Console.ReadLine();

            Console.Write("Versamento iniziale: ");
            int versamentoIniziale = int.Parse(Console.ReadLine());

            ContoCorrente contoCorrente = new ContoCorrente(name, surname, versamentoIniziale);

            Console.WriteLine($"Conto aperto per {contoCorrente.Name} {contoCorrente.Surname}");
            Console.Clear();
            Console.WriteLine($"Saldo iniziale: {contoCorrente.SaldoConto}");

            bool primoVersamento = false;

            do
            {
                Console.WriteLine("Scegli un'operazione:");
                Console.WriteLine("1. Versamento");
                Console.WriteLine("2. Prelievo");
                Console.WriteLine("3. Esci");
             

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        Console.Write("Inserisci l'importo del versamento: ");
                        int importoVersamento = int.Parse(Console.ReadLine());

                        if (!primoVersamento && importoVersamento < 200)
                        {
                            Console.WriteLine("Il primo versamento deve essere superiore o uguale a 200 poveroo!!!.");
                        }
                        else
                        {
                            contoCorrente.EffettuaVersamento(importoVersamento);

                            Console.WriteLine($"Nuovo saldo: {contoCorrente.SaldoConto}");
                            primoVersamento = true;
                        }
                        break;

                    case "2":
                        Console.Write("Inserisci l'importo del prelievo: ");
                        int importoPrelievo = int.Parse(Console.ReadLine());
                        contoCorrente.EffettuaPrelievo(importoPrelievo);
                        Console.WriteLine($"Nuovo saldo: {contoCorrente.SaldoConto}");
                        break;

                    case "3":
                        Console.WriteLine("Uscita dal programma.");
                        return;

                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }

                Console.WriteLine("Premi un tasto per continuare...");
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }
    }

    class ContoCorrente
    {
        private string _name;
        private string _surname;
        private int _saldoConto;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public int SaldoConto
        {
            get { return _saldoConto; }
            private set { _saldoConto = value; }
        }


        private int _versamento;
        public int Versamento
        {
            get { return _versamento; }
            set
            {
                do
                {
                    if (value < 1000)
                    {
                        Console.WriteLine("Importo non accettato. Riprova.");
                        Console.Write("Inserisci un importo superiore o uguale a 1000: ");
                        value = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        _versamento = value;
                        break;
                    }
                } while (true);
                SaldoConto += _versamento;
            }
        }

        public ContoCorrente(string name, string surname, int versamentoIniziale)
        {
            _name = name;
            _surname = surname;
            Versamento = versamentoIniziale;
        }

        public void EffettuaVersamento(int importoVersamento)
        {
            _saldoConto += importoVersamento;
        }

        public void EffettuaPrelievo(int importoPrelievo)
        {
            if (_saldoConto >= importoPrelievo)
            {
                _saldoConto -= importoPrelievo;
            }
            else
            {
                Console.WriteLine("Saldo insufficiente. Prelievo non effettuato.");
            }
        }
    }
}



//Esercizio 2
//using System;
//using static System.Runtime.InteropServices.JavaScript.JSType;
//using System.Runtime.ConstrainedExecution;

//class Program
//{
//    static void Main()
//    {
//        // Chiedi all'utente la dimensione dell'array
//        Console.Write("Inserisci il numero di nomi: ");
//        int n = Convert.ToInt32(Console.ReadLine());

//        // Dichiarazione e inizializzazione dell'array
//        string[] nomi = new string[n];

//        // Caricamento dell'array con i nomi
//        for (int i = 0; i < n; i++)
//        {
//            Console.Write($"Inserisci il nome {i + 1}: ");
//            nomi[i] = Console.ReadLine();
//        }

//        // Chiedi all'utente il nome da cercare
//        Console.Write("Inserisci il nome da cercare: ");
//        string nomeDaCercare = Console.ReadLine();

//        // Cerca il nome nell'array
//        bool presente = false;
//        foreach (string nome in nomi)
//        {
//            if (nome.Equals(nomeDaCercare, StringComparison.OrdinalIgnoreCase))
//            {
//                presente = true;
//                break;
//            }
//        }

//        // Stampa il risultato
//        if (presente)
//        {
//            Console.WriteLine($"Il nome {nomeDaCercare} è presente nell'array.");
//        }
//        else
//        {
//            Console.WriteLine($"Il nome {nomeDaCercare} non è presente nell'array.");
//        }
//    }
//}


//using System;

//class Program
//{
//    static void Main()
//    {
//        // Chiedi all'utente la dimensione dell'array
//        Console.Write("Inserisci la dimensione dell'array: ");
//        int dimensione = int.Parse(Console.ReadLine());

//        // Chiama la funzione con la dimensione specificata
//        (int sommaTotale, double mediaAritmetica) = CalcolaSommaEMedia(dimensione);

//        // Stampare i risultati
//        Console.WriteLine("La somma di tutti i numeri è: " + sommaTotale);
//        Console.WriteLine("La media aritmetica è: " + mediaAritmetica);
//    }

//    static (int, double) CalcolaSommaEMedia(int arrayDimensione)
//    {
//        // Inizializza la somma a zero
//        int somma = 0;

//        // Chiedi all'utente di inserire gli elementi dell'array
//        for (int i = 0; i < arrayDimensione; i++)
//        {
//            // Input di un numero intero dall'utente
//            Console.Write("Inserisci il numero #" + (i + 1) + ": ");
//            int numero = int.Parse(Console.ReadLine());

//            // Aggiungi il numero alla somma
//            somma += numero;
//        }

//        // Calcola la media aritmetica
//        double media = (double)somma / arrayDimensione;

//        // Restituisci la somma e la media
//        return (somma, media);
//    }
//}
