using System;

namespace les4_2
{
    public class Matrix
    {
        private int rows;
        private int cols;
        private int[,] data;
        public int Rows
        {
            get { return rows; }
            set { rows = value > 0 ? value : 0; }
        }
        public int Cols
        {
            get { return cols; }
            set { cols = value > 0 ? value : 0; }
        }
        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            data = new int[rows, cols];
        }        
        public int this[int row, int col]
        {
            get { return data[row, col]; }
            set { data[row, col] = value; }
        }        
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
                throw new ArgumentException("Матриці різного розміру.");
            Matrix result = new Matrix(m1.Rows, m1.Cols);
            for (int i = 0; i < m1.Rows; i++)
                for (int j = 0; j < m1.Cols; j++)
                    result[i, j] = m1[i, j] + m2[i, j];
            return result;
        }        
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
                throw new ArgumentException("Матриці різнргр розміру.");
            Matrix result = new Matrix(m1.Rows, m1.Cols);
            for (int i = 0; i < m1.Rows; i++)            
                for (int j = 0; j < m1.Cols; j++)               
                    result[i, j] = m1[i, j] - m2[i, j];            
            return result;
        }        
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Cols != m2.Rows)
                throw new ArgumentException("Кількість стовпчиків першої матриці повинна дорівнювати кількості рядків другої матриці.");
            Matrix result = new Matrix(m1.Rows, m2.Cols);
            for (int i = 0; i < m1.Rows; i++)            
                for (int j = 0; j < m2.Cols; j++)                
                    for (int k = 0; k < m1.Cols; k++)                    
                        result[i, j] += m1[i, k] * m2[k, j];             
            return result;
        }        
        public static Matrix operator *(Matrix matrix, int number)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Cols);
            for (int i = 0; i < matrix.Rows; i++)           
                for (int j = 0; j < matrix.Cols; j++)               
                    result[i, j] = matrix[i, j] * number;           
            return result;
        }        
        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if (ReferenceEquals(m1, m2))
                return true;
            if (m1 is null || m2 is null || m1.Rows != m2.Rows || m1.Cols != m2.Cols)
                return false;
            for (int i = 0; i < m1.Rows; i++)            
                for (int j = 0; j < m1.Cols; j++)                
                    if (m1[i, j] != m2[i, j])
                        return false;                
            return true;
        }        
        public static bool operator !=(Matrix m1, Matrix m2)
        {
            return !(m1 == m2);
        }        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return this == (Matrix)obj;
        }       
        public override int GetHashCode()
        {
            return data.GetHashCode();
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)                
                    result += data[i, j] + "\t";                
                result += "\n";
            }
            return result;
        }
        public void AfterShow()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }
    }
}
