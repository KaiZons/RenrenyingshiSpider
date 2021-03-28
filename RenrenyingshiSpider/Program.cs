using HtmlAgilityPack;
using System;
using System.Text;

namespace RenrenyingshiSpider
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://yyetss.com/list-jingsong-all-1.html";
            string html = HttpHelper.DownloadHtml(url);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("/html/body/div[2]/div/div[1]/div[2]/div"); //通过xPath。获取div;
            foreach (HtmlNode node in nodes)
            {
                string imgPath = node.SelectSingleNode("a/img").Attributes["src"].Value; //获取每个div下的a/img中的src属性;
                string teleplayName = node.SelectSingleNode("div/a/p[1]").InnerText;
                string description = node.SelectSingleNode("div/a/p[2]/span").InnerText;
                Console.WriteLine($"名称：{teleplayName} 描述：{description} 图片路径：{imgPath}");
            }
            Console.ReadLine();
        }
    }
}
