using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web
{
    public static class ElasticSearchConfig
    {
        public static void ConfigureMappings()
        {
        }

        private static void Initialize()
        {
            ElasticConnection connection = new ElasticConnection("localhost");
            OperationResult indexResult = connection.Post(Commands.CreateIndex("app"));
            OperationResult mappingResult = connection.Put(Commands.PutMapping("app", "contact"), BuildContactMapping());       
        }

        private static string BuildContactMapping()
        {
            return new MapBuilder<Contact>()
                .RootObject("contact", r => r
                    .All(e => e.Enabled(false))
                    .Dynamic(false)
                    .Properties(pr => pr
                        .String(c => c.Name, f => f.Analyzer(DefaultAnalyzers.standard))
                        .String(c => c.Email, f => f.Analyzer(DefaultAnalyzers.standard))
                    )
                ).Build();
        }
    }
}