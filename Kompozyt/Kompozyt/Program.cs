using System;
using System.Collections.Generic;

public interface Kompozyt
{
    public void Renderuj();
    void DodajElement(Kompozyt element);
    void UsunElement(Kompozyt element);


}

public class Lisc : Kompozyt
{
    public string nazwa { get; set; }

    public Lisc(string nazwa)
    {
        this.nazwa = nazwa;
    }

    public void Renderuj()
    {
        Console.WriteLine(nazwa + " renderowanie...");
        // renderowanie
    }


    void Kompozyt.DodajElement(Kompozyt element)                            //2 brakujące metody których wymaga interfejs
    {
        throw new NotImplementedException();
    }

    void Kompozyt.UsunElement(Kompozyt element)                             //2 brakujące metody których wymaga interfejs
    {
        throw new NotImplementedException();
    }
}


public class Wezel : Kompozyt
{

    private List<Kompozyt> Lista = new List<Kompozyt>();

    public Wezel(string nazwa)
    {
        this.nazwa = nazwa;
    }

    public string nazwa { get; set; }

    public void DodajElement(Kompozyt element)                          // 2 brakujące metody 
    {
        Lista.Add(element);
    }

    public void Renderuj()
    {
        Console.WriteLine(nazwa + " rozpoczęcie renderowania");        //rozpoczęcie renderowania

        foreach (var item in Lista)                                     //foreach item.Renderuj(); 
        {
            item.Renderuj();
        }

        Console.WriteLine(nazwa + " zakończenie renderowania  ");
        //zakończenie renderowania
    }

    public void UsunElement(Kompozyt element)                           // 2 brakujące metody 
    {
        Lista.Remove(element);
    }
}

// rednerowanie reenderuje wszystkie elementy z listy i elementy liscia 
class MainClass
{
    public static void Main(string[] args)
    {
        //definicje struktury
        Wezel korzen = new Wezel("Korzeń");
        Wezel branch2 = new Wezel("Węzeł 2");
        Wezel branch3 = new Wezel("Węzeł 3");
        Wezel branch33 = new Wezel("Węzeł 3.3");

        //liscie niepotrzebne, narazie bedzie
        Lisc lisc1 = new Lisc("Liść 1.1");
        Lisc lisc21 = new Lisc("Liść 2.1");
        Lisc lisc22 = new Lisc("Liść 2.2");
        Lisc lisc23 = new Lisc("Liść 2.3");
        Lisc lisc31 = new Lisc("Liść 3.1");
        Lisc lisc32 = new Lisc("Liść 3.2");
        Lisc lisc331 = new Lisc("Liść 3.3.1");

        korzen.DodajElement(lisc1);
        korzen.DodajElement(branch2);
        korzen.DodajElement(branch3);
        branch2.DodajElement(lisc21);
        branch2.DodajElement(lisc22);
        branch2.DodajElement(lisc23);
        branch3.DodajElement(lisc31);
        branch3.DodajElement(lisc32);
        branch3.DodajElement(branch33);
        branch33.DodajElement(lisc331);




        korzen.Renderuj();

    }
}