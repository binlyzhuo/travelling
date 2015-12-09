if object_id('P_HotelCheapMost') is not null
drop proc P_HotelCheapMost
go
create proc P_HotelCheapMost
as
WITH ct2 as(
select ROW_NUMBER() OVER(PARTITION BY d.HotelCityCode order by d.TrueAmount/cast(d.ListAmount as float) ASC,d.HotelStarRate asc) as Num,d.HotelID,d.HotelCityCode,d.HotelName,d.TrueAmount,d.TrueAmount as AmountBeforeTax,d.HotelStarRate,d.AddressLine,d.HotelImg,d.ListAmount,d.CityName from T_XC_HotelDescription d WITH(NOLOCK)
where d.ListAmount>0 and d.TrueAmount>0 and d.TrueAmount BETWEEN 100 and 300)
select * from ct2 where num<21

