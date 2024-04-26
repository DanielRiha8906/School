namespace Lecture_5
{
    class Program
    {
        static void Main(string[] args)
        {
            RichTextFactory factory = new RichTextFactory();
            var text = factory.Create(Device.WEB);
            text.AddTitle("Pán Prstenů stručně");
            text.AddParagraph("Skupina kamarádů jde vyhodit bordel do drtičky odpadů");
            text.AddListing(new string[]{"Frodo", "Sam", "Aragorn"});
            text.Show();
        }
    }
}