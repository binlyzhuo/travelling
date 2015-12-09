using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Travelling.Domain.Hotel;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.ViewModel.Dto.Ticket;
using Travelling.Domain;
using Travelling.Domain.Scenery;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel.Dto.HotelSyncRecord;
using Travelling.ViewModel.Travel;
using Travelling.OpenApiEntity.Scenery.Module;
using Travelling.ViewModel.Dto.User;
using Travelling.Domain.Setting;
using Travelling.ViewModel.Dto.Setting;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.OpenApiEntity.Zhuna;
using Travelling.ViewModel.Dto.Zhuna;

namespace Travelling.Repository
{
    /// <summary>
    /// 数据绑定
    /// </summary>
    public class DtoMapper
    {
        /// <summary>
        /// Maaper Dto
        /// </summary>
        public static void AutoMapper()
        {
            Mapper.CreateMap<T_SceneryInfoSyncRecord, SceneryInfoSyncRecord>();
            Mapper.CreateMap<T_SceneryImgInfo, SceneryImgInfo>();
            Mapper.CreateMap<T_SceneryTheme, SceneryThemeInfo>();
            Mapper.CreateMap<T_XC_HotelDescription, HotelDescription>();
            Mapper.CreateMap<T_XC_HotelRefPointInfo, HotelRefPointInfo>();
            Mapper.CreateMap<T_XC_HotelLocation, LocationInfo>();
            Mapper.CreateMap<T_XC_HotelAreaInfo, HotelAreaSyncInfo>();
            Mapper.CreateMap<T_XC_HotelAreaInfo, CityAreaInfo>();
            Mapper.CreateMap<T_JobScheduler, JobScheduler>();
            Mapper.CreateMap<JobScheduler, T_JobScheduler>();
            Mapper.CreateMap<T_HotelBookingOrder, HotelBookingOrder>();
            Mapper.CreateMap<T_SceneryInfoDetail, SceneryInfoDetail>();
            Mapper.CreateMap<T_SceneryTicketPrice, SceneryTicketPrice>();
            Mapper.CreateMap<T_SceneryTicketOrder, SceneryTicketOrder>();
            Mapper.CreateMap<SceneryPolicy, TicketPolicyInfo>();
            Mapper.CreateMap<T_XC_HotelProvince, HotelProvinceInfo>();
            Mapper.CreateMap<T_SceneryProvinceDetailInfo, SceneryProvinceDetailInfo>();
            Mapper.CreateMap<T_AccountInfo, AccountInfo>();
            Mapper.CreateMap<T_JobSchedulerLog, JobSchedulerLog>();
            Mapper.CreateMap<JobSchedulerLog, T_JobSchedulerLog>();
            Mapper.CreateMap<T_OperatingLog, OperatingLog>();
            Mapper.CreateMap<OperatingLog, T_OperatingLog>();
            Mapper.CreateMap<HotelRoomRateJobScheduler, T_XC_HotelRoomRateJobScheduler>();
            Mapper.CreateMap<T_XC_HotelRoomRateJobScheduler, HotelRoomRateJobScheduler>();
            Mapper.CreateMap<T_XC_HotelCityDetailInfo, HotelCityDetailInfo>();
            Mapper.CreateMap<HotelCityDetailInfo, T_XC_HotelCityDetailInfo>();
            Mapper.CreateMap<HotelBrandDetailInfo, T_XC_HotelBrandDetailInfo>();
            Mapper.CreateMap<T_XC_HotelBrandDetailInfo, HotelBrandDetailInfo>();
            Mapper.CreateMap<T_XC_HotelRoomInfo, HotelRoomInfo>();
            Mapper.CreateMap<T_FriendLink, FriendLinkDto>();
            Mapper.CreateMap<FriendLinkDto, T_FriendLink>();
            Mapper.CreateMap<T_SettingConfig, SettingConfigDto>();
            Mapper.CreateMap<T_UnionDetailInfo, UnionDetailInfoDto>();
            Mapper.CreateMap<ArticleInfoDto, T_ArticleInfo>();
            Mapper.CreateMap<T_ArticleInfo,ArticleInfoDto>();
            Mapper.CreateMap<ZhunaHotelInfo, Zhuna_HotelInfo>()
                .ForMember(u => u.teshe, opt => opt.NullSubstitute(""))
                .ForMember(u => u.yulejianshen, opt => opt.NullSubstitute(""))
                .ForMember(u=>u.jianshu,opt=>opt.NullSubstitute(""))
                .ForMember(u=>u.traffic_zhinan,opt=>opt.NullSubstitute(""))
                .ForMember(u=>u.liansuo,opt=>opt.NullSubstitute(""))
                .ForMember(u=>u.zaocanPrice,opt=>opt.NullSubstitute(""))
                .ForMember(u=>u.tags,opt=>opt.NullSubstitute(""))
                .ForMember(u=>u.max_jiangjin,opt=>opt.NullSubstitute(""))
                .ForMember(u=>u.service,opt=>opt.NullSubstitute("")).ForMember(u=>u.cityname,opt=>opt.NullSubstitute(""));

            Mapper.CreateMap<ZhunaCityareaInfo, Zhuna_CityAreaInfo>();
            Mapper.CreateMap<Zhuna_CityLable, Zhuna_CityLableDto>();
            Mapper.CreateMap<T_HotelInfo, HotelInfoDto>();
            Mapper.CreateMap<T_HotelBrand, HotelBrandDto>();
            Mapper.CreateMap<Zhuna_CBD, Zhuna_CBDDto>();
            //Mapper.CreateMap<ZhunaLableInfo, Zhuna_CityLable>().ForMember(u=>u.classname,opt=>opt.);
        }
    }
}
