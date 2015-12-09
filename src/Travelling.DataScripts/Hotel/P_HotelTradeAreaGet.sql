if object_id('P_HotelTradeAreaGet') is not null
drop proc P_HotelTradeAreaGet
GO
create proc P_HotelTradeAreaGet
as
select cbd.cbdname as Name,cbd.cityname as CityName,cf.CityID from Zhuna_CBD cbd
inner join T_CityInfo cf on cbd.cityid = cf.ZhunaCityID
inner join OTA_Hotel.dbo.T_XC_HotelCityDetailInfo d on d.CityID = cf.CityID
where d.IsHotCity=1
