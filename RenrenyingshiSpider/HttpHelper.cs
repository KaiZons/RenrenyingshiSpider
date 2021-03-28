using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RenrenyingshiSpider
{
    public class HttpHelper
    {
        public static string DownloadHtml(string url)
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 30 * 1000; // 30s超时
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.90 Safari/537.36 Edg/89.0.774.63";
            request.ContentType = "text/html charset=UTF-8"; // 编码可以在浏览器的开发者模式的控制台中输入document.charset 获取
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string html = reader.ReadToEnd();
                reader.Close();
                return html;
            }
        }
        
    }
}
