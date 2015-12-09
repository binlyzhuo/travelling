﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.TC;

namespace Travelling.OpenApiEntity.Scenery
{
    /// <summary>
    /// 获取景点图片列表请求实体
    /// </summary>
    public class GetSceneryImageListCallEntity : TongChengBaseCallEntity
    {
        private int page = 1;
        private int pageSize = 20;

        public int Page
        {
            get
            {
                return this.page;
            }
        }

        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
        }

        public int SceneryId
        {
            get
            {
                return this.sceneryId;
            }
        }

        public GetSceneryImageListCallEntity()
        {
            page = 1;
            pageSize = 10;
        }

        public GetSceneryImageListCallEntity(int page, int pageSize)
        {
            this.page = page;
            this.pageSize = pageSize;
        }
        private int sceneryId;

        /// <summary>
        /// 获取景区图片信息列表
        /// </summary>
        /// <param name="sceneryId">景区id</param>
        /// <param name="page">页码</param>
        /// <param name="pageSize">每页个数</param>
        public GetSceneryImageListCallEntity(int sceneryId, int page, int pageSize)
            : this(page, pageSize)
        {
            this.sceneryId = sceneryId;
        }
    }
}
