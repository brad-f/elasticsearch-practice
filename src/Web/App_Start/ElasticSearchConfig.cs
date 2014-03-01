using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;
using Web.Search;

namespace Web
{
    public static class ElasticSearchConfig
    {
        public static void ConfigureMappings()
        {
        }

        private static void Initialize()
        {
            new SearchService<Contact>().CreateIndexAndMapping();      
        }
    }
}