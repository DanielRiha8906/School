class Ridic{

    public string Name{set;get;}
    public IPojizdne Brmbrm{set;get;}
    public Ridic(string name, Ipojizdne brmbrm = null){


        this.Name = name;
        this.Brmbrm = brmbrm;
    }
public void Najdi_Si_Vozidlo(Ipojizdne vozidlo){
    this.Brmbrm = vozidlo;
}

public void Dojed_do_Prace(){
    if(this.Brmbrm == null){
        Console.WriteLine("Nemáš čím jet čéče");
    }
    else{
        this.Brmbrm.JedDopredu(10);
        this.Brmbrm.ZatocDoleva();
        this.Brmbrm.JedZpatky(12);
        this.Brmbrm.Get_X();
        this.Brmbrm.Get_Y();
        Console.WriteLine("Jses tam");
    }
}
}