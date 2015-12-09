TRUNCATE table OTA_TCHotel.dbo.T_LocationInfo
insert into OTA_TCHotel.dbo.T_LocationInfo(LocationID,LocationName,ZhunaLocationID,LocationEName,HotelCount,CityID,CityName)
select l.LocationID,l.LocationName,isnull(c.areaid,''),l.LocationEName,0,l.LocationCityID,d.CityName from OTA_Hotel.dbo.T_XC_HotelLocation l 
inner join OTA_Hotel.dbo.T_XC_HotelCityDetailInfo d on d.CityID=l.LocationCityID
left join OTA_TCHotel.dbo.Zhuna_CityAreaInfo c on l.LocationID = c.ctripareaid
where c.ctripareaid>0

update OTA_TCHotel.dbo.Zhuna_CityAreaInfo set ctripareaid=t0.LocationID
from (select l.LocationID,c.areaid,l.LocationName,c.cityid from OTA_TCHotel.dbo.Zhuna_CityAreaInfo c inner join OTA_TCHotel.dbo.T_CityInfo ci on ci.ZhunaCityID=c.cityid inner join OTA_Hotel.dbo.T_XC_HotelLocation l on l.LocationCityID=ci.CityID) t0
where (t0.LocationName like areaname+'%' or areaname like t0.LocationName+'%') and Zhuna_CityAreaInfo.cityid=t0.cityid

update OTA_TCHotel.dbo.Zhuna_CityAreaInfo set ctripareaid=t0.LocationID
from (select l.LocationID,c.areaid,l.LocationName,c.cityid from OTA_TCHotel.dbo.Zhuna_CityAreaInfo c inner join OTA_TCHotel.dbo.T_CityInfo ci on ci.ZhunaCityID=c.cityid inner join OTA_Hotel.dbo.T_XC_HotelLocation l on l.LocationCityID=ci.CityID) t0
where (t0.LocationName like areaname+'%' or areaname like t0.LocationName+'%') and Zhuna_CityAreaInfo.cityid=t0.cityid


select distinct(l.LocationID),l.LocationName,isnull(c.areaid,'') as areaid,l.LocationEName,0 as HotelCount,d.CityID,d.CityName,isnull(c.cityid,'') as zhunacityid from OTA_Hotel.dbo.T_XC_HotelLocation l
inner join OTA_Hotel.dbo.T_XC_HotelCityDetailInfo d on d.CityID=l.LocationCityID
left join OTA_TCHotel.dbo.Zhuna_CityAreaInfo c on l.LocationID = c.ctripareaid
