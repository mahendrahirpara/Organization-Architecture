using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel720.Platform.Infrastructure.Queries
{
    public class QueryResult : IQueryResult
    {
        public bool Success { get; protected set; }
        public int? CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int TotalCount { get; set; }
        private int defaultRpp = 50;
        private int maxRpp = 500; //Records per page - default value = 50 and max value = 500

        private int _rpp = 50;
        protected int Rpp
        {
            get
            {
                return _rpp;
            }
            set
            {
                if (value <= 0)
                    _rpp = defaultRpp;
                else if (value > maxRpp)
                    _rpp = maxRpp;
                else
                    _rpp = value;
            }
        }
    }
}
