if object_id('fn_Merge') is not null
drop FUNCTION fn_Merge
GO
create function dbo.fn_Merge(@id int)   
returns varchar(8000)   
  as   
  begin
   
        declare @r varchar(8000)
SET @r = ''
SELECT
	@r = @r + ';' + Name
FROM T_HotelAreaSyncInfo
WHERE HotelID = @id
RETURN STUFF(@r, 1, 1, '')
END

-------------------------------------
select d2.HotelCityCode,d2.CityName,d2.HotelName,d2.HotelID,d2.HotelStarRate,d2.BrandCode,d2.BrandName,d2.ZoneId,d2.ZoneName,d2.Longitude,d2.Latitude,d2.HotelImg,t0.AreaInfos,d2.TrueAmount,
(select MAX(StartTime) from T_HotelSyncRoomRatePlan where d2.HotelID=d2.HotelID) StartDate,
(select MIN(StartTime) from T_HotelSyncRoomRatePlan where d2.HotelID=d2.HotelID) EndDate
from(
SELECT d.HotelID,dbo.fn_Merge(d.HotelID) as AreaInfos FROM T_HotelAreaSyncInfo a
inner join T_HotelSyncDescription d on d.HotelID = a.HotelID
--where a.HotelID=1064941
GROUP by d.HotelID,a.CityID) t0
inner join T_HotelSyncDescription d2 on d2.HotelID = t0.HotelID
