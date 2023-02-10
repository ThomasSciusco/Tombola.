using System;
using System.Threading;
namespace Tombola //Thomas Sciusco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, x, y = 2;
            Random ran = new Random();
            bool[] v = new bool[90];
            int car1 = 0, car2 = 0;
            int[,] cart1 = new int[9, 3];
            int[,] cart2 = new int[9, 3];
            Console.WriteLine("Inizio gioco: ");
            Console.ReadKey();
            Console.WriteLine(" ");
            Console.WriteLine("Tabellone: ");



            for (int i = 0; i < 9; i++)                         //stampa colonna del tabellone
            {
                x = 13;

                for (int j = 0; j < 10; j++)                    //stampa riga del tabellone
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" |");
                    x += 3;
                }
                y++;
            }

            Cart1();                                            //generazione numeri cartella1
            Cart2();                                            //generazione numeri cartella1  
            Scart1();                                           //stampa cartella1
            Scart2();                                           //stampa cartella2



            for (int i = 0; i < 90; i++)                        //ciclo di estrazione e controllo 
            {
                num = estrazione();
                x = Coordx();
                y = Coordy();
                for (int j = 0; j < 3; j++)                      //stampa del numero sul tabellone
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(num);
                    Thread.Sleep(300);
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(num);
                    Thread.Sleep(300);
                }
                Ecart1();                                       //estrazione e vincita cartella1
                Ecart2();                                       //estrazione e vincita cartella2
                Thread.Sleep(400);
            }
            int estrazione()
            {
                int n;
                do
                {
                    n = ran.Next(1, 91);
                } while (v[n - 1] == true);                       //verifica che il numero non sia ancora uscito
                v[n - 1] = true;
                return n;
            }
            int Coordx()
            {
                if (num / 10 == 0)
                {
                    x = 11 + (num % 10 * 3);                      //calcolo della x se la condizione è verificata
                }
                else
                {
                    if (num % 10 != 0)
                    {
                        x = 11 + (num % 10 * 3 - 1);
                    }
                    else
                    {
                        x = 11 + num / (num / 10) * 3 - 1;
                    }
                }
                return x;
            }
            int Coordy()
            {
                if (num / 10 == 0)
                {
                    y = 2;                                        //calcolo della y se la condizione è verificata
                }
                else
                {
                    if (num % 10 != 0)
                    {
                        y = 2 + num / 10;
                    }
                    else
                    {
                        y = 1 + num / 10;
                    }
                }
                return y;

            }
            int Cart1()                                          //funzione caricamento della matrice cartella1
            {

                bool[] cartv = new bool[90];                     //dichiarazione array di 90 elementi 
                int numr;
                for (int k = 0; k < 3; k++)
                {
                    bool[] decv = new bool[10];                 //dichiarazione di un array di 10 elementi 
                    for (int j = 0; j < 5; j++)                       //ciclo che identifica i numeri da generare per ogni riga
                    {
                        do
                        {
                            numr = ran.Next(1, 91);             //estrazione numero casuale tra 1 e 90
                        }
                        while (cartv[numr - 1] == true || decv[numr / 10] == true);
                        cartv[numr - 1] = true;
                        decv[numr / 10] = true;
                        if (numr == 90)
                        {
                            cart1[8, k] = 90;
                        }
                        else
                        {
                            cart1[numr / 10, k] = numr;
                        }
                    }
                    for (int i = 0; i < 9; i++)
                    {
                        decv[i] = false;
                    }
                }
                return 0;
            }
            int Cart2()                                         //funzione di caricamento della matrice della seconda cartella
            {

                bool[] cartv = new bool[90];                    //dichiarazione di un array di 90 elementi 
                int numr;
                for (int k = 0; k < 3; k++)
                {
                    bool[] decv = new bool[10];                //dichiarazione di un array di 10 elementi 
                    for (int j = 0; j < 5; j++)                //ciclo che identifica i numeri da generare per ogni riga
                    {
                        do
                        {
                            numr = ran.Next(1, 91);           //estrazione numero casuale tra 1 e 90
                            if (numr == 90)
                            {
                                j--;
                            }
                        } while (cartv[numr - 1] == true || decv[numr / 10] == true);
                        cartv[numr - 1] = true;
                        decv[numr / 10] = true;
                        if (numr == 90)
                        {
                            cart2[8, k] = 90;
                        }
                        else
                        {
                            cart2[numr / 10, k] = numr;
                        }
                    }
                    for (int i = 0; i < 9; i++)
                    {
                        decv[i] = false;
                    }
                }
                return 0;
            }
            void Scart1()                                   //funzione stampa cartella1
            {
                x = 0;
                y = 12;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("Cartella 1: ");
                y++;
                for (int i = 0; i < 5; i++)                 //stampa righe cartella1
                {
                    x = 0;
                    y++;

                    if (i % 2 == 1)

                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("-------------------------");
                    }
                    else
                    {

                        Console.SetCursorPosition(x, y);
                        for (int j = 0; j < 9; j++)         //ciclo per scrivere i numeri o gli spazi 
                        {
                            if (cart1[j, i / 2 + i % 2] != 0)      //condizione che verifica se è necessario stampare un numero o lo spazio

                            {

                                Console.Write($"{cart1[j, i / 2 + i % 2]} "); //stampa del numero 

                            }

                            else

                            {
                                if (j == 0)            //condizione che verifica se il numero da stampare occupa 1 spazio
                                {
                                    Console.Write("  ");
                                }
                                else
                                {
                                    Console.Write("   ");
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            void Scart2()                               //funzione stampa cartella2
            {
                x = 30;
                y = 12;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("Cartella 2: ");
                y++;
                for (int i = 0; i < 5; i++)
                {
                    x = 30;
                    y++;
                    if (i % 2 == 1)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("-------------------------");
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);
                        for (int j = 0; j < 9; j++)
                        {
                            if (cart2[j, i / 2 + i % 2] != 0)
                            {
                                Console.Write($"{cart2[j, i / 2 + i % 2]} ");
                            }
                            else
                            {
                                if (j == 0)
                                {
                                    Console.Write("  ");
                                }
                                else
                                {
                                    Console.Write("   ");
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            int Ecart1()                                    //funzione estrazione e vincita
            {
                x = 0;
                y = 14;
                for (int k = 0; k < 3; k++)                 //ciclo che identifica le righe della cartella
                {
                    for (int j = 0; j < 9; j++)             // identifica ogni numero nella riga
                    {
                        if (cart1[j, k] == num)            // verifica presenza del numero estratto
                        {
                            if (j == 0)
                            {
                                x = 0;
                            }
                            else
                            {
                                x += j * 3 - 1;
                            }
                            y += k * 2;
                            car1++;
                            Console.SetCursorPosition(x, y);
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.Write(num);
                            Console.BackgroundColor = ConsoleColor.Black;
                            if (car1 == 15)
                            {
                                Console.SetCursorPosition(0, 20);
                                Console.Write("Il primo giocatore ha fatto tombola!!!");
                                Console.SetCursorPosition(1, 1);
                                Environment.Exit(1);
                            }
                        }
                    }
                }
                return car1;
            }
            int Ecart2()                                    //funzione estrazione e vincita
            {
                x = 30;
                y = 14;
                for (int k = 0; k < 3; k++)                 //ciclo che identifica le righe della cartella1
                {
                    for (int j = 0; j < 9; j++)            // identifica ogni numero nella riga
                    {
                        if (cart2[j, k] == num)             // verifica presenza del numero estratto
                        {
                            if (j == 0)
                            {
                                x = 30;
                            }
                            else
                            {
                                x += j * 3 - 1;
                            }
                            y += k * 2;
                            car2++;
                            Console.SetCursorPosition(x, y);
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(num);
                            Console.BackgroundColor = ConsoleColor.Black;
                            if (car2 == 15)
                            {
                                Console.SetCursorPosition(30, 20);
                                Console.Write("Il secondo giocatore ha fatto tombola!!!");
                                Console.SetCursorPosition(1, 1);
                                Environment.Exit(1);        //chiusura programma
                            }
                        }
                    }
                }
                return car2;
            }
        }
    }
}

