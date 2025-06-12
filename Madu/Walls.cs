using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARgv24_C_Sharp.Madu;

namespace TARgv24_C_Sharp.Madu
{
    // класс Walls отвечает за создание и отрисовку стен, а также проверку столкновений с ними
    class Walls
    {
        List<Figure> wallList; // список фигур
        private bool isHardLevel; // флажок: есть ли сложные стены внутри

        public Walls(int mapWidth, int mapHeight, bool hardLevel = false) // принимает габариты карты
        {
            wallList = new List<Figure>();

            // отрисовка рамочки
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '-');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '-');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '|');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '|');

            // принцип полиморфизма (в список с фигурами добавляются объекты наследников)
            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);

            if (hardLevel)
            {
                AddHardLevelWalls();
            }
        }

        // добавление стен для сложного уровня
        private void AddHardLevelWalls()
        {
            // создание дополнительных стен внутри карты
            wallList.Add(new HorizontalLine(20, 30, 6, 'X'));
            wallList.Add(new HorizontalLine(50, 60, 6, 'X'));
            wallList.Add(new HorizontalLine(20, 30, 18, 'X'));
            wallList.Add(new HorizontalLine(50, 60, 18, 'X'));
            wallList.Add(new VerticalLine(10, 16, 40, 'X'));
        }


        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}