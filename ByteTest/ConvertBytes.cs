using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteTest
{
    public class ConvertBytes
    {
        /// <summary>
        /// 按照先后顺序合并字节数组，并返回合并后的字节数组。
        /// </summary>
        /// <param name="firstBytes">第一个字节数组</param>
        /// <param name="firstIndex">第一个字节数组的开始截取索引</param>
        /// <param name="firstLength">第一个字节数组的截取长度</param>
        /// <param name="secondBytes">第二个字节数组</param>
        /// <param name="secondIndex">第二个字节数组的开始截取索引</param>
        /// <param name="secondLength">第二个字节数组的截取长度</param>
        /// <returns></returns>
        public static byte[] ToArray(byte[] firstBytes, int firstIndex, int firstLength, byte[] secondBytes, int secondIndex, int secondLength)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write(firstBytes, firstIndex, firstLength);
                bw.Write(secondBytes, secondIndex, secondLength);

                bw.Close();
                bw.Dispose();

                return ms.ToArray();
            }
        }
        /// <summary>
        /// byte数组转化成16进制格式
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes)
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append("0x" + bytes[i].ToString("X2") + ",");
                }
                hexString = strB.ToString();
            }
            return hexString;
        }
        /// <summary>
        /// 字符串转成16进制(ascill码的16进制)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string StringToAscaillHexString(string s)
        {
            byte[] b = Encoding.UTF8.GetBytes(s);//按照指定编码将string编程字节数组
            string result = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符，以%隔开
            {
                result += Convert.ToString(b[i], 16);
            }
            return result;
        }
        /// <summary>
        /// 16进制字符串转byte数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] ConvertHexStringToByteArray(string hexString, string strSplit, int num)
        {
            if (strSplit.Equals("") == false)
                hexString = hexString.Replace(strSplit, "");
            if (hexString.Length == 1)
                hexString = "0" + hexString;
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            byte[] receiveBytes;
            if (num == 0)
                receiveBytes = returnBytes;
            else
            {
                receiveBytes = new byte[num];
                Array.Copy(returnBytes, receiveBytes, returnBytes.Length);
            }
            return receiveBytes;
        }
        /// <summary>
        /// 把Byte数组（16进制ASCII）转换成字符串
        /// </summary>
        /// <param name="bytArray"></param>
        /// <param name="nStart"></param>
        /// <param name="nLen"></param>
        public static string ConvertAsciiByteArrayToString(byte[] bytArray, int nStart, int nLen)
        {
            byte[] bytLenArray = new byte[nLen];
            System.Array.Copy(bytArray, nStart, bytLenArray, 0, bytLenArray.Length);
            string strValue = System.Text.Encoding.ASCII.GetString(bytLenArray);
            int nDataLen = strValue.IndexOf("\0");
            if (nDataLen >= 0)
                strValue = strValue.Substring(0, nDataLen);
            return strValue;
        }
    }
}
