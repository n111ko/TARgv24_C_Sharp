using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_Sharp._5._osa___Kollektsioonid._Listid_ja_sõnastikud
{
    internal class MainClass_ylesanne
    {
        public static void Main(string[] args)
        {
            /********************************************************************************/
            // Ülesanne 1 – Kalorite kalkulaator klassidega

            Console.WriteLine("--- Ülesanne 1 ---");
            List<Toode> tooted = new List<Toode>();

            tooted.Add(new Toode() { Nimi = "Õun", Kalorid100g = 52 });
            tooted.Add(new Toode() { Nimi = "Banaan", Kalorid100g = 89 });
            tooted.Add(new Toode() { Nimi = "Kartul", Kalorid100g = 77 });
            tooted.Add(new Toode() { Nimi = "Tomat", Kalorid100g = 18 });
            tooted.Add(new Toode() { Nimi = "Kurg", Kalorid100g = 16 });
            tooted.Add(new Toode() { Nimi = "Porgand", Kalorid100g = 41 });
            tooted.Add(new Toode() { Nimi = "Lõhe filee", Kalorid100g = 208 });
            tooted.Add(new Toode() { Nimi = "Kana muna", Kalorid100g = 155 });
            tooted.Add(new Toode() { Nimi = "Kanafilee", Kalorid100g = 165 });
            tooted.Add(new Toode() { Nimi = "Sealiha", Kalorid100g = 242 });
            tooted.Add(new Toode() { Nimi = "Veiseliha", Kalorid100g = 250 });
            tooted.Add(new Toode() { Nimi = "Keedetud riis", Kalorid100g = 130 });


            // Kasutaja andmed
            Console.Write("Sisestage oma nimi: ");
            string nimi = Console.ReadLine();
            Console.Write("Sisestage oma vanus: ");
            int vanus = int.Parse(Console.ReadLine());
            Console.Write("Sisestage sugu (mees/naine): ");
            string sugu = Console.ReadLine();
            Console.Write("Sisestage pikkus (cm): ");
            double pikkus = double.Parse(Console.ReadLine());
            Console.Write("Sisestage kaal (kg): ");
            double kaal = double.Parse(Console.ReadLine());
            Console.Write("-- Aktiivsus tasemed --\n1. Istuv eluviis\n2. Kerge aktiivsus\n3. Mõõdukas aktiivsus\n4. Väga aktiivne\n5. Äärmiselt aktiivne\nValige aktiivsustase (1-5): ");
            double aktiivsus = double.Parse(Console.ReadLine());

            Inimene inimene = new Inimene()
            {
                Nimi = nimi,
                Vanus = vanus,
                Sugu = sugu,
                Pikkus = pikkus,
                Kaal = kaal,
                Aktiivsustase = aktiivsus
            };

            // Päevase energiavajaduse arvutamine Harris-Benedict’i valemi abi
            // https://nutrium.com/blog/harris-benedict-equation-calculator-for-nutrition-professionals/

            double paevaneEnergiavajadus = Math.Round(inimene.ArvutaKalorivajadus(), 2);

            Console.WriteLine($"\n{nimi}, sinu hinnanguline päevane kalorivajadus on {paevaneEnergiavajadus} kcal\n");

            foreach (Toode t in tooted)
            {
                double kogus = Math.Round(paevaneEnergiavajadus / t.Kalorid100g * 100, 2);
                Console.WriteLine($"{t.Nimi}: {kogus} g päevas");
            }



            /********************************************************************************/
            // Ülesanne 2 – Maakonnad ja pealinnad (sõnastik ja test)

            Console.WriteLine("\n\n--- Ülesanne 2 ---");

            while (true)
            {
                Console.WriteLine("\n--- Maakonnad ja pealinnad ---");
                Console.WriteLine("1. Otsi maakonda või linna");
                Console.WriteLine("2. Lisa uus maakond");
                Console.WriteLine("3. Mängurežiim");
                Console.WriteLine("4. Kuvada kõik maakonnad ja pealinnad");
                Console.WriteLine("5. Välju");

                Console.Write("\nVali tegevus: ");
                string valik = Console.ReadLine();

                if (valik == "1")
                {
                    FunktsioonideClass_5osa.OtsiMaakondLinn();
                }
                else if (valik == "2")
                {
                    FunktsioonideClass_5osa.LisaUusMaakond();
                }
                else if (valik == "3")
                {
                    FunktsioonideClass_5osa.ManguReziim();
                }
                else if (valik == "4")
                {
                    FunktsioonideClass_5osa.KuvaKoik();
                }
                else if (valik == "5")
                {
                    Console.WriteLine("Head aega!");
                    break;  // выходим из цикла
                }
                else
                {
                    Console.WriteLine("Vale valik. Proovi uuesti.");
                }
            }



            /********************************************************************************/
            // Ülesanne 3 – Õpilased ja hinnete analüüs

            Console.WriteLine("\n\n--- Ülesanne 3 ---");

            // создание списка учеников
            List<Opilane> opilased = new List<Opilane>();

            Opilane o1 = new Opilane();
            o1.Nimi = "Maria";
            o1.Hinded = new List<int>();
            o1.Hinded.Add(5);
            o1.Hinded.Add(4);
            o1.Hinded.Add(5);

            Opilane o2 = new Opilane();
            o2.Nimi = "Andrei";
            o2.Hinded = new List<int>();
            o2.Hinded.Add(3);
            o2.Hinded.Add(4);
            o2.Hinded.Add(3);

            Opilane o3 = new Opilane();
            o3.Nimi = "Anna";
            o3.Hinded = new List<int>();
            o3.Hinded.Add(5);
            o3.Hinded.Add(5);
            o3.Hinded.Add(5);
            o3.Hinded.Add(4);

            // добавление всех учеников в список
            opilased.Add(o1);
            opilased.Add(o2);
            opilased.Add(o3);

            // сортировка учеников по средней оценке (убывание)
            opilased.Sort((x, y) => y.ArvutaKeskmine().CompareTo(x.ArvutaKeskmine()));

            // вывод имени каждого ученика и его средней оценки
            foreach (Opilane o in opilased)
            {
                Console.WriteLine($"{o.Nimi} keskmine hinne: {o.ArvutaKeskmine()}");
            }

            // поиск ученика с самой высокой средней оценкой
            Opilane parim = opilased[0]; // начинаем с первого ученика
            foreach (Opilane o in opilased)
            {
                if (o.ArvutaKeskmine() > parim.ArvutaKeskmine())
                {
                    parim = o; // обновление лучшего ученика
                }
            }

            Console.WriteLine($"\nKõrgeima keskmise hinde sai {parim.Nimi}: {parim.ArvutaKeskmine()}");


            Console.ReadKey();
        }
    }
}