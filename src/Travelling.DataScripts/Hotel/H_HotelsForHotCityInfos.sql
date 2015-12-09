if object_id('HP_HotelsForHotCityInfos') is not null
drop proc HP_HotelsForHotCityInfos
GO
CREATE proc HP_HotelsForHotCityInfos
as
select h.HotelName,h.HotelID,h.AddressLine,h.CityName,h.HotelCityCode from T_HotelDescription h 
inner join T_HotelPrice p on h.HotelCode = p.HotelID