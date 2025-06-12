﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figgle; // библиотека для вывода текста в стиле ASCII

namespace TARgv24_C_Sharp.Madu
{
    /* класс Menu отвечает за отображение главного меню игры "Змейка" и обработку выбора игрока */
    public class Menu
    {
        private static string[] options = { "PLAY", "LEADERBOARD", "SETTINGS", "EXIT" }; // варианты меню


        public static void ShowFullMenu(Sounds sounds)
        {
            while (true)
            {
                Console.Clear();
                int menuChoice = MenuChoice(); // отображение меню каждый раз

                if (menuChoice == 1) // Play
                {
                    Game game = new Game(sounds);
                    game.Start();
                }
                else if (menuChoice == 2) // Leaderboard
                {
                    Score.showLeaderoard();
                }
                else if (menuChoice == 3) // Settings
                {
                    Settings.ShowSettings();
                }
                else if (menuChoice == 4) // Exit
                {
                    Environment.Exit(0); // полностью завершаем программу
                }
            }
        }

        // метод для отображения меню и обработки выбора игрока
        public static int MenuChoice()
        {
            string title = FiggleFonts.Standard.Render("Snake Game");
            return Keyboard.ChooseOption(title, options); // вызов метода выбора опции
        }
    }
}
