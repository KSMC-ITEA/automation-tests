using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Malafi.Tests.Models
{
    public class TableFooterInformation
    {
        public TableFooterInformation(string footerText)
        {
            var matches = Regex.Match(footerText, "(?<pageStart>\\d+)\\s*to\\s*(?<pageEnd>\\d+)\\s*of\\s*(?<totalItems>\\d+)\\s*items");
            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Success);
            PageStart = int.Parse(matches.Groups["pageStart"].Value);
            PageEnd = int.Parse(matches.Groups["pageEnd"].Value);
            TotalItems = int.Parse(matches.Groups["totalItems"].Value);
            NumberOfPages = (int)Math.Ceiling(TotalItems / (PageEnd - PageStart + 1.0m));
        }

        public int PageStart { get; private set; }
        public int PageEnd { get; private set; }
        public int TotalItems { get; private set; }
        public int NumberOfPages { get; private set; }
    }
}
