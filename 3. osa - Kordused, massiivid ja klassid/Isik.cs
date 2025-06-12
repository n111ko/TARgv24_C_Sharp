﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_Sharp._3._osa___Kordused__massiivid_ja_klassid
{
    internal enum Sugu
    {
        Mees,
        Naine
    }

    internal class Isik
    {
        public string Nimi { get; set; }
        public int Vanus { get; set; } = 18;
        public string Isikukood { get; set; }
        public string Aadress { get; set; }
        public Sugu Sugu { get; set; } = Sugu.Mees;
        public Isik() { }
        public Isik(string nimi)
        {
            Nimi = nimi;
        }
        public Isik(string nimi, int vanus, string isikukood, string aadress) // Sugu sugu
        {
            Nimi = nimi;
            Vanus = vanus;
            Isikukood = isikukood;
            Aadress = aadress;
        }
        public void PrindiInfo()
        {
            Console.WriteLine($"Nimi: {Nimi}, Vanus: {Vanus}, Isikukood: {Isikukood}, Aadress: {Aadress}, Sugu:{Sugu}\n");
        }
    }
}
