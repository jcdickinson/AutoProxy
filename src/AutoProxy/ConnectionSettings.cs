using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoProxy
{
    [Flags]
    public enum Autodetect
    {
        None = 0x0,
        AutoDetect = 0x8,
        AutoConfig = 0x4,
        Manual = 0x2,
        EnableProxy = 0x1
    }

    public class ConnectionSettings
    {
        private static readonly UTF8Encoding Utf8 = new UTF8Encoding(false);


        public int Version = 0x46;
        public int Counter = 0x00;
        public Autodetect Autodetect;
        public string ProxyServer;
        public string ExtraData;
        public string AutodetectScript;
        public byte[] Junk;

        public static ConnectionSettings Read(byte[] data)
        {
            var cs = new ConnectionSettings();
            using (var ms = new MemoryStream(data))
            using (var br = new BinaryReader(ms))
            {
                cs.Version = br.ReadInt32();
                cs.Counter = br.ReadInt32();
                cs.Autodetect = (Autodetect)br.ReadInt32();

                var len = br.ReadInt32();
                cs.ProxyServer = Utf8.GetString(br.ReadBytes(len));

                len = br.ReadInt32();
                cs.ExtraData = Utf8.GetString(br.ReadBytes(len));

                len = br.ReadInt32();
                cs.AutodetectScript = Utf8.GetString(br.ReadBytes(len));

                // So damn lazy.
                using (var ms2 = new MemoryStream())
                {
                    var ba = new byte[Environment.SystemPageSize];
                    while ((len = br.Read(ba, 0, ba.Length)) != 0)
                    {
                        ms2.Write(ba, 0, len);
                    }

                    cs.Junk = ms2.ToArray();
                }
            }

            return cs;
        }

        public byte[] Write()
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                bw.Write(Version);
                bw.Write(Counter);
                bw.Write((int)Autodetect);
                
                var ba = Utf8.GetBytes(ProxyServer ?? "");
                bw.Write(ba.Length);
                bw.Write(ba);

                ba = Utf8.GetBytes(ExtraData ?? "");
                bw.Write(ba.Length);
                bw.Write(ba);

                ba = Utf8.GetBytes(AutodetectScript ?? "");
                bw.Write(ba.Length);
                bw.Write(ba);

                bw.Write(Junk);
                bw.Flush();

                return ms.ToArray();
            }
        }
    }
}
