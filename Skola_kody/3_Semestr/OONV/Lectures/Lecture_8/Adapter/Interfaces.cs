namespace Adapter
{
    interface IStack<T>
    {
        void Push(T item);
        T Pop();
        bool Empty { get; }
        T First { get; }
    }
}