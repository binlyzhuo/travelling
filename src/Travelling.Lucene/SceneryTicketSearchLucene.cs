using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using Travelling.FrameWork;
using Travelling.ViewModel.Dto.Ticket;
using Travelling.ViewModel.Travel;

using util = Lucene.Net.Util;
using store = Lucene.Net.Store;

namespace Travelling.Lucene
{
    /// <summary>
    /// 景点门票相关Lucene查询
    /// </summary>
    public class SceneryTicketSearchLucene
    {
        private static readonly string SceneryLuceneIndexLocation;
        private static SceneryTicketSearchLucene instance;

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static SceneryTicketSearchLucene()
        {
            SceneryLuceneIndexLocation = ConfigurationManager.AppSettings["SceneryLuceneIndexLocation"];
        }

        public static SceneryTicketSearchLucene Instance()
        {
            if(instance==null)
            {
                instance = new SceneryTicketSearchLucene();
            }
            return instance;
        }


        /// <summary>
        /// 创建索引
        /// </summary>
        /// <param name="infos"></param>
        public void CreateSceneryLuceneIndex(List<SceneryInfoDetail> infos)
        {
            string indexLocation = SceneryLuceneIndexLocation;
            store.Directory indexDirectory = store.FSDirectory.Open(new DirectoryInfo(indexLocation));
            Analyzer analyzer = new PanGuAnalyzer();
            bool isCreate = !IndexReader.IndexExists(indexDirectory);
            IndexWriter indexWriter = new IndexWriter(indexDirectory, analyzer, isCreate, IndexWriter.MaxFieldLength.UNLIMITED);

            try
            {
                foreach (var s in infos)
                {
                    Document doc = new Document();

                    doc.Add(new Field("SceneryID", s.SceneryID.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Address", s.Address.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    //doc.Add(new Field("AmountAdvice", s.AmountAdvice.ToString(), Field.Store.YES, Field.Index.ANALYZED));

                    NumericField amountAdviceField = new NumericField("AmountAdvice", Field.Store.YES, true);
                    amountAdviceField.SetIntValue(s.AmountAdvice);
                    doc.Add(amountAdviceField);

                    doc.Add(new Field("BookFlag", s.BookFlag.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("CityID", s.CityID.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("CityName", s.CityName.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("GradeId", s.GradeId.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("GradeInt", s.GradeInt.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("HasPricePolicy", s.HasPricePolicy.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("IfUseCard", s.IfUseCard.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Img", s.ImgBaseUrl + s.Imgs, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Intro", s.Intro.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Lat", s.Lat.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Lon", s.Lon.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("PayMode", s.PayMode.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("ProvinceID", s.ProvinceID.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("ProvinceName", s.ProvinceName.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("SceneryName", s.SceneryName.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("ScenerySummary", s.ScenerySummary.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Themes", s.Themes.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    indexWriter.AddDocument(doc);
                }

                indexWriter.Optimize();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (analyzer != null)
                {
                    analyzer.Close();
                }
                if (indexWriter != null)
                {
                    indexWriter.Dispose();
                }
                if (indexDirectory != null)
                {
                    indexDirectory.Dispose();
                }
            }
        }

        /// <summary>
        /// 索引查询
        /// </summary>
        public List<SceneryInfoDetail> SceneryLuceneIndexSearch(SceneryQueryInfo sceneryQuery, out int totalRecords)
        {
            string indexLocation = SceneryLuceneIndexLocation;
            totalRecords = 0;
            //if (hotelQuery.CityId == 0)
            //    return null;

            store.Directory sceneryinfoDir = store.FSDirectory.Open(new DirectoryInfo(indexLocation));
            Analyzer analyzer = new PanGuAnalyzer();
            BooleanQuery query = new BooleanQuery();

            if (sceneryQuery.ProvinceId > 0)
            {
                var queryProvinceId = new TermQuery(new Term("ProvinceID", sceneryQuery.ProvinceId.ToString()));
                query.Add(queryProvinceId, Occur.MUST);
            }

            if (sceneryQuery.CityID > 0)
            {
                var queryCityID = new TermQuery(new Term("CityID", sceneryQuery.CityID.ToString()));
                query.Add(queryCityID, Occur.MUST);
            }

            if (sceneryQuery.ThemeId > 0)
            {
                var queryTheme = new TermQuery(new Term("Themes", sceneryQuery.ThemeId.ToString()));
                query.Add(queryTheme, Occur.MUST);
            }

            if (sceneryQuery.CityID == 0 && sceneryQuery.ProvinceId == 0 && sceneryQuery.Star == 0 && sceneryQuery.ThemeId == 0)
            {
                if (!string.IsNullOrEmpty(sceneryQuery.KeyWord) && sceneryQuery.KeyWord != "search")
                {
                    QueryParser parserSceneryName = new QueryParser(util.Version.LUCENE_30, "SceneryName", analyzer);
                    var queryAddress = parserSceneryName.Parse(sceneryQuery.KeyWord);
                    query.Add(queryAddress, Occur.MUST);

                    QueryParser parserCityName = new QueryParser(util.Version.LUCENE_30, "CityName", analyzer);
                    var queryCityName = parserCityName.Parse(sceneryQuery.KeyWord);
                    query.Add(queryCityName, Occur.SHOULD);
                }
            }

            var queryPrice = NumericRangeQuery.NewIntRange("AmountAdvice", 1, 99999, true, true);
            query.Add(queryPrice, Occur.MUST);

            if (sceneryQuery.Star >= 0)
            {
                SceneryStarLevel starLevel = (SceneryStarLevel)sceneryQuery.Star;
                var numRangeAtt = (NumberRangeAttribute)typeof(SceneryStarLevel).GetField(starLevel.ToString()).GetCustomAttributes(typeof(NumberRangeAttribute), false).SingleOrDefault();
                int minStar = numRangeAtt.Min;
                int maxStar = numRangeAtt.Max;

                List<int> starList = new List<int>();
                for (int index = minStar; index <= maxStar; index++)
                {
                    starList.Add(index);
                }

                string starCollection = string.Join(" ", starList);
                var queryStar = new QueryParser(util.Version.LUCENE_30, "GradeInt", analyzer).Parse(starCollection);
                query.Add(queryStar, Occur.MUST);
            }

            // order by
            Sort sort = new Sort(new SortField("AmountAdvice", SortField.INT, false));
            if (sceneryQuery.OrderBy == 1)
            {
                sort = new Sort(new SortField("AmountAdvice", SortField.INT, true));
            }
            else
            {
                sort = new Sort(new SortField("AmountAdvice", SortField.INT, false));
            }

            int n = 1000;
            IndexSearcher searcher = new IndexSearcher(sceneryinfoDir, true);
            TopDocs docs = searcher.Search(query, null, n, sort);
            ScoreDoc[] scoreDocs = docs.ScoreDocs;

            int page = sceneryQuery.PageIndex;
            int pagesize = sceneryQuery.PageSize;

            totalRecords = docs.TotalHits;
            int totalPages = totalRecords % pagesize == 0 ? 0 + totalRecords / pagesize : 1 + totalRecords / pagesize;
            page = Math.Min(page, totalPages);

            int startIndex = Math.Max((page - 1) * pagesize, 0);
            int endIndex = Math.Min(page * pagesize - 1, totalRecords);


            if (docs.TotalHits == 0)
                return null;

            List<SceneryInfoDetail> sceneryinfos = new List<SceneryInfoDetail>();
            SceneryInfoDetail sceneryinfo;
            for (int i = startIndex; i < endIndex; i++)
            {
                sceneryinfo = new SceneryInfoDetail();
                Document doc = searcher.Doc(scoreDocs[i].Doc);
                sceneryinfo.SceneryID = Convert.ToInt32(doc.Get("SceneryID"));
                sceneryinfo.Address = doc.Get("Address");
                sceneryinfo.AmountAdvice = doc.Get("AmountAdvice").ToInt32();
                sceneryinfo.BookFlag = doc.Get("BookFlag").ToInt32();
                sceneryinfo.BuyNotice = doc.Get("BuyNotice");
                sceneryinfo.CityID = doc.Get("CityID").ToInt32();
                sceneryinfo.CityName = doc.Get("CityName");
                sceneryinfo.GradeId = doc.Get("GradeId");
                sceneryinfo.GradeInt = doc.Get("GradeInt").ToInt32();
                sceneryinfo.HasPricePolicy = doc.Get("HasPricePolicy").ToInt32();
                sceneryinfo.IfUseCard = doc.Get("IfUseCard").ToInt32();
                sceneryinfo.Imgs = doc.Get("Img");
                sceneryinfo.Lat = doc.Get("Lat");
                sceneryinfo.Lon = doc.Get("Lon");
                sceneryinfo.PayMode = doc.Get("PayMode");
                sceneryinfo.ProvinceID = doc.Get("ProvinceID").ToInt32();
                sceneryinfo.ProvinceName = doc.Get("ProvinceName");
                sceneryinfo.SceneryName = doc.Get("SceneryName");
                sceneryinfo.Themes = doc.Get("Themes");
                sceneryinfos.Add(sceneryinfo);
            }

            return sceneryinfos;
        }

        /// <summary>
        /// 根据城市名称查询
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public List<SceneryInfoDetail> SceneryLuceneIndexSearch(string cityName)
        {
            string indexLocation = SceneryLuceneIndexLocation;
            store.Directory sceneryinfoDir = store.FSDirectory.Open(new DirectoryInfo(indexLocation));
            Analyzer analyzer = new PanGuAnalyzer();
            BooleanQuery query = new BooleanQuery();
            if (!string.IsNullOrEmpty(cityName))
            {
                QueryParser parserCityName = new QueryParser(util.Version.LUCENE_30, "CityName", analyzer);
                var queryCityName = parserCityName.Parse(cityName);
                query.Add(queryCityName, Occur.SHOULD);
            }

            int page = 1;
            int pageSize = 8;
            int start = pageSize * (page - 1);
            int limit = start + pageSize;

            var collector = TopScoreDocCollector.Create(8, false);
            IndexSearcher searcher = new IndexSearcher(sceneryinfoDir, true);
            searcher.Search(query, collector);

            ScoreDoc[] hits = collector.TopDocs(start, limit).ScoreDocs;

            List<SceneryInfoDetail> sceneryinfos = new List<SceneryInfoDetail>();
            SceneryInfoDetail sceneryinfo;
            for (int i = 0; i < hits.Count(); i++)
            {
                sceneryinfo = new SceneryInfoDetail();
                Document doc = searcher.Doc(hits[i].Doc);
                sceneryinfo.SceneryID = Convert.ToInt32(doc.Get("SceneryID"));
                sceneryinfo.Address = doc.Get("Address");
                sceneryinfo.AmountAdvice = doc.Get("AmountAdvice").ToInt32();
                sceneryinfo.BookFlag = doc.Get("BookFlag").ToInt32();
                sceneryinfo.BuyNotice = doc.Get("BuyNotice");
                sceneryinfo.CityID = doc.Get("CityID").ToInt32();
                sceneryinfo.CityName = doc.Get("CityName");
                sceneryinfo.GradeId = doc.Get("GradeId");
                sceneryinfo.GradeInt = doc.Get("GradeInt").ToInt32();
                sceneryinfo.HasPricePolicy = doc.Get("HasPricePolicy").ToInt32();
                sceneryinfo.IfUseCard = doc.Get("IfUseCard").ToInt32();
                sceneryinfo.Imgs = doc.Get("Img");
                sceneryinfo.Lat = doc.Get("Lat");
                sceneryinfo.Lon = doc.Get("Lon");
                sceneryinfo.PayMode = doc.Get("PayMode");
                sceneryinfo.ProvinceID = doc.Get("ProvinceID").ToInt32();
                sceneryinfo.ProvinceName = doc.Get("ProvinceName");
                sceneryinfo.SceneryName = doc.Get("SceneryName");
                sceneryinfo.Themes = doc.Get("Themes");
                sceneryinfos.Add(sceneryinfo);
            }

            return sceneryinfos;
        }

        /// <summary>
        /// 删除索引文件
        /// </summary>
        public static void DeleteSceneryLuceneIndex()
        {
           
            if (Directory.Exists(SceneryLuceneIndexLocation))
            {
                Directory.Delete(SceneryLuceneIndexLocation, true);
            }
        }
    }
}
