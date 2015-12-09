if object_id('P_GetHotelInfoForIndex') is not null
drop proc P_GetHotelInfoForIndex
GO
create proc P_GetHotelInfoForIndex
as
declare @hotelid table(hotelid int)
insert into @hotelid(hotelid)
select top 500 d.HotelId from T_HotelSyncDescription d where IsIndex=0;

select d.HotelID,d.HotelName,d.HotelCityCode,d.CityName,d.HotelStarRate,Isnull(p.AmountBeforeTax,0) AmountBeforeTax,
isnull(p.ListAmount,0) ListAmount,d.BrandCode,d.BrandName,d.HotelImg,d.AddressLine,
d.AreaID as LocationID,d.AreaName as LocationName,d.Longitude,d.Latitude,d.ZoneId,d.ZoneName,d.CtripStarRate,d.CtripUserRate,d.CtripCommRate,d.CommServiceRate,CONVERT(varchar(100), GETDATE(), 112) as CreateDate from T_HotelSyncDescription d
left join T_HotelPriceSyncInfo p on d.HotelID = p.HotelID 
INNER join @hotelid h on h.hotelid = d.HotelID;

select af.Name,af.HotelID from T_HotelAreaSyncInfo af
inner join @hotelid h on h.hotelid =af.HotelID;

