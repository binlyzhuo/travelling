using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Data.Setting;
using Travelling.TravelInterface.Repository;
using Ninject;
using Travelling.ViewModel.Dto.Setting;
using Travelling.Domain.Setting;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel;
using AutoMapper;
using Travelling.Caching;

namespace Travelling.Repository
{
    public class SettingBusinessLogic : BaseLogic,ISettingBusinessLogic
    {
        private readonly IFriendLinkDataProvider friendLinkData;
        private readonly IArticleInfoDataProvider articleData;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SettingBusinessLogic()
        {
            
            if (friendLinkData==null)
            {
                friendLinkData = kernel.Get<IFriendLinkDataProvider>();
            }
            if(articleData==null)
            {
                articleData = kernel.Get<IArticleInfoDataProvider>();
            }
            
        }

        public bool FriendLinkAdd(FriendLinkDto friendLinkDto)
        {
            T_FriendLink friendLinkDomain = AutoMapper.Mapper.Map<FriendLinkDto, T_FriendLink>(friendLinkDto);
            return friendLinkData.Save(friendLinkDomain)>0;
        }

        public FriendLinkDto FriendLinkGetById(int id)
        {
            var friendLinkDomain = friendLinkData.SingleOrDefault(id);
            return AutoMapper.Mapper.Map<T_FriendLink, FriendLinkDto>(friendLinkDomain);
        }

        public PageObjectResult<FriendLinkDto> FriendLinkGetPageResult(FriendLinkSearchModel searchModel)
        {
            var pageResult = friendLinkData.FriendLinkGetPageResult(searchModel);
            if (pageResult.TotalItems == 0)
                return new PageObjectResult<FriendLinkDto>();
            var pageViewResult = new PageObjectResult<FriendLinkDto>() {
                Items = Mapper.Map<List<T_FriendLink>, List<FriendLinkDto>>(pageResult.Items),
                Page = pageResult.CurrentPage,
                PageSize = pageResult.ItemsPerPage,
                TotalCount = pageResult.TotalItems,
                TotalPages = pageResult.TotalPages
            };
            return pageViewResult;
        }

        public bool FriendLinkUpdate(FriendLinkDto friendLinkDto)
        {
            var friendLinkDomain = friendLinkData.SingleOrDefault(friendLinkDto.ID);
            friendLinkDomain.Name = friendLinkDto.Name;
            friendLinkDomain.LinkUrl = friendLinkDto.LinkUrl;
            friendLinkDomain.OrderIndex = friendLinkDto.OrderIndex;
            friendLinkDomain.LinkMan = friendLinkDto.LinkMan;
            friendLinkDomain.State = friendLinkDto.State;
            return friendLinkData.Update(friendLinkDomain)>0;
        }

        public bool FriendLinkDelete(int id)
        {
            return friendLinkData.Delete(id);
        }

        public List<FriendLinkDto> FriendLinks()
        {
            var friendLinks = cacheProvider.GetCacheItem<List<FriendLinkDto>>(CacheKeys.FriendLinks);
            if(friendLinks==null)
            {
                friendLinks = AutoMapper.Mapper.Map<List<T_FriendLink>, List<FriendLinkDto>>(friendLinkData.All());
                cacheProvider.InsertCacheItems(CacheKeys.FriendLinks, friendLinks);
            }
            return friendLinks;
        }

        /// <summary>
        /// 新闻咨询添加
        /// </summary>
        /// <param name="articleDto">文字信息</param>
        /// <returns>主键</returns>
        public int AddArticleInfo(ArticleInfoDto articleDto)
        {
            var articleinfo = AutoMapper.Mapper.Map<ArticleInfoDto, T_ArticleInfo>(articleDto);
            return articleData.Save(articleinfo);
        }

        /// <summary>
        /// 新闻咨询信息分页查询结果
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public PageObjectResult<ArticleInfoDto> ArticleInfoPageResult(ArticleInfoSearchModel search)
        {
            var pageResult = articleData.ArticleInfoPageSearchResult(search);
            if(pageResult.TotalItems==0)
            {
                return new PageObjectResult<ArticleInfoDto>();
            }
            var pageViewResult = new PageObjectResult<ArticleInfoDto>() {
                Items = AutoMapper.Mapper.Map<List<T_ArticleInfo>, List<ArticleInfoDto>>(pageResult.Items),
                Page = pageResult.CurrentPage,
                PageSize = pageResult.ItemsPerPage,
                TotalCount = pageResult.TotalItems,
                TotalPages = pageResult.TotalPages

            };
            return pageViewResult;
        }

        /// <summary>
        /// 获取新闻信息
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public ArticleInfoDto ArticleInfoGetByID(int articleId)
        {
            var articleDomain = articleData.ArticleInfoGetByID(articleId);
            var articleDto = AutoMapper.Mapper.Map<T_ArticleInfo, ArticleInfoDto>(articleDomain);
            return articleDto;
        }

        public bool ArticleInfoUpdate(ArticleInfoDto articleDto)
        {
            var articleDomain = articleData.ArticleInfoGetByID(articleDto.ID);
            articleDomain.Title = articleDto.Title;
            articleDomain.Content = articleDto.Content;
            articleDomain.State = articleDto.State;
            articleDomain.Tag = articleDto.Tag;
            articleDomain.Type = articleDto.Type;
            return articleData.ArticleInfoUpdate(articleDomain);
        }

        public bool ArticleDelete(int articleId)
        {
            return articleData.Delete(articleId);
        }

        public Tuple<List<ArticleInfoDto>, List<ArticleInfoDto>> GetNextAndLastArticle(int articleId)
        {
            var items = articleData.GetNextAndLastArticle(articleId);
            return items;
        }
    }
}
