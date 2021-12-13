using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ISave
    {
        IDictionary<string, object> Save();
    }
}