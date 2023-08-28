using ProtoBuf;
using System.IO;

namespace WpfApp.Backend
{
    public static class Extensions
    {
        public static SELF DeepCopy<SELF>(this SELF self)
        {
            using var stream1 = new MemoryStream();
            Serializer.Serialize(stream1, self);
            var arr = stream1.ToArray();
            using var stream2 = new MemoryStream();
            stream2.Write(arr, 0, arr.Length);
            stream2.Seek(0, SeekOrigin.Begin);
            return Serializer.Deserialize<SELF>(stream2);
        }
    }
}