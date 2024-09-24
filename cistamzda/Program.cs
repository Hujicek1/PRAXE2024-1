using System.Diagnostics.Contracts;

namespace cistamzda;

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Zadejte svoji hrubou mzdu: ");
        int hrubaMzda = int.Parse(Console.ReadLine());
        int slevaZaDite = 0;
        int slevaZaStudenta = 0;
        float socialniPojisteni = hrubaMzda*0.065f;
        float zdravotniPojisteni = hrubaMzda*0.045f;
        float dan = (hrubaMzda*0.15f)-2570;
        int odecetCelkem = (int)(socialniPojisteni+zdravotniPojisteni+dan);
        System.Console.WriteLine("Kolik máte dětí?: ");
        int pocetDeti = int.Parse(Console.ReadLine());
        System.Console.WriteLine("Jste student?(ano/ne):");
        string student = Console.ReadLine();


        if(student == "ano"){
            slevaZaStudenta = 335;
        }
        if(pocetDeti == 1){
            slevaZaDite = 1267;
        }
        else if (pocetDeti == 2){
            slevaZaDite = 3127;
        }
        else if (pocetDeti >= 3){
            slevaZaDite = 5447+(pocetDeti-3)*2320;
        }


        int cistamzda = hrubaMzda-odecetCelkem+slevaZaDite+slevaZaStudenta;
        System.Console.WriteLine("Vaše čistá mzda: " + cistamzda);
    }
}
