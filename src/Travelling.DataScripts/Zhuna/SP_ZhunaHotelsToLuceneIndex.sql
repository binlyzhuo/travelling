if object_id('SP_ZhunaHotelsToLuceneIndex') is not null
drop proc SP_ZhunaHotelsToLuceneIndex
GO
create proc SP_ZhunaHotelsToLuceneIndex
as
select top 1 h.id as HotelID,h.hotelname as HotelName,f.ctripcityid as HotelCityCode,h.cityname as CityName,dbo.getZhunaHotelStar(h.xingji) as HotelStarRate,h.min_jiage as AmountBeforeTax,
isnull(hn.BrandName,'') as BrandName,isnull(hn.BrandID,0) as BrandCode,h.picture as HotelImg,Isnull(h.address,'') as AddressLine,c.LocationID as LocationId,isnull(c.LocationName,'') as LocationName,h.baidu_lng as Longitude,h.baidu_lat as Latitude,h.esdname as ZoneName,f.ctripcityid,h.content,1 as UnionId,CONVERT(varchar(100), GETDATE(), 112) as CreateDate,'' as RefPoints from Zhuna_HotelInfo h with(NOLOCK)
left join Zhuna_CityInfo f with(NOLOCK) on h.ecityid = f.cid 
left join OTA_TCHotel.dbo.T_LocationInfo c on c.ZhunaLocationID=h.eareaid and c.ZhunaCityID=h.ecityid
left join OTA_TCHotel.dbo.T_HotelBrand hn on hn.ZhunaBrandID = h.liansuoid
where h.isindex=1
