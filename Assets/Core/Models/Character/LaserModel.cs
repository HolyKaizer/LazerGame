using System.Collections.Generic;
using Core.Extensions;
using Core.Interfaces;
using Core.Interfaces.Configs;
using Core.Interfaces.Models;

namespace Core.Models.Character
{
    public sealed class LaserModel : BaseModel<ILaserConfig>, ILaserModel
    {
        protected override bool IsSerializable => false;
        public ISerializableVector3 LaserRotation { get; }

        public LaserModel(string id, ILaserConfig config) : base(id, config)
        {
            LaserRotation = new SerializableVector3();
        }

        protected override IDictionary<string, object> OnSave(IDictionary<string, object> rawData)
        {
            return new Dictionary<string, object> { { Consts.LaserRotation, LaserRotation } };
        }
    }
}