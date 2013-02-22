using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Matrix
{
    public class Matrix<T>
    {
        private T[,] matrix;
        private int rows;
        private int cols;

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new T[rows, cols];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= rows || col < 0 || col >= cols)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return matrix[row, col];
                }
            }

            set
            {
                if (row < 0 || row >= rows || col < 0 || col >= cols)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    matrix[row, col] = value;
                }
            }
        }

        public static Matrix<T> operator -(Matrix<T> a)
        {
            Matrix<T> result = new Matrix<T>(a.Rows, a.Cols);
            dynamic tmp;

            for (int i = 0; i < a.Rows; ++i)
            {
                for (int j = 0; j < a.Cols; ++j)
                {
                    tmp = a[i, j];
                    result[i, j] = -tmp;
                }
            }
            return result;
        }

        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new ArgumentException("The matrix you are  trying to add have difference dimensions");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(a.Rows, a.Cols);
                dynamic tmp1;
                dynamic tmp2;

                for (int i = 0; i < a.Rows; ++i)
                {
                    for (int j = 0; j < a.Cols; ++j)
                    {
                        tmp1 = a[i, j];
                        tmp2 = b[i, j];

                        result[i, j] = tmp1 + tmp2;
                    }
                }
                return result;
            }
        }

        public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
        {
            return a + (-b);
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            if (a.Cols != b.Rows)
            {
                throw new ArgumentException();
            }
            else
            {
                Matrix<T> result = new Matrix<T>(a.Rows, b.Cols);
                dynamic tmp1;
                dynamic tmp2;
                dynamic tmp3;

                for (int i = 0; i < a.Rows; ++i)
                {
                    for (int j = 0; j < b.Cols; ++j)
                    {
                        for (int k = 0; k < b.Rows; ++k)
                        {
                            tmp1 = a[i, k];
                            tmp2 = b[k, j];
                            tmp3 = result[i, j];
                            tmp3 += tmp1 * tmp2;
                            result[i, j] = tmp3;
                        }
                    }
                }

                return result;
            }
        }

        public static bool operator true(Matrix<T> a)
        {
            dynamic tmp;
            for (int i = 0; i < a.Rows; ++i)
            {
                for (int j = 0; j < a.Cols; ++j)
                {
                    tmp = a[i, j];
                    if (tmp != default(T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T> a)
        {
            if (a)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Cols; ++j)
                {
                    if (j > 0)
                    {
                        result.Append(" ");
                    }
                    result.Append(this[i, j]);
                }
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}
