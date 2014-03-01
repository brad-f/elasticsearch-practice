using PlainElastic.Net;
using PlainElastic.Net.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Search;
using Web.Service;

namespace Web.Models
{
    public class Contact : IIndexable, ISearchable
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public IndexCommand BuildIndex()
        {
            return Commands.Index("app", "contact", id: Email);
        }

        public SearchCommand BuildCommand()
        {
            return Commands.Search("app", "contact");
        }

        public string BuildQuery(string query)
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
                )
                .Build();
        }
    }
}