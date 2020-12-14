using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ChatClient
{
	public static class Cifrado
	{
		// se define el tamaño del key y del vector
		private static  int tamanyoClave = 32;
		private static  int tamanyoVector = 16;

		private static string clave;
		// Define la palabra clave para el cifrado y
		public static string Clave { 
			get { return clave; } 
			set { clave = value; } 
		}
		//private static string Clave = "CHAT C#";
		private static string Vector = "WITH WCF";

		// se convierte el vector y la key a bytes
		public static byte[] key { 
			get { 
				if(Clave.Length > 3)
                {
					return UTF8Encoding.UTF8.GetBytes(Clave);
                }
                else
                {
					return null;
				}
			} 
		}
		public static byte[] IV = UTF8Encoding.UTF8.GetBytes(Vector);

		public static string CifradoTexto(String txtPlano)
		{
			byte[] Key = key;
			Array.Resize(ref Key, tamanyoClave);
			Array.Resize(ref IV, tamanyoVector);

			// se instancia el Rijndael
			Rijndael RijndaelAlg = Rijndael.Create();

			// se establece cifrado
			MemoryStream memoryStream = new MemoryStream();

			// se crea el flujo de datos de cifrado
			CryptoStream cryptoStream = new CryptoStream(memoryStream,
				RijndaelAlg.CreateEncryptor(Key, IV),
				CryptoStreamMode.Write);

			// se obtine la información a cifrar
			byte[] txtPlanoBytes = UTF8Encoding.UTF8.GetBytes(txtPlano);

			// se cifran los datos
			cryptoStream.Write(txtPlanoBytes, 0, txtPlanoBytes.Length);
			cryptoStream.FlushFinalBlock();

			// se obtinen los datos cifrados
			byte[] cipherMessageBytes = memoryStream.ToArray();

			// se cierra todo
			memoryStream.Close();
			cryptoStream.Close();

			// Se devuelve la cadena cifrada
			return Convert.ToBase64String(cipherMessageBytes);
		}

		public static string DescifradoTexto(String txtCifrado)
		{
			byte[] Key = key;
			Array.Resize(ref Key, tamanyoClave);
			Array.Resize(ref IV, tamanyoVector);

			// se obtienen los bytes para el cifrado
			byte[] cipherTextBytes = Convert.FromBase64String(txtCifrado);

			// se almacenan los datos descifrados
			byte[] plainTextBytes = new byte[cipherTextBytes.Length]; //Cifrado Rijndael AES con C#

			// se crea una instancia del Rijndael			
			Rijndael RijndaelAlg = Rijndael.Create();

			// se crean los datos cifrados
			MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

			// se descifran los datos
			CryptoStream cryptoStream = new CryptoStream(memoryStream,
				RijndaelAlg.CreateDecryptor(Key, IV),
				CryptoStreamMode.Read);

			// se obtienen datos descifrados
			int decryptedByteCount = 0;
            try
            {
				decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
			}
            catch (System.Security.Cryptography.CryptographicException)
            {
				MessageBox.Show("Incapaz de descifrar");
            }

			// se cierra todo
			memoryStream.Close();
			cryptoStream.Close();

			// se devuelve los datos descifrados
			return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
		}
	}
}