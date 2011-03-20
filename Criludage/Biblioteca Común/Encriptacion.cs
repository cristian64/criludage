using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca_Común
{
    public class Encriptacion
    {
        private int key;
        private int N;

        public Encriptacion(int key, int N)
        {
            this.key = key;
            this.N = N;
        }

        public string encriptacion(string text)
        {
            byte[] bytes = Encoding.Default.GetBytes(text);

            for (int i = 0; i < bytes.Length; i++)
            {
                int tmp = (int)bytes[i];
                BigInteger b = new BigInteger(tmp);
                tmp = b.modPow(key, N).IntValue();
                bytes[i] = (byte)tmp;
            }

            return Encoding.Default.GetString(bytes);
        }            
    }
}
