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
    public class SearchService
    {
        private readonly JsonNetSerializer serializer;

        public SearchService()
        {
            serializer = new JsonNetSerializer();
        }

        public void Index(IIndexable indexable)
        {
            string result = Connection.Put(indexable.BuildIndex(), serializer.ToJson(indexable));
            IndexResult indexResult = serializer.ToIndexResult(result);
        }

        public IEnumerable<T> Search<T>(string value) where T : ISearchable, new()
        {
            T t = new T();
            OperationResult operationResult = Connection.Post(t.BuildCommand(), t.BuildQuery(value));
            SearchResult<T> searchResult = serializer.ToSearchResult<T>(operationResult);
            return searchResult.Documents;
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