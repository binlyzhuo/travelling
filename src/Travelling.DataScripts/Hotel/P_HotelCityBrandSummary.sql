if object_id('P_HotelCityBrandSummary') is not null
drop proc P_HotelCityBrandSummary
GO
create proc P_HotelCityBrandSummary
as
select count(d.HotelID) HotelCount,d.CityId as HotelCityCode,c.PinYin as CityEName,d.CityName,d.BrandId,b.BrandName,c.ABCD as OrderFlag from OTA_TCHotel.dbo.T_HotelInfo d
inner join OTA_TCHotel.dbo.T_CityInfo c on c.CityID=d.CityId
inner join OTA_TCHotel.dbo.T_HotelBrand b on b.BrandID=d.BrandId
group by d.CityId,d.BrandId,b.BrandName,d.CityName,c.ABCD,c.PinYin