class Program {

    static void Main()
    {

Automobil brmbrm = new Automobil("Toyota", 4, 0, 0);
brmbrm.JedDopredu(14);
brmbrm.ZatocDoleva();
brmbrm.JedZpatky(11.3);
Console.WriteLine(brmbrm.Get_X());
Console.WriteLine(brmbrm.Get_Y());
}
}