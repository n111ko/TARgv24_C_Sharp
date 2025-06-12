﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_Sharp._3._osa___Kordused__massiivid_ja_klassid
{
    internal class ArvuTöötlus
    {
        public static (int[], int[]) GenereeriRuudud(int min, int max)
        {
            // генерируется два случайных числа в заданном диапазоне
            Random rnd = new Random();
            int N = rnd.Next(min, max);
            int M = rnd.Next(min, max);

            int väiksem, suurem;

            if (N < M)
            {
                väiksem = N;
                suurem = M;
            }
            else
            {
                väiksem = M;
                suurem = N;
            }

            /* создание двух массивов:
            - arvud для хранения исходных чисел (без -100 и 100)
            - ruudud для хранения квадратов этих чисел */
            int[] arvud = new int[suurem - väiksem - 1];
            int[] ruudud = new int[suurem - väiksem - 1];

            for (int i = 0; i < ruudud.Length; i++)
            {
                arvud[i] = väiksem + i + 1; // крайнее число пропускается, начинается со следующего
                ruudud[i] = arvud[i] * arvud[i]; // вычисление квадрата числа и сохранение
            }

            /* возвращение обоих массивов, потому что, если пытаться в Main найти исходное число через корень из квадрата, 
             будет невозможно определить знак исходного числа (отрицательное оно было или положительное) */
            return (ruudud, arvud);
        }
    }
}
