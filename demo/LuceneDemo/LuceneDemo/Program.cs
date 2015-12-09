using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucene.Net;
//using Lucene.Net.Store;
using Lucene.Net.Analysis;
using Lucene.Net.Search;
using Lucene.Net.Documents;
using Lucene.Net.QueryParsers;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace LuceneDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Token();
            //CreateIndex();
            //Search();

            //GetNumberPrices();
            //RegexTest();
            //LoadCacheKeys();
            LoadMenus();
            Console.WriteLine("Get console....");
            Console.ReadLine();
        }

        static void GetNumberPrices()
        {
            Type enumType = typeof(HotelPriceLevel);
            //var enumTypes = Enum.GetValues(enumType);
            //var fields = enumType.GetField(HotelPriceLevel.Below150.ToString());
            //var att = (NumberRangeAttribute)fields.GetCustomAttributes(typeof(NumberRangeAttribute), false).SingleOrDefault();


            var hotelPrices = from int val in Enum.GetValues(enumType)
                              let field = enumType.GetField(Enum.GetName(enumType, val))
                              let att = (NumberRangeAttribute)field.GetCustomAttributes(typeof(NumberRangeAttribute), false).SingleOrDefault()
                              select att.Min+"-"+att.Max;


            hotelPrices.ToList().ForEach(u => {
                Console.WriteLine(u);
            });
            //Console.WriteLine(att.Min);
        }

        static void LoadMenus()
        {
            Type enumType = typeof(TopMenuSetting);

            var menuSettings = from int val in Enum.GetValues(enumType)
                               let field = enumType.GetField(Enum.GetName(enumType, val))
                               let att = (MenuUrlAttribute)field.GetCustomAttributes(typeof(MenuUrlAttribute), false).SingleOrDefault()
                               select att.Title;
            foreach(var m in menuSettings)
            {
                Console.WriteLine(m);
            }
        }
        static void Token()
        {
            Console.WriteLine("测试分词");
            Lucene.Net.Analysis.Standard.StandardAnalyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            string str = "my name is julian.zhu,欢迎访问我的个人网站www.zhuzhusoft.com";
            System.IO.StringReader reader = new StringReader(str);
            Lucene.Net.Analysis.TokenStream ts = analyzer.TokenStream(str,reader);
            bool hasNext = ts.IncrementToken();
            Lucene.Net.Analysis.Tokenattributes.ITermAttribute ita;
            while(hasNext)
            {
                ita = ts.GetAttribute<Lucene.Net.Analysis.Tokenattributes.ITermAttribute>();
                Console.Write(ita.Term+"|");
                hasNext = ts.IncrementToken();
            }
            Console.WriteLine();
            ts.CloneAttributes();
            reader.Close();
            analyzer.Close();
        }

        static void CreateIndex()
        {
            Console.WriteLine("测试创建索引");
            Analyzer analyzer = null;
            analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            DirectoryInfo dirInfo = new DirectoryInfo("luceneIndex");
            var directory = Lucene.Net.Store.FSDirectory.Open(dirInfo);
            IndexWriter writer = new Lucene.Net.Index.IndexWriter(directory,analyzer,true,IndexWriter.MaxFieldLength.LIMITED);
            CreateIndex(writer,"小周","21","网管");
            CreateIndex(writer, "小朱", "21", "网管");
            CreateIndex(writer, "小王", "21", "程序员");
            CreateIndex(writer, "小钱", "21", "网页设计师");
            CreateIndex(writer, "小沈", "21", "平面设计师");
            CreateIndex(writer, "小范", "21", "程序员");
        }

        static void CreateIndex(IndexWriter writer,string title,string age,string content)
        {
           try
           {
               Document doc = new Document();
               doc.Add(new Field("name",title,Field.Store.YES,Field.Index.ANALYZED));
               doc.Add(new Field("age", age, Field.Store.YES, Field.Index.NO));
               doc.Add(new Field("job", content, Field.Store.YES, Field.Index.ANALYZED));
               doc.Add(new Field("createdate",DateTime.Now.AddMonths(-1).ToString("yyyyMMdd"),Field.Store.YES,Field.Index.ANALYZED));
               writer.AddDocument(doc);
           }
           catch(FileNotFoundException fnEx)
           {
               throw fnEx;
           }
           catch(Exception ex)
           {
               throw ex;
           }
        }

        static void Search()
        {
            Console.WriteLine("测试搜索");
            string keyword = "设计";
            string field = "job";
            Analyzer analyzer = null;
            analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, field, analyzer);
            Query query = parser.Parse(keyword);

            int n = 1000;
            DirectoryInfo dirInfo = System.IO.Directory.CreateDirectory("luceneIndex");
            Lucene.Net.Store.Directory directory = Lucene.Net.Store.FSDirectory.Open(dirInfo);
            IndexSearcher searcher = new IndexSearcher(directory,true);
            TopDocs docs = searcher.Search(query, null, n);
            if(docs==null||docs.TotalHits==0)
            {
                Console.WriteLine("没有结果");
            }
            else
            {
                int counter = 1;
                foreach(ScoreDoc sd in docs.ScoreDocs)
                {
                    try
                    {
                        Document doc = searcher.Doc(sd.Doc);
                        string name = doc.Get("name");
                        string age = doc.Get("name");

                        string job = doc.Get("job");
                        string createdate = doc.Get("createdate");
                        string result = string.Format("这是第{0}个,name为{1},age{2},createdate:{3}",counter,name,age,createdate,job);
                        Console.WriteLine(result);
                    }
                    catch(Exception ex)
                    {

                    }
                    counter++;
                }
            }
        }

        //====================================
        static void Token2()
        {
            Analyzer analyer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            TokenStream tokenStream = analyer.TokenStream("", new StringReader("Hello Lucene.Net,我1爱1你China"));
            //Lucene.Net.Analysis.Token token = tokenStream.;
            while(tokenStream.IncrementToken())
            {

            }
            //tokenStream.n
        }

        static void RegexTest()
        {
            string oldUrl = "bbs.aspx?floor=1";
            Regex r = new Regex(@"floor=\d");
            string newUrl = r.Replace(oldUrl,"a=1",1);
        }

        static void LoadCacheKeys()
        {
            Type type= typeof(CacheKeys);
            

            var fields = from it in type.GetFields()
                         let des = (DescriptionAttribute)it.GetCustomAttributes(typeof(DescriptionAttribute), false).SingleOrDefault()
                         let text = des.Description
                         select new {filedName=it.Name,desc = text,value = it.GetValue(it) };

            foreach(var f in fields)
            {
                Console.WriteLine(f.filedName+"---"+f.desc+"----"+f.value);
            }
        }
    }
}
