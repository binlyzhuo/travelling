if object_id('P_HotHotelsForCityInfo') is not null
drop proc P_HotHotelsForCityInfo
go
create proc P_HotHotelsForCityInfo
as
with ct as
(
  select ROW_NUMBER() OVER(PARTITION by h.HotelCityCode ORDER by h.CtripCommRate desc) as num,h.HotelID,h.HotelName,p.ListAmount,p.AmountBeforeTax,h.HotelCityCode,h.HotelImg,h.AddressLine from T_XC_HotelDescription h
  inner join T_XC_HotelPrice p on p.HotelID = h.HotelID
  inner join T_XC_HotelCityDetailInfo c on c.CityID = h.HotelCityCode
  where h.HotelImg!='' and h.HotelImg is NOT NULL and p.AmountBeforeTax BETWEEN 200 AND 400 and c.IsHotCity=1
)
select * from ct
where num<11;
select * from T_XC_HotelCityDetailInfo where IsHotCity=1 order by HotCityIndex asc;