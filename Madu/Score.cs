using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24_C_Sharp.Madu
{
    /* класс Score отвечает за ведение счёта в игре.
     он хранит имя игрока и количество очков, а также предоставляет методы для добавления очков,
     отображения счёта, сохранения результатов в файл, сортировки и вывода таблицы лидеров на экран */
    internal class Score
    {
        public string PlayerName { get; set; } // имя игрока
        public int Points { get; set; } // количество очков
        public string filePath;

        // конструктор класса Score
        public Score(string playerName)
        {
            PlayerName = playerName;
            Points = 0;

            Params p = new Params();
            filePath = Path.Combine(p.GetResourceFolder(), "results.txt");
            Draw();
        }


        // метод для добавления очков 
        public void Add(int pointsAmount)
        {
            Points += pointsAmount; // добавляем очки
            Draw();
        }


        // метод для отображения очков в консоли
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // красный цвет текста
            Console.SetCursorPosition(0, 0); // позиция курсора
            Console.Write($"Score: {Points} ");
            Console.ResetColor(); // возвращение стандартного цвета текста
        }


        // метод для сохранения результата в файл
        public void Save()
        {
            List<Score> players = new List<Score>(); // создание списка игроков
            bool updated = false; // флажок: обновили ли результат игрока

            // чтение всех строк из файла
            string[] lines = File.ReadAllLines(filePath);

            // перебор всех строки
            foreach (string line in lines)
            {
                string[] parts = line.Split(':'); // разделение строки на имя и очки
                if (parts.Length == 2)
                {
                    string nimi = parts[0]; // имя игрока
                    int punktid = int.Parse(parts[1]); // очки игрока

                    // добавление игрока в список
                    players.Add(new Score(nimi) { Points = punktid });
                }
            }

            // поиск, есть ли уже игрок с таким именем
            foreach (Score player in players)
            {
                if (player.PlayerName == PlayerName)
                {
                    // если новые очки больше старых - обновление
                    if (Points > player.Points)
                    {
                        player.Points = Points;
                    }
                    updated = true; // игрок найден
                    break;
                }
            }

            // если игрока не нашли — добавление нового
            if (!updated)
            {
                players.Add(new Score(PlayerName) { Points = Points });
            }

            // сортировка списка по очкам от большего к меньшему
            players.Sort((a, b) => b.Points.CompareTo(a.Points));

            // перезаписывание файла новыми строками
            using (StreamWriter scoreBoard = new StreamWriter(filePath)) 
            {
                foreach (Score player in players)
                {
                    scoreBoard.WriteLine(player.PlayerName + ":" + player.Points);
                }
            }
        }


        // метод для показа таблицы лидеров
        public static void showLeaderoard()
        {
            try
            {
                // чтение и заполнение словаря
                Params p = new Params();
                string path = Path.Combine(p.GetResourceFolder(), "results.txt");

                string[] lines = File.ReadAllLines(path); // чтение строки из файла

                // вывод отсортированных результатов
                Console.Clear();
                int xOffset = 25;
                int yOffset = 8;
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.SetCursorPosition(xOffset, yOffset++);
                Game.WriteText("============================", xOffset, yOffset++);
                Game.WriteText("     TULEMUSED", xOffset + 5, yOffset++); // заголовок по центру
                yOffset++; // отступ

                foreach (var line in lines)
                {
                    Game.WriteText(line, xOffset + 10, yOffset++); // вывод результатов
                }

                Game.WriteText("============================", xOffset, yOffset++);
                yOffset += 5;
                Game.WriteText("Press ESC to return to MENU", xOffset, yOffset++);
                Console.ResetColor(); // вернуть обычный цвет
                Keyboard.WaitForEsc(); // ожидание нажатия ESC
            }
            catch (Exception)
            {
                Console.WriteLine("Viga tulemuste lugemisel.");
            }
        }
    }
}
