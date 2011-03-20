using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca_Común
{
    namespace Encriptacion
    {
        public class RSA
        {
            private int key;
            private int N;

            public RSA(int key, int N)
            {
                this.key = key;
                this.N = N;
            }

            public String Encriptar(String mensaje)
            {
                byte[] bytes = Encoding.Default.GetBytes(mensaje);

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
}
