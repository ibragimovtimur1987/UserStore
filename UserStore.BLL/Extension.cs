using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStore.BLL
{
    public static class Extensions
    {
        public static byte[] ToBytes(this Stream stream)
        {
            if (stream.CanSeek)
                stream.Position = 0;
            var bufferLen = (int)stream.Length;
            var buffer = new byte[bufferLen];
            stream.Read(buffer, 0, bufferLen);
            return buffer;
        }
    }
}
