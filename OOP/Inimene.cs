﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_Sharp.OOP
{
    public class Inimene
    {
        public string Nimi;
        public int Vanus;

        public void Tervita()
        {
            Console.WriteLine("Tere! Mina olen " + Nimi);
        }
    }
}
