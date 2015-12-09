if object_id('P_HotelInfoToIndex') is not null
drop proc P_HotelInfoToIndex
GO

create proc P_HotelInfoToIndex
as

SELECT TOP 1500 ID,
	HotelID,
	HotelName,
	CityId AS HotelCityCode,
	CityName,
	HotelStar AS HotelStarRate,
	Amount AS AmountBeforeTax,
	BrandName,
	BrandId AS BrandCode,
	HotelImg,
	Address AS AddressLine,
	isnull(RefPoint,'') as RefPoints,
	LocationId,
	LocationName,
	Lat as Latitude,
	Lng as Longitude,
    UnionId,
    ZhunaHotelID,
	GETDATE() as CreateDate,
	Description
FROM OTA_TCHotel.dbo.T_HotelInfo
WHERE IndexState = 0
