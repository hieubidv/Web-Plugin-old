
namespace ICreative.Menu
{
    public static class MVCSiteMap
    {
        private static IMenuNode _startingNode;

        public static IMenuNode StartingNode
        {
            get { return _startingNode; }
        }

        public static void BuildSiteMap(IMenuNode node)
        {
            _startingNode = node;
        }
    }
}