using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WinetrackerGen.ApplicationCore.Utils
{
public class Util
{
        public static string GetEncondeMD5(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("La contraseña no puede estar vacía.");
            }

            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }


        public static string Decode (string token)
{
        string json = Jose.JWT.Decode (token, Utils.Util.getKey ());

        return json;
}

public static byte[] getKey ()
{
        /*PROTECTED REGION ID(secretKeyWinetrackerGen.ApplicationCore) ENABLED START*/
        var secretKey = new byte[] { 164, 60, 194, 0, 161, 189, 41, 38, 130, 89, 141, 164, 45, 170, 159, 209, 69, 137, 243, 216, 191, 131, 47, 250, 32, 107, 231, 117, 37, 158, 225, 234 };

        /*PROTECTED REGION END*/

        return secretKey;
}
}
}
