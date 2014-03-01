using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Queries;
using Web.Service;

namespace Web.Models
{
    public class Contact : ISearchable
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public IndexCommand BuildIndexCommand()
        {
            return Commands.Index("app", "contact", id: Email);
        }

        public SearchCommand BuildSearchCommand()
        {
            return Commands.Search("app", "contact");
        }

        public string BuildMappingCommand()
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

        public string BuildSearchQuery(string query)
        {
            return new QueryBuilder<Contact>()
                .Query(q => q
                    .Bool(b => b
                        .Must(m => m
                            .QueryString(qs => qs
                                .Fields(c => c.Email)
                                .Query(query)
                            )
                        )
                    )
                ).Build();
        }
    }
}