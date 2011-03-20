using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

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

        public class AES
        {
            /// <summary>
            /// Vector de inicialización de encriptación.
            /// Debe ser una cadena de 16 bytes, es decir, 16 caracteres.
            /// </summary>
            public static String InitialVector = "abcdefghijklmnop";

            /// <summary>
            /// Puede ser cualquier cadena.
            /// TODO: explicar que es esto
            /// </summary>
            public static String SaltValue = "asdf";

            /// <summary>
            /// Cantidad de bits de la clave.
            /// Puede ser cualquiera de estos tres valores: 128, 192 o 256
            /// </summary>
            public static int KeySize = 128;

            /// <summary>
            /// Número de iteraciones. Con 1 o 2 es suficiente.
            /// </summary>
            public static int Iterations = 2;

            /// <summary>
            /// Tipo de algoritmo de resumen: "MD5" o "SHA1".
            /// </summary>
            public static String StrHashAlgorithm = "MD5";

            /// <summary>
            /// Encripta un mensaje según la clave proporcionada.
            /// </summary>
            /// <param name="mensaje">Mensaje que se va a encriptar.</param>
            /// <param name="clave">Clave que se va a utilizar.</param>
            /// <returns>Devuelve el mensaje encriptado.</returns>
            public static String Encriptar(String mensaje, String clave)
            {
                try
                {
                    byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
                    byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);
                    byte[] plainTextBytes = Encoding.UTF8.GetBytes(mensaje);
                    PasswordDeriveBytes password = new PasswordDeriveBytes(clave, saltValueBytes, StrHashAlgorithm, Iterations);
                    byte[] keyBytes = password.GetBytes(KeySize / 8);
                    RijndaelManaged symmetricKey = new RijndaelManaged();
                    symmetricKey.Mode = CipherMode.CBC;
                    ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, InitialVectorBytes);
                    MemoryStream memoryStream = new MemoryStream();
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    byte[] cipherTextBytes = memoryStream.ToArray();
                    memoryStream.Close();
                    cryptoStream.Close();

                    return Convert.ToBase64String(cipherTextBytes);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            /// <summary>
            /// Desencripta un mensaje a partir la clave proporcionada.
            /// </summary>
            /// <param name="mensaje">Mensaje que se va a desencriptar.</param>
            /// <param name="clave">Clave que se va a utilizar. La cantidad de bits debe coincidir con el campo KeySize.</param>
            /// <returns>Devuelve el mensaje desencriptado.</returns>
            public static String Desencriptar(String mensaje, String clave)
            {
                try
                {
                    byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
                    byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);
                    byte[] cipherTextBytes = Convert.FromBase64String(mensaje);
                    PasswordDeriveBytes password = new PasswordDeriveBytes(clave, saltValueBytes, StrHashAlgorithm, Iterations);
                    RijndaelManaged symmetricKey = new RijndaelManaged();
                    symmetricKey.Mode = CipherMode.CBC;
                    byte[] keyBytes = password.GetBytes(KeySize / 8);
                    ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, InitialVectorBytes);
                    MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                    memoryStream.Close();
                    cryptoStream.Close();

                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
