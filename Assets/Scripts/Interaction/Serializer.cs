using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game.Tools
{
    public static class Serializer
    {
        public static string ConvertToString<T>(T data) where T : class
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, data);
            byte[] dataByteArray = memoryStream.ToArray();
            return Convert.ToBase64String(dataByteArray);
        }

        public static T ConvertFromString<T>(string str) where T : class
        {
            byte[] dataByteArray = Convert.FromBase64String(str);
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream(dataByteArray);
            return formatter.Deserialize(memoryStream) as T;
        }
    }
}