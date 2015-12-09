if object_id('P_HotelBrandCitySummary') is not null
drop proc P_HotelBrandCitySummary
GO
create proc P_HotelBrandCitySummary
as
select d.HotelName,d.HotelID,b.BrandID as BrandCode,d.BrandName,d.CityName,d.CityId,d.UnionId as HotelCityCode,d.UnionId from OTA_TCHotel.dbo.T_HotelInfo d
INNER join OTA_TCHotel.dbo.T_HotelBrand b on d.BrandId = b.BrandID
