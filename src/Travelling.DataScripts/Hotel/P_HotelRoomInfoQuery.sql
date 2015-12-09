if object_id('P_HotelRoomInfoQuery') is not null
DROP PROC P_HotelRoomInfoQuery
GO
create proc P_HotelRoomInfoQuery
@start datetime,
@end datetime
as
SELECT
	rm.HotelId,
	rm.RoomTypeName,
	rm.RoomTypeCode,
	ISNULL(rp.AmountBeforeTax, 0) AmountBeforeTax,
	ISNULL(rp.ListPrice, 0) ListPrice,
	ISNULL(rp.NumberOfBreakfast, 0) NumberOfBreakfast,
	rp.StartTime
FROM T_HotelRoomInfo rm WITH (NOLOCK)
LEFT JOIN T_HotelSyncRoomRatePlan rp WITH (NOLOCK)
	ON rp.HotelId = rm.HotelId
	AND rm.RoomTypeCode = rp.RoomTypeCode
	AND rp.StartTime = @start
	AND AmountBeforeTax > 0
WHERE rm.HotelId IN (83, 86, 89, 103)