// This je jen u prvního, jelikož na ten první to volám, druhý dávám jako argument!!
using System.Runtime.InteropServices;
using System.Collections.Generic;
static class IterTools
{
    public static IEnumerable<TResult> ZipWith<T1, T2, TResult>(this IEnumerable<T1> en1, IEnumerable<T2> en2, Func<T1, T2, TResult> zipfunc)
    {
        IEnumerator<T1> i1 = en1.GetEnumerator();
        IEnumerator<T2> i2 = en2.GetEnumerator();

        while (i1.MoveNext() && i2.MoveNext())
        {

            yield return zipfunc(i1.Current, i2.Current);

        }
    }

}
class Program
{
    public static void Main()
    {
        List<int> c1 = new List<int>() { 1, 2, 3 };
        List<int> c2 = new List<int>() { 10, 20 };
        foreach (var z in c1.ZipWith(c2, (x, y) => x * y))
        {
            Console.WriteLine(z);
        }
        List<Action<int>> akce = new List<Action<int>>();
        for (int i = 0; i < 10; i++)
        {

            akce.Add((j) => Console.WriteLine(j * i));
            akce[i](100);
        }
        Console.WriteLine(akce.Count);
        akce[2](100);
    }

}






//generický typ G nad typem A - G(A) List<int> např
// např A -|- B (Bázová třída, odvozená třída), tak se může stát, že G(A) je podmnožinou G(B) -> Kovariance
//Zvíře jest nadtypem psa => Seznam Zvířat je nadtypem seznamem psů aka každý seznam psů je seznam zvířat. Tohle si mysleli tvůrci Javy -> Javovské arraye jsou kovariantní
//List<zvirat> zver = new List<pes>(); - Jelikož je to nadtyp, mělo by to fungovat
// zver.add(Kocka); Nemůžeme to udělat, jelikož je to seznam psů. Problém je, že to vyhodí exception v běhu. Kinda cringe nl
//Seznamy nejsou kovarentní -> U listu není <out T> therefore je invarientní. No clue what that is
//Read only list toto rozhraní má (nejsou tam read only jenom ntice v C# no clue proč nám říkal, že read only tohle rozhraní má)
//Tuple<out T1, out T2> ... pro dvojice, pro tŘetice apod. je to jinak (je tam o jendo T navíc :OOOO)
// Ntice zvířat, psů a tak funguje
//
//Kontravariance! 
//Jesliže A je nadtypem B => B je nadtypem A 
//Kontravariance pro kolekce nefunguje, ale projevuje se to v func<>
// když fce můýe očekávat psa, tak může očekávat i zvíře
//
//Linq() - last thing about c# apparently... Let's go
// q as in query??!! 
//linq funkcionální - zavolej fci na fci na fci na fci...
//linq SQL like - což je stejně dobrá
// Jakože, je mi naprost jasný, že tahle hodina je strašně důležitá pro mojí budoucí práci or whatnot... ALe na tnehle předmět je tahle
// hodina totálně zbytečná
// Yield enumerator or enumerable get info about this shit
// delegát -- dám funkci in, dostanu out -- delegát rozdělený na dvě věcí - this a metodu. Ví nad jakým objektem se bude volat, ví metodu
//list ... list.append - hodí se to na delegáta co hází metodu nad this objektem.  
// delegát se dá volat -> nazvu si ho d(), mohu se na něj odkázat a pak udělat d(5) a hodí se tam 5, jako fce, ale pamatuje si nad jakým objektem pracuje
// this může být prázdné ->  statické metody 
//Tohle je vśechno kvůli Javě... C# potom šel svojí vlastní cestou -- Anonymní delegáti
//Anonymní delegáti - delegate int intf(int n)
//vytvoř mi intf, a udělej mi funkci. Pak řekl že to je useless. Fakt miluji Fišera 
//intf inc = {...}
//(x) => x+1 - nová syntaxe delegátů nebo (int x) => x+1 (int + int je int, najde si typ sám)
//Dá se to využívat jen v kontextu, kde se dá odvodit ten typ 
//
//
//
//
//