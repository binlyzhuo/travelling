using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain.Setting;
using Travelling.TravelInterface.Data.Setting;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.Setting;

namespace Travelling.DataProvider.Setting
{
    public class ArticleInfoDataProvider : BaseRecord<T_ArticleInfo>, IArticleInfoDataProvider
    {
        public ArticleInfoDataProvider()
        {
            this.defaultDatabase = TravelDatabase;
        }

        public Page<T_ArticleInfo> ArticleInfoPageSearchResult(ArticleInfoSearchModel search)
        {
            Sql whereSql = Sql.Builder.Where("1=1").OrderBy("id desc");
            var pageResult = defaultDatabase.Page<T_ArticleInfo>(search.PageIndex,search.PageSize,whereSql);
            return pageResult;
        }

        public T_ArticleInfo ArticleInfoGetByID(int articleId)
        {
            var article = defaultDatabase.SingleOrDefaultById<T_ArticleInfo>(articleId);
            return article;
        }

        public Tuple<List<ArticleInfoDto>, List<ArticleInfoDto>> GetNextAndLastArticle(int articleId)
        {
            string sql = string.Format(@"select top 1 ID,Title,Content,AddDate,UserID,State,Tag from T_ArticleInfo WITH(NOLOCK) where ID>{0} and State=1 order by ID asc;
                           select top 1 ID,Title,Content,AddDate,UserID,State,Tag from T_ArticleInfo with(NOLOCK) where id<{0} and State=1 order by ID desc;", articleId);

            var itesm = defaultDatabase.FetchMultiple<ArticleInfoDto, ArticleInfoDto>(sql);
            return itesm;
        }

        public T_ArticleInfo GetLastArticle(int articleId)
        {
            return null;
        }

        public bool ArticleInfoUpdate(T_ArticleInfo article)
        {
            return defaultDatabase.Update(article)>0;
        }
    }
}
