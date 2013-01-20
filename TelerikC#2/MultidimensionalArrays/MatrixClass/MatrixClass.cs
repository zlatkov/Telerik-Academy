using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixClass
{
    class Matrix
    {
        private int[,] matrix;
        private int rowsCount;
        private int columnsCount;

        public Matrix(int rows, int columns)
        {
            rowsCount = rows;
            columnsCount = columns;

            matrix = new int[rowsCount, columnsCount];
        }

        public Matrix(int[,] initialMatrix)
        {
            if (initialMatrix.Rank == 2)
            {
                rowsCount = initialMatrix.GetLength(0);
                columnsCount = initialMatrix.GetLength(1);

                matrix = (int[,])initialMatrix.Clone();
            }
        }

        public int RowsCount
        {
            get
            {
                return rowsCount;
            }
        }

        public int ColumnsCount
        {
            get
            {
                return columnsCount;
            }
        }

        public int this[int rowIndex, int columnIndex]
        {
            get
            {
                if (rowIndex >= 0 && rowIndex < rowsCount && columnIndex >= 0 && columnIndex < columnsCount)
                {
                    return matrix[rowIndex, columnIndex];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (rowIndex >= 0 && rowIndex < rowsCount && columnIndex >= 0 && columnIndex < columnsCount)
                {
                    matrix[rowIndex, columnIndex] = value;
                }
            }
        }

        public static Matrix operator +(Matrix x, Matrix y)
        {
            if (x.RowsCount == y.RowsCount && x.ColumnsCount == y.ColumnsCount)
            {
                Matrix result = new Matrix(x.RowsCount, y.RowsCount);
                for (int i = 0; i < x.RowsCount; ++i)
                {
                    for (int j = 0; j < x.ColumnsCount; ++j)
                    {
                        result[i, j] = x[i, j] + y[i, j];
                    }
                }

                return result;
            }
            else
            {
                return new Matrix(0, 0);
            }
        }

        public static Matrix operator -(Matrix x, Matrix y)
        {
            if (x.RowsCount == y.RowsCount && x.ColumnsCount == y.ColumnsCount)
            {
                Matrix result = new Matrix(x.RowsCount, y.RowsCount);
                for (int i = 0; i < x.RowsCount; ++i)
                {
                    for (int j = 0; j < x.ColumnsCount; ++j)
                    {
                        result[i, j] = x[i, j] - y[i, j];
                    }
                }

                return result;
            }
            else
            {
                return new Matrix(0, 0);
            }
        }

        public static Matrix operator *(Matrix x, Matrix y)
        {
            if (x.ColumnsCount == y.RowsCount)
            {
                Matrix result = new Matrix(x.RowsCount, y.ColumnsCount);
                for (int i = 0; i < x.RowsCount; ++i)
                {
                    for (int j = 0; j < y.ColumnsCount; ++j)
                    {
                        for (int k = 0; k < x.ColumnsCount; ++k)
                        {
                            result[i, j] += x[i, k] * y[k, j];
                        }
                    }
                }

                return result;
            }
            else
            {
                return new Matrix(0, 0);
            }
        }

        public override string ToString()
        {
            StringBuilder matrixToString = new StringBuilder();
            for (int i = 0; i < rowsCount; ++i)
            {
                for (int j = 0; j < columnsCount; ++j)
                {
                    if (j > 0)
                    {
                        matrixToString.Append(" ");
                    }

                    matrixToString.Append(matrix[i, j].ToString());
                }
                if (i != rowsCount - 1)
                {
                    matrixToString.Append("\n");
                }
            }
            return matrixToString.ToString();
        }
    }

    class MatrixClass
    {
        static void Main(string[] args)
        {
            Matrix test = new Matrix(0, 0);

            int[,] a = new int[,] { {1, 1, 1}, {2, 2, 2} };
            int[,] b = new int[,] { {1, 2, 3}, {1 , 2, 3}, {1, 2, 3}};

            Matrix ma = new Matrix(a);
            Matrix mb = new Matrix(b);

            Matrix res = ma * mb;

            Console.WriteLine(res.ToString());
        }
    }
}
