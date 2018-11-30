using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boootcamp20
{
    abstract class Kalkulator
    {
        public abstract double Hitung();
        public void CetakHasil (String op)
        {
            Console.Write("Hasil = " + Hitung());
        }
    }
    class Penjumlahan : Kalkulator {
        private double num1,num2;
        public Penjumlahan(double a, double b)
        {
            this.num1 = a;
            this.num2 = b;
        }

        public override double Hitung()
        {
            return num1 + num2;
        }
    }
    class Pengurangan : Kalkulator
    {
        private double num3, num4;
        public Pengurangan (double c, double d)
        {
            this.num3 = c;
            this.num4 = d;
			Console.Write("abc");
        }

        public override double Hitung()
        {
            return num3 - num4;
        }
    }
    class Perkalian : Kalkulator
    {
        private double num5, num6;
        public Perkalian(double e, double f)
        {
            this.num5 = e;
            this.num6 = f;
        }

        public override double Hitung()
        {
            return num5 * num6;
        }
    }
    class Pembagian : Kalkulator
    {
        private double num7, num8;
        public Pembagian(double g, double h)
        {
            this.num7 = g;
            this.num8 = h;
        }

        public override double Hitung()
        {
            return num7/num8;
        }
    }
}
