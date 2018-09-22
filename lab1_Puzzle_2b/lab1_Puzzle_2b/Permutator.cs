using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_Puzzle_2b
{
    //Перестановка
    //Реализация в нерекурсивном виде.Алгоритм Джонсона-Троттера
    //Сопоставим каждому элементу перестановки nums[i] направление arrow[i].
    //Будем указывать направление при помощи переменных bool (false - влево, true - вправо). 
    //Назовём элемент подвижным, если по направлению  стоит элемент меньше его.
    //Например, для p ={ 1,3,2,4,5},d={←,→,←,→,←}, подвижными являются элементы 3 и 5. 
    //На каждой итерации алгоритма будем искать наибольший подвижный элемент и менять местами с элементом, который стоит по направлению стрелки.
    //После чего поменяем направление стрелок на противоположное у всех элементов больших текущего.Изначально p ={ 1,…,n},d={←,…,←}(false ..).

    class Permutator
    {
        private int n;   // кол-во элементов 
        private int[] nums;  // массив переставляемых элементов
        private bool[] arrows; // массив направлений
        private long count, cur; // всевозможное кол-во перестановок, текущее кол-во перестановок

        public Permutator(int n)
        {
            this.n = n;
            nums = new int[n];
            arrows = new bool[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = i + 1;
                arrows[i] = false;
            }

            count = 1;
            for (int i = 1; i <= n; i++)
            {
                count *= i;
            }
            cur = 0;
        }
        /// <summary>
        /// Функция, проверяет существует следующая ли перестановка.
        /// </summary>
        /// <returns></returns>
        public bool hasNext()
        {
            return cur < count;
        }

        public long Cur { get { return cur; } }

        /// <summary>
        /// Генерирует новую перестановку.
        /// </summary>
        /// <returns>res - массив новой перестановки</returns>
        public int[] next()
        {
            int y = nums.Length;
            int[] res = new int[y];
            Array.Copy(nums, res, nums.Length);
            step();
            return res;
        }
        /// <summary>
        /// Алгоритм Джонсона-Троттера
        /// </summary>
        public void step()
        {
            int biggest = 0, pos = -1;

            cur++;

            for (int i = 1; i < n; i++)
            {
                // ищем наибольший подвижный элемент
                if (!arrows[i])
                {
                    if (nums[i] > nums[i - 1] && nums[i] > biggest)
                    {
                        pos = i;
                        biggest = nums[pos];
                    }
                }
                if (arrows[i - 1])
                {
                    if (nums[i] < nums[i - 1] && nums[i - 1] > biggest)
                    {
                        pos = i - 1;
                        biggest = nums[pos];
                    }
                }
            }
            // если не нашли
            if (pos < 0)
            {
                return;
            }
            // меняем подвижный элемент с эл-ом по направлении стрелки (bool переменной)
            int nei = pos + (arrows[pos] ? 1 : -1);
            nums[pos] = nums[nei];
            nums[nei] = biggest;
            bool t = arrows[pos];
            arrows[pos] = arrows[nei];
            arrows[nei] = t;
            //поменяем направление стрелок на противоположное у всех элементов больших текущего
            for (int i = 0; i < n; i++)
            {
                if (nums[i] > biggest)
                {
                    arrows[i] = !arrows[i];
                }
            }
        }

    }
}

