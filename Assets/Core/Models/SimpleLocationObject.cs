using Core.Interfaces;

namespace Core.Models 
{
    
    public sealed class SimpleLocationObject : LocationObjectModel
    {
        public SimpleLocationObject(string id, ILocationObjectConfig config) : base(id, config)
        {
        }
    }
}