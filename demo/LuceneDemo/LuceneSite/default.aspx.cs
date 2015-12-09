using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lucene.Net;
using Lucene.Net.Index;
using io = System.IO;
using store = Lucene.Net.Store;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using PanGu.Framework;

//using Lucene.Net.Store;

//http://outofmemory.cn/code-snippet/959/c-usage-Lucene-net-create-index-achieve-search-code-example
namespace LuceneSite
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string indexLocation = Server.MapPath("~/searchlucene");
            if(io.Directory.Exists(indexLocation))
            {
                Directory.Delete(indexLocation,true);
            }
            //Directory.CreateDirectory(indexLocation);
            store.Directory indexDirectory = store.FSDirectory.Open(new io.DirectoryInfo(indexLocation));
            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            IndexWriter writer = null;
            try
            {
                bool isCreate = !Lucene.Net.Index.IndexReader.IndexExists(indexDirectory);
                writer = new IndexWriter(indexDirectory,analyzer,isCreate,IndexWriter.MaxFieldLength.UNLIMITED);

                foreach(var item in Get())
                {
                    Document doc = new Document();
                    doc.Add(new Field("id",item.Id,Field.Store.YES,Field.Index.ANALYZED));
                    doc.Add(new Field("classid",item.ClassId,Field.Store.YES,Field.Index.NOT_ANALYZED));
                    doc.Add(new Field("classname", item.ClassName, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("title", item.Title, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("summary", item.Summary, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("createtime", item.CreateTime.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                    writer.AddDocument(doc);
                }

                writer.Optimize();


            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                if(analyzer!=null)
                {
                    analyzer.Close();
                }
                if(writer!=null)
                {
                    writer.Dispose();
                }
                if(indexDirectory!=null)
                {
                    indexDirectory.Dispose();
                }
            }
        }

        private void IsIndexExists(out bool created,string sIndexPath)
        {
            created = false;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string k = "体育新闻";
            string indexLocation = Server.MapPath("~/searchlucene");
            var version = Lucene.Net.Util.Version.LUCENE_30;
            store.Directory indexDirectory = store.FSDirectory.Open(new DirectoryInfo(indexLocation));
            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            IndexSearcher searcher = null;
            try
            {
                searcher = new IndexSearcher(indexDirectory,true);
                string[] fields = { "title","summary" };
                BooleanQuery booleanQuery = new BooleanQuery();

                MultiFieldQueryParser parse = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_30,fields,analyzer);
                Query query = parse.Parse(k);

                Query query1 = new TermQuery(new Term("id","1"));
                Query query2 = new TermQuery(new Term("classname",k));
                Query query3 = new QueryParser(version,"title",analyzer).Parse(k);
                Query query4 = new PrefixQuery(new Term("classname",k));

                Query query5 = new QueryParser(version, "title", analyzer).Parse(k);
                TermRangeQuery query6 = new TermRangeQuery("createtime", "2012-1-3", "2012-5-3", true, true);

                //booleanQuery.Add(query3,Occur.MUST);
                booleanQuery.Add(query2, Occur.MUST);

                TopDocs ts = searcher.Search(booleanQuery,null,100);
                int recCount = ts.TotalHits;

                ScoreDoc[] hits = ts.ScoreDocs;
                List<Article> list = new List<Article>();

                foreach(var item in hits)
                {
                    list.Add(new Article() { 
                      Id = searcher.Doc(item.Doc).Get("id"),
                      ClassId = searcher.Doc(item.Doc).Get("classid"),
                      ClassName = searcher.Doc(item.Doc).Get("classname"),
                      Title = searcher.Doc(item.Doc).Get("title"),
                      Summary = searcher.Doc(item.Doc).Get("summary"),
                      Score = searcher.Doc(item.Doc).Get("score"),
                      CreateTime = DateTime.Parse(searcher.Doc(item.Doc).Get("createtime"))
                    });
                }

            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                if(searcher!=null)
                {
                    searcher.Dispose();
                }
            }
        }

        public List<Article> Get()
        {
            List<Article> list = new List<Article>();
            list.Add(new Article() { Id = "1", ClassId = "1", ClassName = "体育新闻", Title = "微软发布MVC4.0了", Summary = "微软发布MVC4.0了，此版本更加强大", CreateTime = DateTime.Parse("2012-2-3") });
            list.Add(new Article() { Id = "2", ClassId = "1", ClassName = "IT新闻", Title = "跟谷歌测试工程师的对话", Summary = "本文主人公Alan是谷歌的一名的软件测试工程师，他的工作对象是谷歌的DoubleClick广告管理系统(Bid Manager)，这个系统提供让广告代理商和广告客户在多个广告上进行报价竞标的功能。", CreateTime = DateTime.Parse("2012-3-3") });
            list.Add(new Article() { Id = "3", ClassId = "1", ClassName = "体育 新闻", Title = "好的程序员应该熟悉的几门编程语言", Summary = "如果想成为一个好的程序员，甚至架构师、技术总监等，显然只精通一种编程语言是不够的，还应该在常见领域学会几门编程语言，正如我们要成为高级人才不仅要会中文还要会英文", CreateTime = DateTime.Parse("2012-4-3") });
            list.Add(new Article() { Id = "4", ClassId = "2", ClassName = "娱乐新闻", Title = "Javascript开发《三国志曹操传》-开源讲座(五)-可移动地图的实现", Summary = "这一讲的内容很简单，大家理解起来会更快。因此我只对重点加以分析，其他的就轮到大家思考哦！首先来说，我对游戏开发可以算是不怎么深入，因为现在的程序员爱用canvas，我却就只会拿几个div凑和。", CreateTime = DateTime.Parse("2012-5-3") });
            list.Add(new Article() { Id = "5", ClassId = "2", ClassName = "体育新闻", Title = "Android之BaseExpandableListAdapter使用心得", Summary = " 但是我最近做那个QQ项目是遇到一个问题，如果给这个ExpandableListView添加动态从网上获取的数据呢？前面跟大家分享的时候，是用了静态的数据，很好处理。", CreateTime = DateTime.Parse("2012-6-3") });
            list.Add(new Article() { Id = "6", ClassId = "3", ClassName = "sports news", Title = "对话CSDN蒋涛：微软移动互联网马太效应不可避免，小团队需学会利用平台", Summary = "CSDN是全球最大的中文IT社区，也是雷锋网最重要的合作伙伴之一，自1999年创办至今，有着非常强大的业界影响力和号召力，其专注IT信息传播、技术交流、教育培训和专业技术人才服务，在2012年移动开发者大会即将举办之际，雷锋网对CSDN的掌门人蒋涛做了一次专访，一起探讨移动互联网的新技术浪潮和下一波发展趋势。", CreateTime = DateTime.Parse("2012-7-3") });
            list.Add(new Article() { Id = "7", ClassId = "3", ClassName = "体育新闻", Title = "基于MySQL的分布式事务控制方案", Summary = "基于MySQL的分布式事务控制方案", CreateTime = DateTime.Parse("2012-8-3") });
            list.Add(new Article() { Id = "8", ClassId = "4", ClassName = "sports news", Title = "IOS和Android开发的一些个人感受", Summary = "最近公司的产品 Android版本第二版也算到了收尾，新加了几个功能性模块，我基本也就捡了几个好玩的模块做了下。", CreateTime = DateTime.Parse("2012-9-3") });
            list.Add(new Article() { Id = "9", ClassId = "5", ClassName = "IT资讯", Title = "Google Code的简单使用", Summary = "google code简介：用于管理代码的仓库，反正我是这么理解的。就比我们在公司的时候也会有个用于存放公司代码的主机一样，google同样给我们提供了这样的一个host。这样我们可以在不同电脑不同地方随时的checkout，commit，同时分享我们的项目。", CreateTime = DateTime.Parse("2012-10-3") });
            list.Add(new Article() { Id = "10", ClassId = "33", ClassName = "IT资讯", Title = "谷歌在印度推Gmail免费短信服务", Summary = "歌一直在努力桥接发展中国家功能手机SMS服务和Gmail之间的服务，这不，近日谷歌在印度推出“Gmail SMS”服务，这使得印度的Gmail用户可以从Gmail的窗口发送信息到手机上并且接受聊天信息的回复，目前谷歌的这项服务已经得到印度的八大运营商的支持。", CreateTime = DateTime.Parse("2012-11-3") });
            list.Add(new Article() { Id = "11", ClassId = "11", ClassName = "体育新闻", Title = "鲍尔默：微软新时代 软硬结合“赢”未来", Summary = "微软CEO鲍尔默在年度公开信中表示，微软在未来将紧密结合硬件和软件。鲍尔默认为，这是微软的一个新时代。“我们看到了前所未有的机会，我们对此很兴奋，并且保持着乐观的心态。”", CreateTime = DateTime.Parse("2012-12-3") });
            return list;
        }
    }
}