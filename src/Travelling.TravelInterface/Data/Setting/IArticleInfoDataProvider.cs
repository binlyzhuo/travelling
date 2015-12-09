using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain.Setting;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.Setting;

namespace Travelling.TravelInterface.Data.Setting
{
    public interface IArticleInfoDataProvider : IDataProvider<T_ArticleInfo>
    {
        Page<T_ArticleInfo> ArticleInfoPageSearchResult(ArticleInfoSearchModel search);

        T_ArticleInfo ArticleInfoGetByID(int articleId);

        bool ArticleInfoUpdate(T_ArticleInfo article);

        Tuple<List<ArticleInfoDto>, List<ArticleInfoDto>> GetNextAndLastArticle(int articleId);
    }
}
