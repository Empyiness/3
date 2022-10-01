using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LibMatrix
{
    /// <summary>
    /// ����� ��� ������ � ��������� ��������
    /// </summary>
    /// <typeparam name="T">���������� ���</typeparam>
    public class Matrix<T>
    {
        private T[,] _items;
        /// <summary>
        /// ����������� ������
        /// </summary>
        /// <param name="rowCount">���������� �����</param>
        /// <param name="columnCount">���������� ��������</param>
        /// <param name="extension">����������</param>
        public Matrix(int rowCount = 5, int columnCount = 4, string extension = ".matrix")
        {
            _items = new T[rowCount, columnCount];
            Rows = rowCount;
            Columns = columnCount;
            Extension = extension;
        }
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="rowIndex">������ ������ ��������</param>
        /// <param name="columnIndex">������ ������� ��������</param>
        /// <returns></returns>
        public T this[int rowIndex, int columnIndex]
        {
            get => _items[rowIndex, columnIndex];
            set => _items[rowIndex, columnIndex] = value;
        }
        /// <summary>
        /// �������� ���������� �����
        /// </summary>
        public int Rows { get; private set; }
        /// <summary>
        /// �������� ���������� ��������
        /// </summary>
        public int Columns { get; private set; }
        /// <summary>
        /// �������� ����������
        /// </summary>
        public string Extension { get; private set; }

        /// <summary>
        /// ��������� ���� ��������� ������� �������� ���� ��-���������
        /// </summary>
        public void DefaultInit()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {   
                    _items[i, j] = default;
                }
            }
        }
        /// <summary>
        /// ���������� �������
        /// </summary>
        /// <param name="path">����</param>
        public void Save(string path)
        {
            BinaryFormatter formatter = new();
            using(FileStream stream = new(path, FileMode.Create))
            {
                formatter.Serialize(stream, _items);
            }
        }
        /// <summary>
        /// �������� �������
        /// </summary>
        /// <param name="path">����</param>
        public void Load(string path)
        {
            BinaryFormatter formatter = new();
            using (FileStream stream = new(path, FileMode.Open))
            {
                _items = formatter.Deserialize(stream) as T[,];
            }
        }
    }
    public static class VisualArray
    {
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("Num" + (i + 1), typeof(T));
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }
                res.Rows.Add(row);
            }
            return res;
        }

        public static DataTable ToDataTable<T>(this Matrix<T> matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.Columns; i++)
            {
                res.Columns.Add("Num" + (i + 1), typeof(T));
            }
            for (int i = 0; i < matrix.Rows; i++)
            {
                var row = res.NewRow();
                for (int j = 0; j < matrix.Columns; j++)
                {
                    row[j] = matrix[i, j];
                }
                res.Rows.Add(row);
            }
            return res;
        }
    }
}
