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
        REVERSE_SQUARE_SIDE = -2
    }

    class Detail
    {
        private MyColor color;  // цвет
        private TypeSide leftSide; // тип левой стороны
        private TypeSide rightSide; // тип правой стороны
        private TypeSide upSide; // тип верхней стороны
        private TypeSide downSide; // тип нижней стороны
        private Image img;  // картинка

        private string addressImage; // адрес картинки
        private Graphics gr; // полотно

        private static int width = 50;  // ширина
        private static int height = 50; // высота

        public Detail(MyColor color, TypeSide leftSide, TypeSide rightSide, TypeSide upSide, TypeSide downSide, string addressImage, Graphics gr)
        {
            this.color = color;
            this.leftSide = leftSide;
            this.rightSide = rightSide;
            this.upSide = upSide;
            this.downSide = downSide;
            this.addressImage = addressImage;
            this.img = Image.FromFile(addressImage);
            this.gr = gr;
        }

        public TypeSide LeftSide { get { return leftSide; } }
        public TypeSide RightSide { get { return rightSide; } }
        public TypeSide UpSide { get { return upSide; } }
        public TypeSide DownSide { get { return downSide; } }
        public MyColor Color { get { return color; } }

        /// <summary>
        /// Отрисовка детали.
        /// </summary>
        /// <param name="X">координата x</param>
        /// <param name="Y">координата x полотно</param>
        /// <param name="p"> полотно</param>
        public void drawDetail(int X, int Y, Graphics p)
        {
            p.DrawImage(img, X, Y, width, height);
        }

        public static bool equalsToPuzzle(TypeSide tpOne, TypeSide tpTwo)
        {
            bool result = false;
            switch(tpOne)
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

    }
}
