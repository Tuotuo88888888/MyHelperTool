using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WinHelperLibrary.BaiduTranslateHelper
{
    public class BaiduTranslate
    {
        private static readonly object _lock = new object();
        private static BaiduTranslate baiduTranslate;
        
        public static BaiduTranslate Instance()
        {
            if (baiduTranslate == null)
            {
                lock (_lock)
                {
                    if (baiduTranslate == null)
                    {
                        baiduTranslate = new BaiduTranslate();
                    }
                }
            }
            return baiduTranslate;
        }
        
        static readonly Uri _baseAddress = new Uri("https://fanyi-api.baidu.com/");
        static readonly Uri _address = new Uri(_baseAddress, "/api/trans/vip/translate");
        public string ZhToEn(string query)
        {
            #region 定义参数
            string secretKey = "hAE5szu8kNyWkMGIbP_o",
            appid = "20220824001317649",
            q = query,
            from = "zh",
            to = "en",
            salt = new Random().Next(100000).ToString(),
            sign = EncryptString(appid + q + salt + secretKey);

            var data = new
            {
                q,
                from,
                to,
                appid,
                salt,
                sign,
            };
            var valuesout = new NameValueCollection();// 所加参数
            GetNameValueCollection(data, ref valuesout);

            #endregion

            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
            webClient.Encoding = Encoding.UTF8;
            //webClient.UploadValuesCompleted += (send, es) =>
            //{
            //    if (es.Result != null)
            //    {
            //        string str = Encoding.UTF8.GetString(es.Result);
            //        var test = JsonConvert.DeserializeObject<BaiduTranslateResult>(str);
            //        if (test!=null)
            //        {
            //            shearWall.Text = test.trans_result[0].dst;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show(es.Error.Message);
            //    }
            //};
            string result = Encoding.UTF8.GetString(webClient.UploadValues(_address, "POST", valuesout));
            return JsonConvert.DeserializeObject<BaiduTranslateResult>(result).trans_result[0].dst;
        }

        // 计算MD5值
        public string EncryptString(string str)
        {
            MD5 md5 = MD5.Create();
            // 将字符串转换成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            // 调用加密方法
            byte[] byteNew = md5.ComputeHash(byteOld);
            // 将加密结果转换为字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                // 将字节转换成16进制表示的字符串，
                sb.Append(b.ToString("x2"));
            }
            // 返回加密的字符串
            return sb.ToString();
        }

        public void GetNameValueCollection<T>(T Obj, ref NameValueCollection nameValue)
        {
            Type type = typeof(T);
            foreach (var prop in type.GetProperties())
            {
                var key = prop.Name;
                var keyvalue = type.GetProperty(key).GetValue(Obj);
                nameValue.Add(key, keyvalue as string);
            }
        }

    }
}
