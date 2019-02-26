using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace pracainz.Notifications
{
    public class SimpleAES
    {
        private byte[] Key = { 123, 217, 19, 11, 24, 26, 85, 45, 1, 184, 27, 162, 37, 112, 222, 209, 34, 24, 56, 144, 173, 53, 19, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
        private byte[] Vector = { 146, 64, 191, 1, 23, 3, 113, 119, 231, 121, 25, 112, 79, 32, 67, 156 };
        private ICryptoTransform EncryptorTransform, DecryptorTransform;

        public SimpleAES(byte[] key = null)
        {
            Key = key ?? Key;
            RijndaelManaged rm = new RijndaelManaged();
            EncryptorTransform = rm.CreateEncryptor(Key, Vector);
            DecryptorTransform = rm.CreateDecryptor(Key, Vector);
        }

        public SimpleAES(string password) :
            this(SHA256Managed.Create().ComputeHash(Encoding.UTF8.GetBytes(password)))
        { }

        public string EncryptToHex(string input)
        {
            byte[] ba = Encrypt(input);
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public string DecryptFromHex(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return Decrypt(bytes);
        }

        public string EncryptToString(string TextValue)
        {
            return ByteArrToString(Encrypt(TextValue));
        }

        public byte[] Encrypt(string TextValue)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(TextValue);
            MemoryStream memoryStream = new MemoryStream();

            /*
             * We will have to write the unencrypted bytes to the stream,
             * then read the encrypted result back from the stream.
             */
            #region Write the decrypted value to the encryption stream
            CryptoStream cs = new CryptoStream(memoryStream, EncryptorTransform, CryptoStreamMode.Write);
            cs.Write(bytes, 0, bytes.Length);
            cs.FlushFinalBlock();
            #endregion

            #region Read encrypted value back out of the stream
            memoryStream.Position = 0;
            byte[] encrypted = new byte[memoryStream.Length];
            memoryStream.Read(encrypted, 0, encrypted.Length);
            #endregion

            //Clean up.
            cs.Close();
            memoryStream.Close();

            return encrypted;
        }

        /// The other side: Decryption methods
        public string DecryptString(string EncryptedString)
        {
            return Decrypt(StrToByteArray(EncryptedString));
        }
        /// Decryption when working with byte arrays.    
        public string Decrypt(byte[] EncryptedValue)
        {
            #region Write the encrypted value to the decryption stream
            MemoryStream encryptedStream = new MemoryStream();
            CryptoStream decryptStream = new CryptoStream(encryptedStream, DecryptorTransform, CryptoStreamMode.Write);
            decryptStream.Write(EncryptedValue, 0, EncryptedValue.Length);
            decryptStream.FlushFinalBlock();
            #endregion

            #region Read the decrypted value from the stream.
            encryptedStream.Position = 0;
            Byte[] decryptedBytes = new Byte[encryptedStream.Length];
            encryptedStream.Read(decryptedBytes, 0, decryptedBytes.Length);
            encryptedStream.Close();
            #endregion
            return Encoding.UTF8.GetString(decryptedBytes);
        }

        /// Convert a string to a byte array.  NOTE: Normally we'd create a Byte Array from a string using an ASCII encoding (like so).
        //      System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        //      return encoding.GetBytes(str);
        // However, this results in character values that cannot be passed in a URL.  So, instead, I just
        // lay out all of the byte values in a long string of numbers (three per - must pad numbers less than 100).
        public byte[] StrToByteArray(string str)
        {
            if (str.Length == 0)
                throw new Exception("Invalid string value in StrToByteArray");

            byte val;
            byte[] byteArr = new byte[str.Length / 3];
            int i = 0;
            int j = 0;
            do
            {
                val = byte.Parse(str.Substring(i, 3));
                byteArr[j++] = val;
                i += 3;
            }
            while (i < str.Length);
            return byteArr;
        }

        // Same comment as above.  Normally the conversion would use an ASCII encoding in the other direction:
        //      System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
        //      return enc.GetString(byteArr);    
        public string ByteArrToString(byte[] byteArr)
        {
            byte val;
            string tempStr = "";
            for (int i = 0; i <= byteArr.GetUpperBound(0); i++)
            {
                val = byteArr[i];
                if (val < 10)
                    tempStr += "00" + val.ToString();
                else if (val < 100)
                    tempStr += "0" + val.ToString();
                else
                    tempStr += val.ToString();
            }
            return tempStr;
        }

    }
}
