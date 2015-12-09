using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.ViewModel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.Setting;

namespace Travelling.TravelInterface.Repository
{
    public interface ISettingBusinessLogic
    {
        bool FriendLinkAdd(FriendLinkDto friendLinkDto);

        PageObjectResult<FriendLinkDto> FriendLinkGetPageResult(FriendLinkSearchModel searchModel);

        FriendLinkDto FriendLinkGetById(int id);

        bool FriendLinkUpdate(FriendLinkDto friendLinkDto);

        bool FriendLinkDelete(int id);

        List<FriendLinkDto> FriendLinks();

        /// <summary>
        /// 添加新闻咨询
        /// </summary>
        /// <param name="articleDto"></param>
        /// <returns></returns>
        int AddArticleInfo(ArticleInfoDto articleDto);

        /// <summary>
        /// 新闻咨询分页查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        PageObjectResult<ArticleInfoDto> ArticleInfoPageResult(ArticleInfoSearchModel search);

        /// <summary>
        /// 获取新闻信息
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        ArticleInfoDto ArticleInfoGetByID(int articleId);

        /// <summary>
        /// 修改新闻咨询
        /// </summary>
        /// <param name="articleDto"></param>
        /// <returns></returns>
        bool ArticleInfoUpdate(ArticleInfoDto articleDto);

        /// <summary>
        /// 新闻咨询删除
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        bool ArticleDelete(int articleId);

        Tuple<List<ArticleInfoDto>, List<ArticleInfoDto>> GetNextAndLastArticle(int articleId);
    }
}
