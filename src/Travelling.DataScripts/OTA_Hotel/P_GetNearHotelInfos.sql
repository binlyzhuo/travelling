if object_id('P_GetNearHotelInfos') is not null
drop proc P_GetNearHotelInfos
GO
create proc P_GetNearHotelInfos
@hotelid int,
@distance float
as
declare @lon nvarchar(100);
declare @lat nvarchar(100);
select @lon = d.Latitude,@lat = d.Longitude from T_XC_HotelDescription d where d.HotelID = @hotelid;

select top 10 h.HotelID,h.HotelName,h.HotelCityCode,p.AmountBeforeTax,h.AddressLine,h.HotelImg,p.ListAmount,dbo.fnGetDistance(@lat,@lon,h.Longitude,h.Latitude) as Distance from T_XC_HotelDescription h
inner join T_XC_HotelPrice p on h.HotelID = p.HotelID
where dbo.fnGetDistance(@lat,@lon,h.Longitude,h.Latitude) < @distance and h.HotelID!=@hotelid