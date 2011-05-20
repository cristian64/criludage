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
            private BigInteger N;
            private BigInteger e;
            private BigInteger d;

            public RSA(string e, string d, string N)
            {
                this.e = new BigInteger(e, 10);
                this.d = new BigInteger(d, 10);
                this.N = new BigInteger(N, 10);
            }

            private static string bytesToString(byte[] encrypted)
            {
                String test = "";

                for (int i = 0; i < encrypted.Length; i++)
                {
                    int b = (int)encrypted[i] + 128;
                    if (b > 255)
                    {
                        b -= 256;
                    }
                    test += b.ToString("000");
                }
                return test;
            }

            private static String toString(byte[] encrypted)
            {
                String test = "";
                foreach (byte b in encrypted)
                {
                    test += b + " ";
                }
                return test;
            }

            private byte[] encrypt(byte[] message)
            {
                return (new BigInteger(message)).modPow(e, N).getBytes();
            }

            private byte[] decrypt(byte[] message)
            {
                return (new BigInteger(message)).modPow(d, N).getBytes();
            }

            public String Encriptar(String msg)
            {

                // creo un string de retorno vacio
                String resultado = "";
                // convierto la cadena a BASE64
                msg = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(msg));
                // obtengo los bytes
                byte[] bytes = Encoding.UTF8.GetBytes(msg);
                // parto la cadena en bloques de 64 bytes
                for (int i = 0; i < bytes.Length; i += 64)
                {
                    // el limite sera i+64
                    int limite = i + 64;
                    // si el limite se sale del array
                    if (limite > bytes.Length)
                    {
                        // el limite sera el ultimo
                        limite = bytes.Length;
                    }
                    // creo un array del tamanyo correcto
                    byte[] trozo = new byte[limite - i];
                    // creo un contador para modificar el array actual
                    int cont = 0;
                    // recorro todo el segmento y lo copio en trozo
                    for (int j = i; j < limite; j++)
                    {
                        trozo[cont] = bytes[j];
                        cont++;
                    }
                    // lo encripto
                    trozo = encrypt(trozo);
                    // el array encriptado debe tener un elmentos mas
                    byte[] trozoEncriptado = new byte[129];
                    // si es asi lo asigno
                    if (trozo.Length == 129)
                    {
                        trozoEncriptado = trozo;
                    }
                    // si no lo copio desplazado
                    else
                    {
                        int k = 128;
                        for (int j = trozo.Length - 1; j >= 0; j--)
                        {
                            trozoEncriptado[k] = trozo[j];
                            k--;
                        }
                    }
                    // encripto el trozo y lo acumulo como string en el resultado
                    resultado += bytesToString(trozoEncriptado);
                    Console.WriteLine(bytesToString(trozoEncriptado));
                }
                // devuelvo el resultado
                return resultado;
            }

            public String Desencriptar(String msg)
            {

                // creo un string de retorno vacio
                String resultado = "";
                // recorro el string en bloques de 387 (129*3)
                for (int i = 0; i < msg.Length - 386; i += 387)
                {
                    // extraigo el trozo
                    String trozo = msg.Substring(i, 387);
                    // creo un array de bytes para el trozo
                    byte[] bytes = new byte[129];
                    // creo un contador para recorrerlo
                    int cont = 0;
                    // recorro todo el trozo
                    for (int j = 0; j < trozo.Length - 2; j += 3)
                    {
                        // calculo el byte y lo asigno
                        int k = int.Parse(trozo.Substring(j, 3)) - 128;
                        if (k < 0)
                        {
                            k += 256;
                        }
                        bytes[cont] = (byte)k;
                        cont++;
                    }
                    // acumulo el array desencriptado
                    resultado += Encoding.UTF8.GetString(decrypt(bytes));
                }
                resultado = Encoding.UTF8.GetString(Convert.FromBase64String(resultado));
                // devuelvo el resultado
                return resultado;
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
