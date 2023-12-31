using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Paket
{
    public double Agirlik { get; set; }
    public double Hacim { get; set; }
    public string Adres { get; set; }
    public void Atama(double agirlik,double hacim,string adres)
    {
        Agirlik = agirlik;
        Hacim = hacim;
        if(Adres=="Adres1")
            Adres = adres;
        else
            Adres = "Adres2";
    }
    private double KargoUcret(double agirlik,double hacim)
    {
        return ((hacim / 5)+(agirlik*1.3));
    }
    private double KargoUcret(double agirlik, double hacim,string adres)
    {
        
            return ((hacim * 2.2)+(agirlik*1.5));
    }
    public double Fiyat()
    {
        if (Adres == "Adres1")
            return KargoUcret(this.Agirlik,this.Hacim);
        else
            return KargoUcret(this.Agirlik,this.Hacim,this.Adres);
    }
}
namespace KargoHizmeti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Paket> kargolar = new List<Paket>();
            bool dongu = true;
            while (dongu)
            {
                Console.Write("Kargonun ağırlığını girin: ");
                double agirlik = Convert.ToDouble(Console.ReadLine());

                Console.Write("Kargonun hacmini girin: ");
                double hacim = Convert.ToDouble(Console.ReadLine());
                Console.Write("Teslimat adresini girin: ");
                string adres = Console.ReadLine();
                Paket yeni=new Paket();
                yeni.Atama(agirlik, hacim, adres);
                kargolar.Add(yeni);
                Console.WriteLine("Başka kargo eklenecek mi (Evet-1,Hayır-2)");
                int karar=Convert.ToInt32(Console.ReadLine());
                if (karar == 1)
                    dongu = true;
                else
                    dongu = false;
            };
            Console.WriteLine("Kargoların adreslere göre karşılaştırması:");
            double enUygunFiyat = double.MaxValue;
            string enUygunAdres = "";
            foreach (Paket kargo in kargolar)
            {
                if (kargo.Fiyat() < enUygunFiyat)
                {
                    enUygunFiyat = kargo.Fiyat();
                    enUygunAdres = kargo.Adres;
                }
            }

            Console.WriteLine($"En uygun teslimat adresi: {enUygunAdres} - Ücret: {enUygunFiyat} TL");

        }
    }
}
