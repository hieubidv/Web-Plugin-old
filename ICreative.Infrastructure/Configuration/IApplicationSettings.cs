
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICreative.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        string LoggerName { get; }
        string NumberOfResultsPerPage { get; }

    }
}
