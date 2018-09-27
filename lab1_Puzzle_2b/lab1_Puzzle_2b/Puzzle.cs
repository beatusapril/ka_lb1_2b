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
        private Detail[] arrayDetails;  // массив деталей
        private int[] perm;  // массив номеров элементов (в который заносится текущая перестановка)
        private int countColomns;  // количество столбцов
        private int countLines; // количество строк
        private int countElem; // кол-во элементов
        private MyColor[] matrColor;  // матрица цветов
        public Graphics gr; // полотно

        private Random rand = new Random();

        private static int step = 50;

        public Puzzle(int _countColomns, int _countLines, Graphics _gr)
        {
            countColomns = _countColomns;
            countLines = _countLines;
            countElem = _countColomns * _countLines;
            gr = _gr;
            arrayDetails = new Detail[countElem];
            initMatrixColor();
        }

        /// <summary>
        /// Инициализация массива цветов
        /// </summary>
        private void initMatrixColor()
        {
            matrColor = new MyColor[countElem];
            for (int i = 0; i < countElem; i++)
                matrColor[i] = (MyColor)rand.Next(0, 3);

        }
        /// <summary>
        /// Отрисовка матрицы цветов.
        /// </summary>
        /// <param name="startx">Начальная координата X</param>
        /// <param name="starty">Начальная координата Y</param>
        public void drawMatrix(int startx, int starty)
        {
            for (int i = 0, j = 1, k = 1; i < countElem; i++, k++)
            {
                if ((i != 0) && ((i % countColomns) == 0))
                {
                    j++;
                    k = 1;
                }
                Detail.drawPol(startx + k * 50, starty + j * 50, gr, matrColor[i]);
            }
        }
        /// <summary>
        /// Рандомная генерация правильного пазла. Потом его надо перемешать.
        /// </summary>
        public void randomGeneratePuzzle()
        {
            for (int i = 0; i < countElem; i++)
            {
                TypeSide leftSide = TypeSide.NONE_SIDE; // тип левой стороны
                TypeSide rightSide = TypeSide.NONE_SIDE;  // тип правой стороны
                TypeSide upSide = TypeSide.NONE_SIDE;  // тип верхней стороны
                TypeSide downSide = TypeSide.NONE_SIDE;  // тип нижней стороны
                if ((i >= 0) && (i < countColomns))
                    upSide = TypeSide.STRAIGHT_SIDE;
                if ((i >= (countElem - countColomns)) && (i < countElem))
                    downSide = TypeSide.STRAIGHT_SIDE;
                if ((i % countColomns) == 0)
                    leftSide = TypeSide.STRAIGHT_SIDE;
                if ((i % countColomns) == (countColomns - 1))
                    rightSide = TypeSide.STRAIGHT_SIDE;
                if ((i == 0))
                {
                    if (rightSide == TypeSide.NONE_SIDE)
                        rightSide = (TypeSide)rand.Next(-2, 2);
                    if (downSide == TypeSide.NONE_SIDE)
                        downSide = (TypeSide)rand.Next(-2, 2);
                }
                if ((i > 0) && (i < countColomns))
                {
                    if (leftSide == TypeSide.NONE_SIDE)
                        leftSide = Detail.reverseSide(arrayDetails[i - 1].RightSide);
                    if (rightSide == TypeSide.NONE_SIDE)
                        rightSide = (TypeSide)rand.Next(-2, 2);
                    if (downSide == TypeSide.NONE_SIDE)
                        downSide = (TypeSide)rand.Next(-2, 2);
                }
                if ((i >= countColomns) && (i < countElem))
                {
                    if (leftSide == TypeSide.NONE_SIDE)
                        leftSide = Detail.reverseSide(arrayDetails[i - 1].RightSide);
                    if (upSide == TypeSide.NONE_SIDE)
                        upSide = Detail.reverseSide(arrayDetails[i - countColomns].DownSide);
                    if (rightSide == TypeSide.NONE_SIDE)
                        rightSide = (TypeSide)rand.Next(-2, 2);
                    if (downSide == TypeSide.NONE_SIDE)
                        downSide = (TypeSide)rand.Next(-2, 2);
                }
                arrayDetails[i] = new Detail(matrColor[i], leftSide, rightSide, upSide, downSide, gr);
            }
            // перемешиваем пазл
            matrixMix();
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
                    --perm[i];
                if (check())
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Отрисовка собранного пазла.
        /// </summary>
        public void drawPuzzleFinish(int _finishX, int _finishY)
        {
            int x = _finishX;
            int y = _finishY;
            for (int i = 0, j = 1; i < countElem; i++)
            {
                x += step;
                if ((i != 0) && ((i % countColomns) == 0))
                {
                    j++;
                    y += step;
                    x = _finishX + step;

                }
                arrayDetails[(perm[i])].drawDetail(x, y, gr);
            }
        }


        /// <summary>
        /// Отрисовка несобранного пазла.
        /// </summary>
        /// <param name="_startX">Начальная коодината X</param>
        /// <param name="_startY">Начальная коодината Y</param>
        public void drawPuzzle(int _startX, int _startY)
        {
            int x = _startX - 2 * step;
            int y = _startY;
            for (int i = 0, j = 1; i < countElem; i++)
            {
                x += step;
                if ((i != 0) && ((i % countColomns) == 0))
                {
                    j++;
                    y += step;
                    x = _startX - step;

                }
                arrayDetails[i].drawDetail(x, y, gr);
            }
        }

        /// <summary>
        /// Перемешать значения матрицы.
        /// </summary>
        private void matrixMix()
        {
            for (int i = arrayDetails.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                // обменять значения arrayDetails[j] и arrayDetails[i]
                Detail temp = arrayDetails[j];
                arrayDetails[j] = arrayDetails[i];
                arrayDetails[i] = temp;
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
        /// <param name="id">Индекс в массиве полученной перестановки</param>
        /// <returns>Результат проверки</returns>
        public bool checkDetails(int id)
        {
            if (arrayDetails[perm[id]].YourColor != matrColor[id])
                return false;
            if ((id >= 0) && (id < countColomns))
            {
                if (arrayDetails[perm[id]].UpSide != TypeSide.STRAIGHT_SIDE)
                    return false;
                if ((id >= 1) && (!Detail.equalsToPuzzle(arrayDetails[perm[id]].LeftSide, arrayDetails[perm[id - 1]].RightSide)))
                    return false;
            }

            if ((id >= (countElem - countColomns)) && (id < countElem))
            {
                if (arrayDetails[perm[id]].DownSide != TypeSide.STRAIGHT_SIDE)
                    return false;
            }
            if (id == 0)
            {
                if (arrayDetails[perm[id]].LeftSide != TypeSide.STRAIGHT_SIDE)
                    return false;
            }

            if (id == (countElem - 1))
            {
                if (arrayDetails[perm[id]].RightSide != TypeSide.STRAIGHT_SIDE)
                    return false;
            }

            if ((id >= countColomns) && (id < countElem))
            {
                if (!Detail.equalsToPuzzle(arrayDetails[perm[id]].LeftSide, arrayDetails[perm[id - 1]].RightSide))
                    return false;
                if (!Detail.equalsToPuzzle(arrayDetails[perm[id]].UpSide, arrayDetails[perm[id - countColomns]].DownSide))
                    return false;
            }
            return true;

        }

    }
}
