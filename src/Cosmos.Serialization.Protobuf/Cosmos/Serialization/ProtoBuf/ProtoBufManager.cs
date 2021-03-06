using System;
using ProtoBuf.Meta;
// ReSharper disable InconsistentNaming

namespace Cosmos.Serialization.ProtoBuf
{
    internal static class ProtoBufManager
    {
        private static readonly Lazy<RuntimeTypeModel> _model = new Lazy<RuntimeTypeModel>(CreateTypeModel);

        public static RuntimeTypeModel Model => _model.Value;

        private static RuntimeTypeModel CreateTypeModel()
        {
            var typeModel = RuntimeTypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        }
    }
}