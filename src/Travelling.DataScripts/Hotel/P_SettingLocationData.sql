if object_id('P_SettingLocationData') is not null
drop proc P_SettingLocationData
go
create proc P_SettingLocationData
as

truncate table OTA_TCHotel.dbo.T_LocationInfo

INSERT into OTA_TCHotel.dbo.T_LocationInfo(LocationID,LocationName,ZhunaCityID,LocationEName,CityID,CityName,HotelCount)
select l.LocationID,l.LocationName,'',l.LocationEName,l.LocationCityID,c.CityName,0 from OTA_Hotel.dbo.T_XC_HotelLocation l
inner join OTA_Hotel.dbo.T_XC_HotelCityDetailInfo c on c.CityID=l.LocationCityID

update OTA_TCHotel.dbo.T_LocationInfo SET ZhunaLocationID=ca.areaid,ZhunaCityID=ca.cityid
from OTA_TCHotel.dbo.Zhuna_CityAreaInfo ca where LocationName like ca.areaname+'%'