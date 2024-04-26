using System.Diagnostics;
using System.Text;
using System.Text.Encodings.Web;
using Lecture_5;

namespace Lecture_5
{
    interface IRichText
    {
        void AddTitle(string text);
        void AddParagraph(string text);
        void AddListing(string[] text);
        void Show();
    }
    class Markdown: IRichText
    {   
        private StringBuilder sb = new StringBuilder();
        internal Markdown() {}
        public void AddTitle(string text)
        {
            sb.Append($"# {text}\n\n");
        }
        public void AddParagraph(string text)
        {
            sb.Append($"{text}\n\n"); //FIXME: formatting on 80 columns
        }
        public void AddListing(string[] text)
        {
            foreach (var item in text)
            {
                sb.Append($" * {item}\n");
            }
            sb.Append('\n');
        }
        public void Show()
        {
            Console.WriteLine(sb.ToString());
        }
    }
    class Html: IRichText
    {
        private StringBuilder sb = new StringBuilder();
    
        internal Html(){}
        public void AddTitle(string text)
        {
            sb.Append($"<h1>{text}</h1>");
        }
        public void AddParagraph(string text)
        {
            sb.Append($"<p>{text}</p>");
        }
        public void AddListing(string[] text)
        {
            sb.Append("<ul>");
            foreach (var item in text)
            {
                sb.Append($"<li>{item}</li>");
            }
            sb.Append("</ul>");
        }
        public void Show()
        {
            string html = "<html><body>" + sb.ToString() + "</body></html>";
            string fileName = Path.GetTempFileName();
            using (var writer = File.CreateText(fileName + ".html"))
            {
                writer.Write(html);
            }
            using var process = new Process();
            process.StartInfo.FileName="C:\\Users\\danie\\AppData\\Local\\Programs\\Opera GX\\launcher.exe";
            process.StartInfo.Arguments = fileName + ".html";
            process.StartInfo.UseShellExecute = false;
            process.Start();
            //Thread.Sleep(1000); Needs to be added for Linux
        }
        
    }
    
    enum Device
    {
        CONSOLE,
        GUI,
        WEB,
        PRINTER
    }
    class RichTextFactory
    {
        public IRichText Create(Device device)
        {
            switch (device)
            {
                case Device.CONSOLE:
                    return new Markdown();
                case Device.GUI:
                    return new Html();
                case Device.WEB:
                    return new Html();
                case Device.PRINTER:
                    return new Html();
                default:
                    throw new ArgumentException("Invalid device type");
                
            }
        }
    }
}
