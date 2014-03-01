using PlainElastic.Net;

namespace Web.Service
{
    public interface ISearchable
    {
        IndexCommand BuildIndexCommand();
        SearchCommand BuildSearchCommand();
        string BuildMappingCommand();
        string BuildSearchQuery(string query);
    }
}
