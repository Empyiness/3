using System;
using LibMatrix;

namespace Lib_12
{
    public static class ExtensionMatrix
    {
        /// <summary>
        /// ���������� ������� ������ �������
        /// </summary>
        /// <param name="matrix">�������</param>
        /// <param name="min">������� ���������</param>
        /// <param name="max">�������� ���������</param>
        /// <returns name="matrix">����������� �������</returnsname></returns>
        public static Matrix<int> Generate(this Matrix<int> matrix, int min = 1, int max = 30)
        {
            if (min > max)
            {
                Invert(ref min, ref max);
            }
            Random rnd = new();
            for (int i = 0; i < matrix.Rows; i++)
            {
                for(int j = 0; j < matrix.Columns; j++)
                {
                    matrix[i,j] = rnd.Next(min, max);
                }
            }
            return matrix;
        }
        /// <summary>
        /// ���������� ��������� ������ 15
        /// </summary>
        /// <param name="matrix">������� ��� ���������� �����</param>
        /// <returns name="sum">����� ���������</returns>
        public static int Sum(this Matrix<int> matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix[i,j] > 15)
                    {
                        sum += matrix[i,j];
                    }
                }
            }
            return sum;
        }
        /// <summary>
        /// ������ �������� ���� ���������� �������
        /// </summary>
        /// <param name="value1">���������� 1</param>
        /// <param name="value2">���������� 2</param>
        private static void Invert(ref int value1, ref int value2)
        {
            int buffer = value1;
            value1 = value2;
            value2 = buffer;
        }
    }
}
