using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JsonModule
{
    public class JsonConverter<T>
    {
        /// <summary>
        /// Jsonシリアライザー設定
        /// </summary>
        private static readonly DataContractJsonSerializerSettings Settings = new DataContractJsonSerializerSettings
        {
            UseSimpleDictionaryFormat = true
        };

        /// <summary>
        /// Jsonシリアライザー
        /// </summary>
        private static DataContractJsonSerializer Serializer = new DataContractJsonSerializer(typeof(T), Settings);

        /// <summary>
        /// Jsonへ変換
        /// </summary>
        /// <param name="data">バイナリーデータ</param>
        /// <returns>Json</returns>
        public static string ConvertToJson(byte[] data)
        {
            using (var streamBinary = new MemoryStream(data)) 
            {
                try
                {
                    var formatter = new BinaryFormatter();
                    T obj = (T)formatter.Deserialize(streamBinary);

                    using (var streamJson = new MemoryStream())
                    {
                        Serializer.WriteObject(streamJson, obj);

                        using (var streamRead = new StreamReader(streamJson))
                        {
                            streamJson.Position = 0;
                            return streamRead.ReadToEnd();
                        }
                    }
                }
                catch (Exception) 
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// バイナリーデータへ変換
        /// </summary>
        /// <param name="json">Json</param>
        /// <returns>バイナリーデータ</returns>
        public static byte[] ConvertToByte(string json)
        {
            using (var streamObj = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                try
                {
                    T obj = (T)Serializer.ReadObject(streamObj);

                    using (var streamBinary = new MemoryStream())
                    {
                        var formatter = new BinaryFormatter();
                        formatter.Serialize(streamBinary, obj);

                        return streamBinary.ToArray();
                    }
                }
                catch (Exception) 
                {
                    return null;
                }
            }
        }
    }
}
