using OpenDataImport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OpenDataImport
{
    public class Porgram
    {
        static void Main(string[] args)
        {
            var nodes = FindOpenData();
            ShowOpenData(nodes);
            Console.ReadKey();

        }
        static List<OpenData> FindOpenData()
        {
            List<OpenData> result = new List<OpenData>();

            var ss = XElement.Load(@"C:\Users\user\Desktop\軟體工程\data.xml");
            var xml = XElement.Load(@"C:\Users\user\Desktop\軟體工程\data.xml");

            var nodes = xml.Descendants("node").ToList();

            for (var i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                OpenData item = new OpenData();

                item.id = int.Parse(getValue(node, "id"));
                item.資料集名稱 = getValue(node, "資料集名稱");
                item.主要欄位說明 = getValue(node, "主要欄位說明");
                item.服務分類 = getValue(node, "服務分類");
                result.Add(item);
            }
            return result;
        }

        private static string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value?.Trim();
        }

        public static void ShowOpenData(List<OpenData> nodes)
        {
            //Console.WriteLine(string.Format("共收到{0}筆的資料", nodes.Count));
            nodes.GroupBy(node => node.資料集名稱).ToList()
                .ForEach(group =>
                {
                    var key = group.Key;
                    var groupDatas = group.ToList();
                    var message = $"資料集名稱:{key},共有{groupDatas.Count()}筆資料";
                    Console.WriteLine(message);

                });
        }
    }
}