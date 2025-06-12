using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_Sharp.Madu
{
    /* класс Keyboard отвечает за обработку нажатий клавиш и выбор пунктов меню */ 
    public static class Keyboard
    {
        public static int ChooseOption(string title, string[] options)
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear(); // очистка экрана каждый раз для обновления меню

                // Выводим заголовок
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.WriteLine(title);
                Console.WriteLine();

                // вывод списка опций
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex) // если это выбранный пункт
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"[ {options[i]} ]\n"); // текущий выбранный пункт
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine($"  {options[i]}\n"); // остальные пункты обычным цветом
                    }
                }

                Console.ResetColor();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // считывание нажатой клавиши
                key = keyInfo.Key; // сохранение нажатой клавиши

                // обработка нажатия стрелок
                if (key == ConsoleKey.UpArrow) // стрелка вверх
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1; // если вышли за верхний предел — переход в конец
                    }
                }
                else if (key == ConsoleKey.DownArrow) // стрелка вниз
                {
                    selectedIndex++;
                    if (selectedIndex >= options.Length)
                    {
                        selectedIndex = 0; // если вышли за нижний предел — переход в начало
                    }
                }
                else if (key == ConsoleKey.Escape)
                {
                    return 0; // при ESC возвращается 0
                }

            } while (key != ConsoleKey.Enter); // продолжение пока не нажата Enter

            return selectedIndex + 1; // возвращение 1, 2, 3 и т.д.
        }


        // метод для ожидания нажатия ESC
        public static void WaitForEsc()
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}
