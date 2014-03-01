using PlainElastic.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Service
{
    public interface ISearchable
    {
        SearchCommand BuildCommand();
        string BuildQuery(string query);
    }
}
