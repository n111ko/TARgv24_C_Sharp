﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_Sharp._3._osa___Kordused__massiivid_ja_klassid
{
    internal class MainClass_3osa
    {
        public static void Main(string[] args)
        {
            // III. osa Kordused, Massivid, Listid, Klassid

            Isik isik1 = new Isik("Juku", 18, "12345678901", "Tallinn");
            isik1.PrindiInfo();
            Isik isik2 = new Isik();
            isik2.Nimi = "Mari";
            isik2.Aadress = "Tartu";
            isik2.Isikukood = "98765432101";
            isik2.Sugu = Sugu.Naine;
            isik2.PrindiInfo();


            int i;
            string[] nimed = new string[10] { "Juku", "Mari", "Kati", "Peeter", "Mati", "Liina", "Katrin", "Andres", "Marko", "Kristi" };
            string[] aadressid = new string[10] { "Tallinn", "Tartu", "Pärnu", "Narva", "Kohtla-Järve", "Viljandi", "Rakvere", "Paide", "Jõhvi", "Kuressaare" };
            Console.WriteLine("----- for++ Massiv -------");
            Isik[] isikud = FunktsioonideClass_3osa.Isikud(nimed.Length, nimed, aadressid);
            for (i = 0; i < nimed.Length; i++)
            {
                isikud[i].PrindiInfo();
            }

            Console.WriteLine("----- for-- List -------");
            List<Isik> isikud2 = FunktsioonideClass_3osa.Isikud2(nimed.Length, nimed, aadressid);

            foreach (Isik isik in isikud2)
            {
                isik.PrindiInfo();
            }


            Console.WriteLine("--------- while ----------");
            while (i>=0)
            {
                Console.WriteLine(i);
                i--;
            }
            Console.WriteLine("--------- do ----------");
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                Console.WriteLine("Väljuta Backspace");
                key= Console.ReadKey();
            }
            while (key.Key!=ConsoleKey.Backspace);


            Console.ReadKey();
        }
    }
}
