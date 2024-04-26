#def meow(cat):
#    print(f"Cat {cat['name']} meows meow meow")
#def main():
#    mica = {
#        "name": "Mica",
#        "age": 2,
#        "owners": ["Petr", "Milan"]
#    }
#    meow(cat=mica)
from random import *
class Kocka:

    max_pocet_kocek_na_svete = 10 #datovy clen tridy 
    
    @classmethod
    def jak_dela_kocka(cls):
        return "mnau"
    
    @staticmethod
    def jak_nedela_kocka():
        return "Blood for the blood god"

    def __init__(self, jmeno, vek, majitele): #initor
        self._jmeno = jmeno               #Atributy (Datove cleny v Pythonu)
        self._vek = vek
        self._majitele = majitele
    
    @property #getter/accessor
    def jmeno(self):
        return self._jmeno
    
    @property
    def vek(self):
        return self._vek
    
    @property
    def majitele(self):
        return self._majitele
    
    @jmeno.setter #setter/mutator
    def jmeno(self, value):
        self._jmeno = value if len(value) > 3 else self._jmeno

    def zamnoukej(self):
        print(f"Kocka {self._jmeno} zamnoukala")

    def defekuj(self, kam:str) -> None:
        print(f"{self._jmeno} se vykadila do {kam}")

    #Magic/Dunder methods example: přetěžování operátzorů
    def __ge__(self, other):
        if not isinstance(other, Kocka):
            raise Exception(f"Objekt {other} neni Kocka!")
        else:
            return self._vek >= other.vek

    #napiste metodu, ktera přetěžuje + a to tak, aby když se pokusím sečíst dvě kočky, tak vznikne nová kočka: 
    #Jmeno spojeni jmen obou koček, vek 0, majitele random z majitelu
    
    def __add__(self, other):
        if not isinstance(other, Kocka):
            raise Exception(f"Tohle se prece nemuze parit")
        else:
            new_name = self._jmeno + other.jmeno
            vek = 0
            owners = choice([self._majitele, other.majitele])
            return Kocka(jmeno = new_name, vek = vek, majitele = owners)

def main():
    #objekt je isntanci (zhmotnenim) tridy
    print(Kocka.jak_dela_kocka())
    print(Kocka.max_pocet_kocek_na_svete)
    print(Kocka.jak_nedela_kocka())
main() 