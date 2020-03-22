using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorException
{
    public class DivisionByZeroException : Exception
    {
        public override string Message
        {
            get
            {
                return "Error pembagian dengan 0";
            }
        }
    }

    public class NegativeRootException : Exception
    {
        private double realNumber;
        public NegativeRootException(double num)
        {
            this.realNumber = num;
        }
        public override string Message
        {
            get
            {
                return "Error mencari akar dari " + this.realNumber;
            }
        }
    }

    public class TooManyInputsException : Exception
    {
        private int inputSize;
        public TooManyInputsException(int size)
        {
            this.inputSize = size;
        }
        public override string Message
        {
            get
            {
                return "Error input Terlalu panjang\nPanjang input : " + this.inputSize;
            }
        }
    }

    public class QueueEmptyException : Exception
    {
        public override string Message
        {
            get
            {
                return "Error Queue kosong";
            }
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
        public RepeatButtonPushException(int buttonID)
        {
            this.buttonID = buttonID;
        }

        public override string Message
        {
            get
            {
                return "Error menekan tombol berulang-ulang\nTombol yang ditekan : " + this.buttonName[this.buttonID];
            }
        }
    }
}
