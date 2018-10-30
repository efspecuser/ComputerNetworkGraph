namespace Contracts
{
    public interface IEdge
    {
        IVertex Source { get; }
        IVertex Target { get; }
    }
}