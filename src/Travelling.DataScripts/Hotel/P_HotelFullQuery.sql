if object_id('P_HotelFullQuery') is not null
drop proc P_HotelFullQuery
GO
CREATE proc P_HotelFullQuery
as
select top 10 d.HotelID,d.HotelName,d.HotelImg,d.ZoneId,d.ZoneName,d.ListAmount,d.TrueAmount,d.AddressLine,d.Longitude,d.Latitude,d.CtripCommRate,d.HotelStarRate,d.CtripStarRate 
from T_HotelDescription d where d.HotelCityCode=1 and d.HotelImg!='' order by d.TrueAmount ASC
