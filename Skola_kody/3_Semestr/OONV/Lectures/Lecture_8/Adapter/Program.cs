namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //IStack<int> stack = new ListWithStackExtension<int>();
            var stack = new ListWithStackExtension<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            while (!stack.Empty)
            {
                Console.WriteLine(stack.Pop());
            }
            // Insert is the varied in Stack and list -> You can't just add new elements into Stack how you want
            Console.WriteLine("\n \n");
            IStack<int> stackInterface = new ListWithStackExtension<int>();
            var stackConcrete = new ListWithStackExtension<int>();

            stackInterface.Push(1);
            stackInterface.Push(2);

            stackConcrete.Push(1);
            stackConcrete.Push(2);
            Console.WriteLine("Implementation");
            System.Console.WriteLine(stackInterface.First); // Volá se property rohraní, měla by se vypsat 2, 2 je první na pop
            Console.WriteLine("Extension");
            System.Console.WriteLine(stackConcrete.First()); // volá se extension metoda rozhraní, měla by se vypsat 1, 1 je první na pop
        }
    }
}