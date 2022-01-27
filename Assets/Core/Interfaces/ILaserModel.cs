using Core.Interfaces.Models;

namespace Core.Interfaces
{
    public interface ILaserModel : IModel
    {
        ISerializableVector3 LaserRotation { get; }
    }
}