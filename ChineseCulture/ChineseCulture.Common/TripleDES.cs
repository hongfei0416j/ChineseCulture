using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCulture.Common
{
    public class TripleDES
    {
        public static readonly TripleDES TripleDESInstance = new TripleDES();
        public TripleDES() { }

        #region 使用 给定密钥字符串 加密/解密string
        /// <summary>
        /// 使用给定密钥字符串加密string
        /// </summary>
        /// <param name="original">原始文字</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public string Encrypt(string original)
        {
            string str_Key = "HF";
            byte[] bt_buff = System.Text.Encoding.Default.GetBytes(original);
            byte[] bt_key = System.Text.Encoding.Default.GetBytes(str_Key);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(bt_key);
            des.Mode = CipherMode.ECB;

            byte[] bt_EncryptText = des.CreateEncryptor().TransformFinalBlock(bt_buff, 0, bt_buff.Length);
            return Convert.ToBase64String(bt_EncryptText);
        }

        /// <summary>
        /// 使用给定密钥字符串加密string
        /// </summary>
        /// <param name="original">原始文字</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public string Encrypt(string original, string str_Key)
        {
            byte[] bt_buff = System.Text.Encoding.Default.GetBytes(original);
            byte[] bt_key = System.Text.Encoding.Default.GetBytes(str_Key);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(bt_key);
            des.Mode = CipherMode.ECB;

            byte[] bt_EncryptText = des.CreateEncryptor().TransformFinalBlock(bt_buff, 0, bt_buff.Length);
            return Convert.ToBase64String(bt_EncryptText);
        }

        /// <summary>
        /// 使用给定密钥字符串解密string,返回指定编码方式明文
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>正確返回明文,錯誤返回空</returns>
        public string Decrypt(string str_Encrypted)
        {
            string str_Key = "HF";
            byte[] bt_buff = Convert.FromBase64String(str_Encrypted);
            byte[] bt_key = Encoding.Default.GetBytes(str_Key);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(bt_key);
            des.Mode = CipherMode.ECB;
            try
            {
                byte[] bt_DecryptText = des.CreateDecryptor().TransformFinalBlock(bt_buff, 0, bt_buff.Length);
                return Encoding.Default.GetString(bt_DecryptText);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// 使用给定密钥字符串解密string,返回指定编码方式明文
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>正確返回明文,錯誤返回空</returns>
        public string Decrypt(string str_Encrypted, string str_Key)
        {
            byte[] bt_buff = Convert.FromBase64String(str_Encrypted);
            byte[] bt_key = Encoding.Default.GetBytes(str_Key);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(bt_key);
            des.Mode = CipherMode.ECB;
            try
            {
                byte[] bt_DecryptText = des.CreateDecryptor().TransformFinalBlock(bt_buff, 0, bt_buff.Length);
                return Encoding.Default.GetString(bt_DecryptText);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }
        #endregion

        #region  使用 给定密钥 加密/解密/byte[]

        /// <summary>
        /// 生成MD5摘要
        /// </summary>
        /// <param name="original">数据源</param>
        /// <returns>摘要</returns>
        private byte[] MakeMD5(byte[] original)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyhash = hashmd5.ComputeHash(original);
            hashmd5 = null;
            return keyhash;
        }
        #endregion
    }
}
