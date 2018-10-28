using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boootcamp20
{
    abstract class Bangun2D
    {
        // pendefinisian fungsi abstract
        public abstract double HitungLuas();
        //pendefinisian fungsi void
        public void CetakLuas (String namabangun)
        {
            Console.WriteLine("Luas "+namabangun + " = " + HitungLuas());
        }
    }
    class Segitiga : Bangun2D
    {
        //pendeklarasian variable ber-modifier private
        private double alas;
        private double tinggi;
        //pendeklarasian konstruktor
        public Segitiga(double a, double t)
        {
            this.alas = a;
            this.tinggi = t;
        }

        public override double HitungLuas()
        {
            return alas * tinggi / 2;
        }
    }

    class Persegi : Bangun2D
    {
        //pendeklarasian variable ber-modifier private
        private double sisi;
        //pendeklarasian konstruktor
        public Persegi(double s)
        {
            this.sisi = s;
        }

        public override double HitungLuas()
        {
            return sisi * sisi;
        }
    }

            class Lingkaran : Bangun2D
            {
                //pendeklarasian variable ber-modifier private
                private double jarijari;
                //pendeklarasian konstruktor
                public Lingkaran(double r)
                {
                    this.jarijari = r;
                }

        public override double HitungLuas()
        {
            return 3.14 * jarijari * jarijari;
        }
    }
        class PersegiPanjang : Bangun2D
                {
                    //pendeklarasian variable ber-modifier private
                    private double pnj;
                    private double leb;
                    private double tgg;
                    //pendeklarasian konstruktor
                    public PersegiPanjang(double p, double l, double t)
                    {
                        this.pnj = p;
                        this.leb = l;
                        this.tgg = t;
                    }

        public override double HitungLuas()
        {
            return pnj * leb * tgg;
        }
    }
}
