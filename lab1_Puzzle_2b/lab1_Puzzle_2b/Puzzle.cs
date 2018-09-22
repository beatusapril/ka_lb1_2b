using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace lab1_Puzzle_2b
{
    class Puzzle
    {
        private LinkedList<Detail> listDetails;  // список деталей
        private int[] perm;  // массив номеров элементов 
        private int countColomns;  // количество столбцов
        private int countLines; // количество строк
        private int countElem; // кол-во элементов
        private MyColor[] matrix;  // матрица цветов
        public  Graphics gr; // полотно

        // координаты позиций
        private static int finishX = -10;
        private static int startX = 300;

        private static int finishY = 40;
        private static int startY = 40;

        private static int step = 50;

        public Puzzle(int _countColomns, int _countLines, Graphics _gr)
        {
            this.countColomns = _countColomns;
            this.countLines = _countLines;
            countElem = _countColomns * _countLines;
            this.gr = _gr;
            initMatrixColor();
            listDetails = new LinkedList<Detail>();
            listDetails.AddLast(new Detail(MyColor.GREEN, TypeSide.SQUARE_SIDE, TypeSide.STRAIGHT_SIDE, TypeSide.SQUARE_SIDE, TypeSide.STRAIGHT_SIDE, "../../images/8.png", gr));  // 8
            listDetails.AddLast(new Detail(MyColor.GREEN, TypeSide.REVERSE_SQUARE_SIDE, TypeSide.STRAIGHT_SIDE, TypeSide.STRAIGHT_SIDE, TypeSide.TRIANGLE_SIDE, "../../images/3.png", gr));  // 3
            listDetails.AddLast(new Detail(MyColor.BLUE, TypeSide.STRAIGHT_SIDE, TypeSide.STRAIGHT_SIDE, TypeSide.REVERSE_TRIANGLE_SIDE, TypeSide.SQUARE_SIDE, "../../images/6.png", gr));  // 6
            listDetails.AddLast(new Detail(MyColor.BLUE, TypeSide.REVERSE_TRIANGLE_SIDE, TypeSide.SQUARE_SIDE, TypeSide.STRAIGHT_SIDE, TypeSide.STRAIGHT_SIDE, "../../images/2.png", gr));  // 2
            listDetails.AddLast(new Detail(MyColor.RED, TypeSide.STRAIGHT_SIDE, TypeSide.TRIANGLE_SIDE, TypeSide.STRAIGHT_SIDE, TypeSide.REVERSE_SQUARE_SIDE, "../../images/1.png", gr));  // 1
            listDetails.AddLast(new Detail(MyColor.RED, TypeSide.STRAIGHT_SIDE, TypeSide.STRAIGHT_SIDE, TypeSide.REVERSE_SQUARE_SIDE, TypeSide.STRAIGHT_SIDE, "../../images/9.png", gr));  // 9
            listDetails.AddLast(new Detail(MyColor.GREEN, TypeSide.STRAIGHT_SIDE, TypeSide.STRAIGHT_SIDE, TypeSide.SQUARE_SIDE, TypeSide.REVERSE_TRIANGLE_SIDE, "../../images/4.png", gr));  // 4
            listDetails.AddLast(new Detail(MyColor.RED, TypeSide.STRAIGHT_SIDE, TypeSide.REVERSE_SQUARE_SIDE, TypeSide.TRIANGLE_SIDE, TypeSide.STRAIGHT_SIDE, "../../images/7.png", gr));  // 7
            listDetails.AddLast(new Detail(MyColor.RED, TypeSide.STRAIGHT_SIDE, TypeSide.STRAIGHT_SIDE, TypeSide.STRAIGHT_SIDE, TypeSide.REVERSE_SQUARE_SIDE, "../../images/5.png", gr));  // 5
        }

        /// <summary>
        /// Инициализация массива цветов
        /// </summary>
        private void initMatrixColor()
        {
            matrix = new MyColor[countColomns * countLines];
            matrix[0] = MyColor.RED;
            matrix[1] = MyColor.BLUE;
            matrix[2] = MyColor.GREEN;
            matrix[3] = MyColor.GREEN;
            matrix[4] = MyColor.RED;
            matrix[5] = MyColor.BLUE;
            matrix[6] = MyColor.RED;
            matrix[7] = MyColor.GREEN;
            matrix[8] = MyColor.RED;
        }

        /// <summary>
        /// Поиск верной комбинации.
        /// </summary>
        /// <returns></returns>
        public bool start()
        {
            Permutator pr = new Permutator(countElem);
            while (pr.hasNext())
            {
                perm = pr.next();
                for (int i = 0; i < perm.Length; i++)
                {
                    --perm[i];
                }
                if (check())
                {
                    drawPuzzleFinish();
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Отрисовка собранного пазла.
        /// </summary>
        public void drawPuzzleFinish()
        {
            int x = finishX;
            int y = finishY;
            for (int i = 0, j = 1; i < listDetails.Count; i++)
            {
                x += step;
                if ((i != 0) && ((i % countColomns) == 0))
                {
                    j++;
                    y += step;
                    x = finishX+step;

                }
                listDetails.ElementAt(perm[i]).drawDetail(x, y, gr);
            }
        }


        /// <summary>
        /// Отрисовка несобранного пазла.
        /// </summary>
        public void drawPuzzleStart()
        {
            int x = startX;
            int y = startY;
            for (int i = 0, j = 1; i < listDetails.Count; i++)
            {
                x += step;
                if ((i != 0) && ((i % countColomns) == 0))
                {
                    j++;
                    y += step;
                    x = startX + step;

                }
                listDetails.ElementAt(i).drawDetail(x, y, gr);
            }
        }


        /// <summary>
        /// Проверка деталей, полученной перестановки.
        /// </summary>
        /// <returns></returns>
        public bool check()
        {
            bool result = true;
            for (int i = 0; i < perm.Length; i++)
            {
                if (!checkDetails(i))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// Проверка детали.
        /// </summary>
        /// <param name="id">индекс в массиве полученной перестановки</param>
        /// <returns></returns>
        public bool checkDetails(int id)
        {
            if (listDetails.ElementAt(perm[id]).Color != matrix[id])
                return false;
            if ((id >= 0) && (id < countColomns))
            {
                if (listDetails.ElementAt(perm[id]).UpSide != TypeSide.STRAIGHT_SIDE)
                    return false;
                if ((id >= 1) && (!Detail.equalsToPuzzle(listDetails.ElementAt(perm[id]).LeftSide, listDetails.ElementAt(perm[id - 1]).RightSide)))
                    return false;
            }

            if ((id >= (countElem - countColomns)) && (id < countElem))
            {
                if (listDetails.ElementAt(perm[id]).DownSide != TypeSide.STRAIGHT_SIDE)
                    return false;
            }
            if (id == 0)
            {
                if (listDetails.ElementAt(perm[id]).LeftSide != TypeSide.STRAIGHT_SIDE)
                    return false;
            }

            if (id == (countElem - 1))
            {
                if (listDetails.ElementAt(perm[id]).RightSide != TypeSide.STRAIGHT_SIDE)
                    return false;
            }

            if ((id >= countColomns) && (id < countElem))
            {
                if (!Detail.equalsToPuzzle(listDetails.ElementAt(perm[id]).LeftSide, listDetails.ElementAt(perm[id - 1]).RightSide))
                    return false;
                if (!Detail.equalsToPuzzle(listDetails.ElementAt(perm[id]).UpSide, listDetails.ElementAt(perm[id - countColomns]).DownSide))
                    return false;
            }
            return true;

        }

    }   
}
