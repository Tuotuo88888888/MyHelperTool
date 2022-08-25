using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinHelperLibrary.httphelper
{
    public class MyHttpHelper
    {
        #region 调用API
        /// <summary>
        /// Post调用API返回JSON
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="dic">参数值</param>
        /// <param name="type">调用类型</param>
        /// <returns></returns>
        private static string httpApi(string url, string jsonStr = "",
            string type = "POST")
        {
            if (string.IsNullOrEmpty(url))
            {
                //LogHelper.LogInformation("API链接地址为空，配置INI文件缺失");
                return null;
            }

            string result = "";//返回结果
            try
            {
                Encoding encoding = Encoding.UTF8;
                HttpWebResponse response;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址  
                //if (Globas.token != null)//是否加上Token令牌
                //{
                //    //var headers = request.Headers;
                //    //headers["Authorization"] = "Bearer " + Globas.token.token;
                //    //request.Headers = headers;
                //    request.Headers.Add("Authorization", "Bearer " + Globas.token.token);
                //    request.Credentials = CredentialCache.DefaultCredentials;
                //}
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = type.ToUpper().ToString();//get或者post
                if (!string.IsNullOrEmpty(jsonStr))//Get请求无需拼接此参数
                {
                    byte[] buffer = encoding.GetBytes(jsonStr);
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                }

                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                    reader.Close();
                }
                if (response.StatusCode != HttpStatusCode.OK)//返回响应码非成功格式化数据后返回
                {
                    result = "Exception:" + JsonConvert.DeserializeObject<string>(result);
                }
                return result;
            }
            catch (WebException ex)
            {
                return "Exception:" + ex.Message;
            }
        }

        #endregion

        #region 拼接Get请求地址
        /// <summary>
        /// 将对象属性拼接到Url
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="req">实例对象</param>
        /// <returns></returns>
        public static string getQueryString(string url, object req)
        {
            StringBuilder query = new StringBuilder();
            if (!url.Contains("&"))
                query.Append("?");
            PropertyInfo[] propertys = req.GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                if (pi.CanRead)
                {
                    query.Append($@"{pi.Name}={pi.GetValue(req)}&");
                }
            }

            return url + query.ToString();
        }
        #endregion

        #region 统一请求响应
        /// <summary>
        /// 统一请求响应
        /// </summary>
        /// <param name="Url">接口路径</param>
        /// <param name="cz">操作类型 post/get</param>
        /// <param name="modal">post方式需要传递的值</param>
        /// <param name="msg">错误提示文本</param>
        /// <returns></returns>
        public static string GetDates(string Url, string cz,
            object modal = null, string msg = "")
        {
            LogHelper.LogInformation($"调用接口路径：{Url}");
            string date = " ", jsonDate = "";
            try
            {
                if (modal != null)//实体类不为空则构建POST参数
                    jsonDate = JsonConvert.SerializeObject(modal);
                if (cz == "Get")
                    date = httpApi(Url, null, "GET");
                else
                    date = httpApi(Url, jsonDate);
                if (date.Contains("Exception"))
                {

                    MessageBox.Show(date);
                    LogHelper.LogInformation($"接口返回错误：{msg}");
                    return "Exception";
                }
                else if (date == "true")
                    MessageBox.Show(msg + "执行成功！");
                else if (date == "false")
                    MessageBox.Show(msg + "执行失败！");
                LogHelper.LogInformation($"接口返回：{date}");
                return date;
            }
            catch (Exception ex)
            {
                LogHelper.LogInformation($"调用接口错误：{ex.Message}");//写日志
                return "Exception";
            }



        }
        #endregion
    }
}
