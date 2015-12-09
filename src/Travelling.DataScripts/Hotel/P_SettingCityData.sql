if object_id('P_SettingCityData') is not null
drop proc P_SettingCityData
go
create proc P_SettingCityData
as
truncate table OTA_TCHotel.dbo.T_CityInfo
INSERT into OTA_TCHotel.dbo.T_CityInfo(CityID,CityName,ZhunaCityID,HotelCount,PinYin,SuoXie,ABCD,ProvinceId,ProvinceName,BaiDuLat,BaiDuLng)
select d.CityID,d.CityName,isnull(b.cid,''),0,isnull(b.pinyin,''),isnull(b.suoxie,''),isnull(b.abcd,''),d.ProvinceID,d.ProvinceName,ISNULL(b.baidu_lat,''),ISNULL(b.baidu_lng,'') from OTA_Hotel.dbo.T_XC_HotelCityDetailInfo d
left join OTA_TCHotel.dbo.Zhuna_CityInfo b on d.CityID=b.ctripcityid