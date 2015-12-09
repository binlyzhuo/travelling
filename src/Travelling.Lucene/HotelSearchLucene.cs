using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Travelling.FrameWork;
using util = Lucene.Net.Util;
using store = Lucene.Net.Store;
using System.Configuration;
using Travelling.ViewModel.Lucene;
using Travelling.ViewModel.Travel;

namespace Travelling.Lucene
{
    /// <summary>
    /// 酒店信息索引相关操作
    /// </summary>
    public class HotelSearchLucene
    {
        private readonly string HotelLuceneIndexLocation;
        private static HotelSearchLucene instance;


        /// <summary>
        /// 构造函数
        /// </summary>
        private HotelSearchLucene()
        {
            HotelLuceneIndexLocation = ConfigurationManager.AppSettings["HotelLuceneIndexLocation"];
        }

        public static HotelSearchLucene GetInstance()
        {
            //if (instance == null)
            //{
            //    instance = new HotelSearchLucene();
            //}
            //return instance;
            return new HotelSearchLucene();
        }

        /// <summary>
        /// 创建索引
        /// </summary>
        /// <param name="hotelinfo"></param>
        public void HotelInfoIndex(List<HotelLuceneIndexInfo> hotelinfos)
        {
            string indexLocation = HotelLuceneIndexLocation;
            store.Directory indexDirectory = store.FSDirectory.Open(new DirectoryInfo(indexLocation));
            Analyzer analyzer = new PanGuAnalyzer();
            bool isCreate = !IndexReader.IndexExists(indexDirectory);
            IndexWriter indexWriter = new IndexWriter(indexDirectory, analyzer, isCreate, IndexWriter.MaxFieldLength.UNLIMITED);

            try
            {
                List<string> searchKeyWords;
                foreach (var hotelinfo in hotelinfos)
                {
                    searchKeyWords = new List<string>();
                    searchKeyWords.Add(hotelinfo.HotelName);
                    searchKeyWords.Add(hotelinfo.AddressLine);
                    if(!string.IsNullOrEmpty(hotelinfo.BrandName))
                    {
                        searchKeyWords.Add(hotelinfo.BrandName);
                    }
                    
                    if(!string.IsNullOrEmpty(hotelinfo.RefPoints))
                    {
                        searchKeyWords.Add(hotelinfo.RefPoints);
                    }
                    if(!string.IsNullOrEmpty(hotelinfo.LocationName))
                    {
                        searchKeyWords.Add(hotelinfo.LocationName);
                    }
                    searchKeyWords.Add(hotelinfo.Description);
                    Document doc = new Document();
                    doc.Add(new Field("HotelID", hotelinfo.HotelID.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("HotelName", hotelinfo.HotelName, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("HotelCityCode", hotelinfo.HotelCityCode.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("CityName", hotelinfo.CityName, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("HotelStarRate", hotelinfo.HotelStarRate.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    NumericField amountBeforeTaxField = new NumericField("AmountBeforeTax", Field.Store.YES, true);
                    amountBeforeTaxField.SetIntValue(hotelinfo.AmountBeforeTax);
                    doc.Add(amountBeforeTaxField);
                    doc.Add(new Field("ListAmount", hotelinfo.ListAmount.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("BrandName", hotelinfo.BrandName, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("BrandCode", hotelinfo.BrandCode.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("HotelImg", hotelinfo.HotelImg, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("AddressLine", hotelinfo.AddressLine, Field.Store.YES, Field.Index.ANALYZED));

                    doc.Add(new Field("LocationID", hotelinfo.LocationId.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("LocationName", hotelinfo.LocationName, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Longitude", hotelinfo.Longitude, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Latitude", hotelinfo.Latitude, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("UnionId", hotelinfo.UnionId.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("ZhunaHotelID", hotelinfo.ZhunaHotelId.ToString(), Field.Store.YES, Field.Index.ANALYZED));

                    NumericField commServiceRateField = new NumericField("CommServiceRate", Field.Store.YES, true);
                    commServiceRateField.SetFloatValue(hotelinfo.CommServiceRate);
                    doc.Add(commServiceRateField);

                    NumericField ctripCommRateField = new NumericField("CtripCommRate", Field.Store.YES, true);
                    ctripCommRateField.SetFloatValue(hotelinfo.CtripCommRate);
                    doc.Add(ctripCommRateField);

                    NumericField ctripStarRateField = new NumericField("CtripStarRate", Field.Store.YES, true);
                    ctripStarRateField.SetFloatValue(hotelinfo.CtripStarRate);
                    doc.Add(ctripStarRateField);

                    NumericField ctripUserRateField = new NumericField("CtripUserRate", Field.Store.YES, true);
                    ctripUserRateField.SetFloatValue(hotelinfo.CtripUserRate);
                    doc.Add(ctripUserRateField);

                    doc.Add(new Field("RefPoints", string.IsNullOrEmpty(hotelinfo.RefPoints)?hotelinfo.AddressLine:hotelinfo.RefPoints, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("SearchKeyWords", searchKeyWords.Join(","), Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Description", hotelinfo.Description, Field.Store.YES, Field.Index.ANALYZED));
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
        /// 搜索
        /// </summary>
        public List<HotelLuceneIndexInfo> HotelSearch(HotelInfoQuery hotelQuery, out int totalRecords)
        {
            string indexLocation = HotelLuceneIndexLocation;
            totalRecords = 0;
            if (hotelQuery.CityId == 0)
                return null;


            store.Directory hotelinfoDir = store.FSDirectory.Open(new DirectoryInfo(indexLocation));
            Analyzer analyzer = new PanGuAnalyzer();
            BooleanQuery query = new BooleanQuery();
            if (hotelQuery.AreaId > 0 && !string.IsNullOrEmpty(hotelQuery.KeyWords))
            {
                QueryParser parserRefPoints = new QueryParser(util.Version.LUCENE_30, "RefPoints", analyzer);
                Query queryRefpoints;
                
                if(hotelQuery.KeyWords.Contains("、"))
                {
                    var areas = hotelQuery.KeyWords.Split('、');
                    foreach (var area in areas)
                    {
                        queryRefpoints = parserRefPoints.Parse(area);
                        query.Add(queryRefpoints, Occur.MUST);
                    }
                }
                else if(hotelQuery.KeyWords.Contains("_"))
                {
                    var areas = hotelQuery.KeyWords.Split('_');
                    foreach (var area in areas)
                    {
                        queryRefpoints = parserRefPoints.Parse(area);
                        query.Add(queryRefpoints, Occur.MUST);
                    }
                }
                else
                {
                    queryRefpoints = parserRefPoints.Parse(hotelQuery.KeyWords);
                    query.Add(queryRefpoints, Occur.MUST);
                }

            }
            if (hotelQuery.LocationID > 0)
            {

                var queryLocation = new TermQuery(new Term("LocationID", hotelQuery.LocationID.ToString()));
                query.Add(queryLocation, Occur.MUST);
            }


            if (hotelQuery.HotelBrandID != "0" && !string.IsNullOrEmpty(hotelQuery.HotelBrandID))
            {
                var hotelBrands = hotelQuery.HotelBrandID.Split('f').ToList();
                string brandCollection = string.Join(" ", hotelBrands);
                var queryBrand = new QueryParser(util.Version.LUCENE_30, "BrandCode", analyzer).Parse(brandCollection);
                query.Add(queryBrand, Occur.MUST);

            }

            if (!string.IsNullOrEmpty(hotelQuery.KeyWords) && (hotelQuery.LocationID == 0 && hotelQuery.AreaId == 0))
            {
                QueryParser parserHotelName = new QueryParser(util.Version.LUCENE_30, "SearchKeyWords", analyzer);
                Query queryRefpoints;
                //var queryHotelName = parserHotelName.Parse(hotelQuery.KeyWords);
                //query.Add(queryHotelName, Occur.MUST);

                if (hotelQuery.KeyWords.Contains("、"))
                {
                    var areas = hotelQuery.KeyWords.Split('、');
                    foreach (var area in areas)
                    {
                        queryRefpoints = parserHotelName.Parse(area);
                        query.Add(queryRefpoints, Occur.MUST);
                    }
                }
                else if (hotelQuery.KeyWords.Contains("_"))
                {
                    var areas = hotelQuery.KeyWords.Split('_');
                    foreach (var area in areas)
                    {
                        queryRefpoints = parserHotelName.Parse(area);
                        query.Add(queryRefpoints, Occur.MUST);
                    }
                }
                else
                {
                    queryRefpoints = parserHotelName.Parse(hotelQuery.KeyWords);
                    query.Add(queryRefpoints, Occur.MUST);
                }

            }

            var queryCityId = new TermQuery(new Term("HotelCityCode", hotelQuery.CityId.ToString()));
            query.Add(queryCityId, Occur.MUST);

            int minPrice = hotelQuery.HotelPrice.Split('-')[0].ToInt32();
            int maxPrice = hotelQuery.HotelPrice.Split('-')[1].ToInt32();

            var queryPrice = NumericRangeQuery.NewIntRange("AmountBeforeTax", minPrice, maxPrice, true, true);
            query.Add(queryPrice, Occur.MUST);



            if (hotelQuery.HotelStar != "0-5")
            {
                int minHotelStar = 0;
                int maxHotelStar = 0;


                var stars = hotelQuery.HotelStar.Split('f').ToList();
                List<int> starList = new List<int>();
                foreach (var star in stars)
                {
                    minHotelStar = star.Split('-')[0].ToInt32();
                    maxHotelStar = star.Split('-')[1].ToInt32();

                    for (int i = minHotelStar; i <= maxHotelStar; i++)
                    {
                        starList.Add(i);
                    }
                }
                starList = starList.Distinct<int>().ToList();

                string starCollection = string.Join(" ", starList);
                var queryStar = new QueryParser(util.Version.LUCENE_30, "HotelStarRate", analyzer).Parse(starCollection);
                query.Add(queryStar, Occur.MUST);
            }

            // 排序


            Sort sort = new Sort(new SortField("AmountBeforeTax", SortField.INT, false));

            switch ((HotelQueryOrderType)hotelQuery.OrderType)
            {
                case HotelQueryOrderType.CommonRate:
                    sort = new Sort(new SortField("CommonRate", SortField.FLOAT, true));
                    break;
                case HotelQueryOrderType.PriceAsc:
                    sort = new Sort(new SortField("AmountBeforeTax", SortField.FLOAT, false));
                    break;
                case HotelQueryOrderType.PriceDesc:
                    sort = new Sort(new SortField("AmountBeforeTax", SortField.FLOAT, true));
                    break;
                case HotelQueryOrderType.StarAsc:
                    sort = new Sort(new SortField("HotelStarRate", SortField.FLOAT, false));
                    break;
                case HotelQueryOrderType.StarDesc:
                    sort = new Sort(new SortField("HotelStarRate", SortField.FLOAT, true));
                    break;
                case HotelQueryOrderType.UserRateAsc:
                    sort = new Sort(new SortField("CtripUserRate", SortField.FLOAT, false));
                    break;
                case HotelQueryOrderType.UserRateDesc:
                    sort = new Sort(new SortField("CtripUserRate", SortField.FLOAT, true));
                    break;
            }

            int n = 1000;
            IndexSearcher searcher = new IndexSearcher(hotelinfoDir, true);
            TopDocs docs = searcher.Search(query, null, n, sort);
            ScoreDoc[] scoreDocs = docs.ScoreDocs;

            int page = hotelQuery.PageIndex;
            int pagesize = hotelQuery.PageSize;

            totalRecords = docs.TotalHits;
            int totalPages = totalRecords % pagesize == 0 ? 0 + totalRecords / pagesize : 1 + totalRecords / pagesize;
            page = Math.Min(page, totalPages);

            int startIndex = Math.Max((page - 1) * pagesize, 0);
            int endIndex = Math.Min(page * pagesize - 1, totalRecords);


            if (docs.TotalHits == 0)
                return null;

            List<HotelLuceneIndexInfo> hotelInfos = new List<HotelLuceneIndexInfo>();
            HotelLuceneIndexInfo hotelinfo;

            for (int i = startIndex; i < endIndex; i++)
            {
                Document doc = searcher.Doc(scoreDocs[i].Doc);
                hotelinfo = new HotelLuceneIndexInfo();
                BindLuceneIndexModel(doc, hotelinfo);
                hotelInfos.Add(hotelinfo);
            }

            int totalCount = hotelInfos.Count;
            return hotelInfos;
        }

        /// <summary>
        /// 根据城市名称获取附近酒店
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public List<HotelLuceneIndexInfo> HotelInfoQueryNearScenery(string cityName, string address = "")
        {
            string indexLocation = HotelLuceneIndexLocation;
            store.Directory hotelinfoDir = store.FSDirectory.Open(new DirectoryInfo(indexLocation));
            Analyzer analyzer = new PanGuAnalyzer();
            BooleanQuery query = new BooleanQuery();

            if (!string.IsNullOrEmpty(cityName))
            {
                QueryParser parserAddress = new QueryParser(util.Version.LUCENE_30, "CityName", analyzer);
                var queryAddress = parserAddress.Parse(cityName);
                query.Add(queryAddress, Occur.MUST);

            }

            int page = 1;
            int pageSize = 8;
            int start = pageSize * (page - 1);
            int limit = start + pageSize;

            var collector = TopScoreDocCollector.Create(8, false);

            Sort sort = new Sort(new SortField("AmountBeforeTax", SortField.INT, false));
            int n = 1000;
            IndexSearcher searcher = new IndexSearcher(hotelinfoDir, true);
            searcher.Search(query, collector);

            ScoreDoc[] hits = collector.TopDocs(start, limit).ScoreDocs;


            List<HotelLuceneIndexInfo> hotelInfos = new List<HotelLuceneIndexInfo>();
            HotelLuceneIndexInfo hotelinfo;

            for (int i = 0; i < hits.Count(); i++)
            {
                hotelinfo = new HotelLuceneIndexInfo();
                Document doc = searcher.Doc(hits[i].Doc);
                BindLuceneIndexModel(doc, hotelinfo);
                hotelInfos.Add(hotelinfo);
            }

            int totalCount = hotelInfos.Count;
            return hotelInfos;

        }

        public List<HotelLuceneIndexInfo> HotelInfoPrimaryInfos()
        {
            string indexLocation = HotelLuceneIndexLocation;
            store.Directory hotelinfoDir = store.FSDirectory.Open(new DirectoryInfo(indexLocation));
            Analyzer analyzer = new PanGuAnalyzer();
            BooleanQuery query = new BooleanQuery();

            int minPrice = 1;
            int maxPrice = 9999;

            var queryPrice = NumericRangeQuery.NewIntRange("AmountBeforeTax", minPrice, maxPrice, true, true);
            query.Add(queryPrice, Occur.MUST);

            int page = 1;
            int pageSize = 8;
            int start = pageSize * (page - 1);
            int limit = start + pageSize;

            var collector = TopScoreDocCollector.Create(8, false);

            Sort sort = new Sort(new SortField("AmountBeforeTax", SortField.INT, false));
            int n = 200000;
            IndexSearcher searcher = new IndexSearcher(hotelinfoDir, true);
            searcher.Search(query, collector);

            TopDocs docs = searcher.Search(query, null, n, sort);
            ScoreDoc[] hits = docs.ScoreDocs;

            
            List<HotelLuceneIndexInfo> hotelInfos = new List<HotelLuceneIndexInfo>();
            HotelLuceneIndexInfo hotelinfo;

            for (int i = 0; i < hits.Count(); i++)
            {
                hotelinfo = new HotelLuceneIndexInfo();
                Document doc = searcher.Doc(hits[i].Doc);
                BindLuceneIndexModel(doc, hotelinfo);
                hotelInfos.Add(hotelinfo);
            }

            int totalCount = hotelInfos.Count;
            return hotelInfos;
        }

        /// <summary>
        /// 删除Lucene索引文件
        /// </summary>
        public static void DropHotelLuceneIndex()
        {
            string indexLocation = ConfigurationManager.AppSettings["HotelLuceneIndexLocation"];
            if (Directory.Exists(indexLocation))
            {
                Directory.Delete(indexLocation, true);
            }

        }

        private void BindLuceneIndexModel(Document doc, HotelLuceneIndexInfo hotelinfo)
        {
            hotelinfo.HotelID = Convert.ToInt32(doc.Get("HotelID"));
            hotelinfo.HotelName = doc.Get("HotelName");
            hotelinfo.AddressLine = doc.Get("AddressLine");
            hotelinfo.CityName = doc.Get("CityName");
            hotelinfo.AmountBeforeTax = doc.Get("AmountBeforeTax").ToInt32();
            hotelinfo.BrandCode = doc.Get("BrandCode").ToInt32();
            hotelinfo.BrandName = doc.Get("BrandName");
            hotelinfo.HotelCityCode = doc.Get("HotelCityCode").ToInt32();

            hotelinfo.HotelImg = doc.Get("HotelImg");
            hotelinfo.HotelStarRate = doc.Get("HotelStarRate").ToInt32();
            hotelinfo.ListAmount = doc.Get("ListAmount").ToInt32();
            hotelinfo.LocationId = doc.Get("LocationId").ToInt32();
            hotelinfo.LocationName = doc.Get("LocationName");
            hotelinfo.RefPoints = doc.Get("RefPoints");

            hotelinfo.Longitude = doc.Get("Longitude");
            hotelinfo.Latitude = doc.Get("Latitude");
            hotelinfo.CommServiceRate = doc.Get("CommServiceRate").ToFloat();
            hotelinfo.CtripCommRate = doc.Get("CtripCommRate").ToFloat();
            hotelinfo.CtripStarRate = doc.Get("CtripStarRate").ToFloat();
            hotelinfo.CtripUserRate = doc.Get("CtripUserRate").ToFloat();
            hotelinfo.UnionId = doc.Get("UnionId").ToInt32();
        }
    }
}
