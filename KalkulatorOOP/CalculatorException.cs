using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorException
{
    public class DivisionByZeroException : Exception
    {
        public DivisionByZeroException() : base("Error pembagian dengan 0")
        {

        }
        public void PrintMessage()
        {
            Console.WriteLine(this.Message);
        }
    }
    
    public class NegativeIntegerRootException : Exception
    {
        private int integerNumber;
        NegativeIntegerRootException() : base()
        {

        }
        public NegativeIntegerRootException(int num) : base("Error mencari akar dari ")
        {
            this.integerNumber = num;
        }
        public void PrintMessage()
        {
            Console.Write(this.Message);
            Console.WriteLine(this.integerNumber);
        }
    }

    public class NegativeRealRootException : Exception
    {
        private double realNumber;
        NegativeRealRootException() : base()
        {

        }
        public NegativeRealRootException(double num) : base("Error mencari akar dari ")
        {
            this.realNumber = num;
        }
        public void PrintMessage()
        {
            Console.Write(this.Message);
            Console.WriteLine(this.realNumber);
        }
    }

    public class TooManyInputsException : Exception
    {
        private int inputSize;
        public TooManyInputsException() : base()
        {

        }
        public TooManyInputsException(int size) : base("Error input Terlalu panjang\nPanjang input : ")
        {
            this.inputSize = size;
        }
        public void PrintMessage()
        {
            Console.Write(this.Message);
            Console.WriteLine(inputSize);
        }
    }

    public class QueueEmptyException : Exception
    {
        public QueueEmptyException() : base("Error Queue kosong")
        {

        }
        public void PrintMessage()
        {
            Console.WriteLine(this.Message);
        }
    }

    public class RepeatButtonPushException : Exception
    {
        private int buttonID;
        private string[] buttonName = {"Titik", "Tambah", "Kurang", "Kali", "Bagi"};
        public enum ButtonIDs
        {
            titik,
            tambah,
            kurang,
            kali,
            bagi
        }
        public RepeatButtonPushException() : base()
        {

        }
        public RepeatButtonPushException(int buttonID) : base("Error menekan tombol berulang-ulang\nTombol yang ditekan : ")
        {
            this.buttonID = buttonID;
        }

        public void PrintMessage()
        {
            Console.Write(this.Message);
            Console.WriteLine(this.buttonName[this.buttonID]);
        }
    }
}
