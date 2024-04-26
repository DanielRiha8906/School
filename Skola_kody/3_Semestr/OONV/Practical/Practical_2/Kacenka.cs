class Automobil: Ipojizdne {
   public string Name{set; get;}
   public int Pocet_kol{set;get;}
   public double GPSPozice_x{set;get;}
   public double GPSPozice_y{set;get;}
   int smer = 0; // 0 dopredu, 1 doleva, 2 dozadu, 3 doprava     
public Automobil (string name, int pocet_tapek, double GPSpozice_x = 0, double GPSpozice_y = 0){
    this.Name = name;
    this.Pocet_Tapek = pocet_tapek;
    this.GPSPozice_x = GPSpozice_x;
    this.GPSPozice_y = GPSpozice_y; 
}
public void ZatocDoleva(){
    if (this.smer == 3){
        this.smer = 0;
    }
    else{
        this.smer = this.smer+1;
    }
}
public void ZatocDoprava(){
    if (this.smer == 0){
        this.smer = 3;
    }
    else{
        this.smer = this.smer-1;
    }
}
public void JedDopredu(double vzdalenost){
if (this.smer == 0){

this.GPSPozice_y = GPSPozice_y + vzdalenost; 

}
else if(this.smer == 1){

this.GPSPozice_x = GPSPozice_x - vzdalenost;

}
else if(this.smer == 2){

this.GPSPozice_y = GPSPozice_y - vzdalenost; 

}
else if(this.smer == 3){

this.GPSPozice_x = GPSPozice_x + vzdalenost;

}
}
public void JedZpatky(double vzdalenost){
if (this.smer == 0){

this.GPSPozice_y = GPSPozice_y - vzdalenost; 

}
else if(this.smer == 1){

this.GPSPozice_x = GPSPozice_x + vzdalenost;

}
else if(this.smer == 2){

this.GPSPozice_y = GPSPozice_y + vzdalenost; 

}
else if(this.smer == 3){

this.GPSPozice_x = GPSPozice_x - vzdalenost;

}

}
public void Udelej_kvak_kvak(){
    Console.WriteLine("Kvakity Kvakity");
}
public double Get_Y(){
    return this.GPSPozice_y;
}
public double Get_X(){
    return this.GPSPozice_x;
}
public string Jmeno_kachnicky(){
    return this.Name;
}
}