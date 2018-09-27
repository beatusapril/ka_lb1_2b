using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab1_Puzzle_2b
{
    /// <summary>
    /// Цвет.
    /// </summary>
    public enum MyColor
    {
        RED,
        GREEN,
        BLUE
    }

    /// <summary>
    /// Тип сторона.
    /// </summary>
    public enum TypeSide
    {
        STRAIGHT_SIDE = 0,
        TRIANGLE_SIDE = 1,
        REVERSE_TRIANGLE_SIDE = -1,
        SQUARE_SIDE = 2,
        REVERSE_SQUARE_SIDE = -2,
        NONE_SIDE = -3
    }


    class Detail
    {
        private MyColor color;  // цвет
        private TypeSide leftSide; // тип левой стороны
        private TypeSide rightSide; // тип правой стороны
        private TypeSide upSide; // тип верхней стороны
        private TypeSide downSide; // тип нижней стороны

        private Graphics gr; // полотно

        private static int width = 50;  // ширина
        private static int height = 50; // высота

        public Detail(MyColor color, TypeSide leftSide, TypeSide rightSide, TypeSide upSide, TypeSide downSide, Graphics gr)
        {
            this.color = color;
            this.leftSide = leftSide;
            this.rightSide = rightSide;
            this.upSide = upSide;
            this.downSide = downSide;
            this.gr = gr;
        }

        /// <summary>
        /// Свойства (геттеры)
        /// </summary>
        public TypeSide LeftSide { get { return leftSide; } }
        public TypeSide RightSide { get { return rightSide; } }
        public TypeSide UpSide { get { return upSide; } }
        public TypeSide DownSide { get { return downSide; } }
        public MyColor YourColor { get { return color; } }
        public static int Width { get { return width; } }

        /// <summary>
        /// Метод отрисовки прямоугольника
        /// </summary>
        /// <param name="X">Координата X </param>
        /// <param name="Y">Координата Y</param>
        /// <param name="p">Полотно</param>
        /// <param name="myc">Цвет</param>
        public static void drawPol(int X, int Y, Graphics p, MyColor myc)
        {
            // Перевод цвета
            SolidBrush brush = new SolidBrush(Color.Blue);
            switch (myc)
            {
                case MyColor.BLUE:
                    brush = new SolidBrush(Color.FromArgb(28, 89, 195));
                    break;
                case MyColor.GREEN:
                    brush = new SolidBrush(Color.FromArgb(63, 168, 18));
                    break;
                case MyColor.RED:
                    brush = new SolidBrush(Color.FromArgb(249, 48, 142));
                    break;
            }
            Rectangle rect = new Rectangle(X, Y, width, height);
            p.FillRectangle(brush, rect);
            p.DrawRectangle(Pens.Black, rect);
        }

        /// <summary>
        /// Отрисовка детали.
        /// </summary>
        /// <param name="X">Координата X</param>
        /// <param name="Y">Кооординат Y</param>
        /// <param name="p">Полотно</param>
        public void drawDetail(int X, int Y, Graphics p)
        {
            drawPol(X, Y, p, color);
            p.DrawLine(Pens.Black, X, Y, X + 50, Y + 50);// рисуем линию
            p.DrawLine(Pens.Black, X, Y + 50, X + 50, Y);// рисуем линию
            drawNumber(X + 20, Y + 2, upSide, p);
            drawNumber(X + 2, Y + 20, leftSide, p);
            drawNumber(X + 20, Y + 36, downSide, p);
            drawNumber(X + 36, Y + 20, rightSide, p);
        }

        /// <summary>
        /// Отрисовка номера (по 1 на каждую грань)
        /// </summary>
        /// <param name="_X">Координата X</param>
        /// <param name="_Y">Координата Y</param>
        /// <param name="type">Тип грани</param>
        /// <param name="p">Полотно</param>
        private void drawNumber(int _X, int _Y, TypeSide type, Graphics p)
        {
            p.DrawString(((int)type).ToString(), mnForm.DefaultFont, new SolidBrush(Color.Black), _X, _Y);
        }
        /// <summary>
        /// Сравнение граней пазлов (они должны быть противоположными)
        /// </summary>
        /// <param name="tpOne">Грань 1</param>
        /// <param name="tpTwo">грань 2</param>
        /// <returns>Результат сравнения</returns>
        public static bool equalsToPuzzle(TypeSide tpOne, TypeSide tpTwo)
        {
            bool result = false;
            switch (tpOne)
            {
                case TypeSide.SQUARE_SIDE:
                    result = (tpTwo == TypeSide.REVERSE_SQUARE_SIDE);
                    break;
                case TypeSide.REVERSE_SQUARE_SIDE:
                    result = (tpTwo == TypeSide.SQUARE_SIDE);
                    break;
                case TypeSide.REVERSE_TRIANGLE_SIDE:
                    result = (tpTwo == TypeSide.TRIANGLE_SIDE);
                    break;
                case TypeSide.TRIANGLE_SIDE:
                    result = (tpTwo == TypeSide.REVERSE_TRIANGLE_SIDE);
                    break;
                case TypeSide.STRAIGHT_SIDE:
                    result = (tpTwo == TypeSide.STRAIGHT_SIDE);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Получение противоположной грани (для рандомной генерации пазла).
        /// </summary>
        /// <param name="type">Тип грани</param>
        /// <returns>Противоположный тип грани.</returns>
        public static TypeSide reverseSide(TypeSide type)
        {
            TypeSide result = TypeSide.NONE_SIDE;
            switch (type)
            {
                case TypeSide.SQUARE_SIDE:
                    result = TypeSide.REVERSE_SQUARE_SIDE;
                    break;
                case TypeSide.REVERSE_SQUARE_SIDE:
                    result = TypeSide.SQUARE_SIDE;
                    break;
                case TypeSide.REVERSE_TRIANGLE_SIDE:
                    result = TypeSide.TRIANGLE_SIDE;
                    break;
                case TypeSide.TRIANGLE_SIDE:
                    result = TypeSide.REVERSE_TRIANGLE_SIDE;
                    break;
                case TypeSide.STRAIGHT_SIDE:
                    result = TypeSide.STRAIGHT_SIDE;
                    break;
            }
            return result;
        }
    }
}
