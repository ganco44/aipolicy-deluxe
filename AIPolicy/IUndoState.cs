namespace AIPolicy
{
    internal interface IUndoState<out T>
    {
        T State { get; }
    }
}
