using PlainElastic.Net;

namespace Web.Search
{
    public interface IIndexable
    {
        IndexCommand BuildIndex();
    }
}
