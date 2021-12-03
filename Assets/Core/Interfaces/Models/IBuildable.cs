using System.Collections.Generic;

namespace Core.Interfaces.Models
{
    public interface IBuildable
    {
        object BuildItem(IDictionary<string, object> rawBuildData);
    }
}