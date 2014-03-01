using PlainElastic.Net;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;
using Web.Service;

namespace Web.Search
{
    public class SearchService<T> where T : ISearchable, new()
    {
        private readonly JsonNetSerializer serializer;

        public SearchService()
        {
            serializer = new JsonNetSerializer();
        }

        public void CreateIndexAndMapping()
        {
            T searchable = new T();
            OperationResult indexResult = Connection.Post(Commands.CreateIndex("app"));
            OperationResult mappingResult = Connection.Put(Commands.PutMapping("app", "contact"), searchable.BuildMappingCommand());  
        }

        public void IndexEntity(ISearchable searchable)
        {
            string result = Connection.Put(searchable.BuildIndexCommand(), serializer.ToJson(searchable));
            IndexResult indexResult = serializer.ToIndexResult(result);
        }

        public IList<T> Search(string value)
        {
            T t = new T();
            OperationResult operationResult = Connection.Post(t.BuildSearchCommand(), t.BuildSearchQuery(value));
            SearchResult<T> searchResult = serializer.ToSearchResult<T>(operationResult);
            return searchResult.Documents.ToList();
        }

        private ElasticConnection Connection
        {
            get
            {
                return new ElasticConnection("localhost");
            }
        }
    }
}