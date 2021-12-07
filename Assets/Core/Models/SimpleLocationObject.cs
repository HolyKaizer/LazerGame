using Core.Interfaces.Configs;

namespace Core.Models 
{
    
    public sealed class SimpleLocationObject : LocationObjectModel
    {
        public SimpleLocationObject(UserData userData, ILocationObjectConfig config) : base(config.Id, config)
        {
        }
    }
}