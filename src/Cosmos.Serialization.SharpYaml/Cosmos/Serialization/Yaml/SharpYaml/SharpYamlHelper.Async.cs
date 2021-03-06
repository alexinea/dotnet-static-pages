using System;
using System.Threading.Tasks;

namespace Cosmos.Serialization.Yaml.SharpYaml
{
    /// <summary>
    /// SharpYaml helper
    /// </summary>
    public static partial class SharpYamlHelper
    {
        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> SerializeAsync<T>(T o)
        {
            return Task.Run(() => SharpYamlManager.DefaultSerializer.Serialize(o));
        }

        /// <summary>
        /// Serialize async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="expectedType"></param>
        /// <returns></returns>
        public static Task<string> SerializeAsync(object o, Type expectedType)
        {
            return Task.Run(() => SharpYamlManager.DefaultSerializer.Serialize(o, expectedType));
        }

        /// <summary>
        /// Serialize to bytes async
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static async Task<byte[]> SerializeToBytesAsync<T>(T o)
        {
            return o is null
                ? new byte[0]
                : SharpYamlManager.DefaultEncoding.GetBytes(await SerializeAsync(o));
        }

        /// <summary>
        /// Serialize to bytes async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="expectedType"></param>
        /// <returns></returns>
        public static async Task<byte[]> SerializeToBytesAsync(object o, Type expectedType)
        {
            return o is null
                ? new byte[0]
                : SharpYamlManager.DefaultEncoding.GetBytes(await SerializeAsync(o, expectedType));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(string data)
        {
            return string.IsNullOrWhiteSpace(data)
                ? default
                : await Task.Run(() => SharpYamlManager.DefaultSerializer.Deserialize<T>(data));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeAsync(string data, Type type)
        {
            return string.IsNullOrWhiteSpace(data)
                ? null
                : await Task.Run(() => SharpYamlManager.DefaultSerializer.Deserialize(data, type));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeFromBytesAsync<T>(byte[] data)
        {
            return data is null || data.Length is 0
                ? default
                : await DeserializeAsync<T>(SharpYamlManager.DefaultEncoding.GetString(data));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeFromBytesAsync(byte[] data, Type type)
        {
            return data is null || data.Length is 0
                ? null
                : await DeserializeAsync(SharpYamlManager.DefaultEncoding.GetString(data), type);
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="targetObj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeIntoAsync<T>(string data, T targetObj)
        {
            return string.IsNullOrWhiteSpace(data)
                ? targetObj
                : await Task.Run(() => SharpYamlManager.DefaultSerializer.DeserializeInto(data, targetObj));
        }

        /// <summary>
        /// Deserialize async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="targetObj"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeIntoAsync(string data, Type type, object targetObj)
        {
            return string.IsNullOrWhiteSpace(data)
                ? targetObj
                : await Task.Run(() => SharpYamlManager.DefaultSerializer.Deserialize(data, type, targetObj));
        }
    }
}