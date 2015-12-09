if object_id('P_HotelMostPractical') is not null
drop proc P_HotelMostPractical
GO
create proc P_HotelMostPractical
as
WITH ct2 as(
select ROW_NUMBER() OVER(PARTITION BY d.HotelCityCode order by d.TrueAmount/cast(d.ListAmount as float) ASC,d.HotelStarRate asc) as Num,d.HotelID,d.HotelCityCode,d.HotelName,d.TrueAmount,d.TrueAmount as AmountBeforeTax,d.HotelStarRate,d.AddressLine,d.HotelImg,d.ListAmount,d.CityName from T_XC_HotelDescription d WITH(NOLOCK)
where d.ListAmount>0)
select * from ct2 where num<16


