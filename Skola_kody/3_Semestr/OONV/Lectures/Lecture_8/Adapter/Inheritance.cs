namespace Adapter
{
    class ListWithStackExtension<T> : List<T>, IStack<T>
    {
        public void Push(T item)
        {
            Add(item);
        }
        public T Pop()
        {
            T last = this[^1];
            this.RemoveAt(this.Count - 1);
            return last;
        }
        public bool Empty
        {
            get => this.Count == 0;
        }
        public new void Insert(int index, T item) //Zastínění - shadowing (public new void)
        {
            if (index != this.Count - 1)
            {
                throw new ArgumentException("This is not a valid operation for stack! ... dumbass");
            }
            else this.Push(item);
        }
        T IStack<T>.First
        {
            get => this[^1];
        }
    }
}