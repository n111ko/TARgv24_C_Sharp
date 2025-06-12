using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figgle;

namespace TARgv24_C_Sharp.Madu
{
    /* класс Levels — отображает меню выбора уровня сложности */
    public class LevelSelector
    {
        public string[] Levels { get; set; }
        public int SelectedLevel { get; set; }

        // конструктор
        public LevelSelector()
        {
            Levels = new string[] { "EASY", "MEDIUM", "HARD", "HELL" };
            SelectedLevel = 1; // значение по умолчанию
        }

        // метод для выбора уровня
        public void Choose()
        {
            string title = FiggleFonts.Standard.Render("SELECT LEVEL\n");
            int choice = Keyboard.ChooseOption(title, Levels);
            if (choice == 0)
            {
                SelectedLevel = 0; // если нажат ESC
            }
            else
            {
                SelectedLevel = choice;
            }
        }

        // метод для получения названия выбранного уровня
        public string GetSelectedLevelName()
        {
            return Levels[SelectedLevel - 1];
        }
    }
}
