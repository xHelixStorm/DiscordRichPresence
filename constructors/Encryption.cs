using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRichPresence.constructors
{
    public class Encryption
    {
        private byte[] key;
        private byte[] iv;

        public Encryption(byte[] key, byte[] iv)
        {
            this.key = key;
            this.iv = iv;
        }

        public byte[] Key
        {
            get { return this.key; }
        }

        public byte[] IV
        {
            get { return this.iv; }
        }

        public override string ToString()
        {
            return "{"+Convert.ToBase64String(key)+", "+Convert.ToBase64String(iv)+"}".Normalize();
        }
    }
}
