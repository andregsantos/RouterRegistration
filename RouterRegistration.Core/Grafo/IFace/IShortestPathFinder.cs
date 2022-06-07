namespace RouterRegistration.Core.Grafo.IFace
{
    public interface IShortestPathFinder
    {
        Node[] FindShortestPath(Node from, Node to);
    }
}
