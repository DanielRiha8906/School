namespace Adapter
{
    class ListStack<T> : IStack<T>
    {
        private List<T> stack = new List<T>();
        public void Push(T item)
        {
            stack.Add(item);
        }
        public T Pop()
        {
            T last = stack[^1];
            stack.RemoveAt(stack.Count - 1);
            return last;
        }
        public bool Empty
        {
            get { return stack.Count == 0; }
        }
        T IStack<T>.First
        {
            get => stack[^1];
        }
    }
}