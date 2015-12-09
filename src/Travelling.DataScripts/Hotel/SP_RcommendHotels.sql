if object_id('SP_RcommendHotels') is not null
drop proc SP_RcommendHotels
GO
create proc SP_RcommendHotels
as
WITH ct as
(
select ROW_NUMBER() OVER(PARTITION BY ci.CtripCityID order by hp.AmountBeforeTax asc) as num,hi.HotelID,hi.HotelCityCode,hp.AmountBeforeTax,hi.HotelName,hi.AddressLine,hi.HotelIcon,hp.ListPrice  from T_CtripHotelInfo hi
inner join T_CtripHotelPrice hp on hi.HotelID = hp.HotelID
inner join T_RecommendCity ci on ci.CtripCityID = hi.HotelCityCode) 
select * from ct where num<=12
order by HotelCityCode
