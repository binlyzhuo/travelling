if object_id('P_HotelRoomInfoServiceQuery') is not null
drop proc P_HotelRoomInfoServiceQuery
GO
CREATE proc P_HotelRoomInfoServiceQuery
@hotelid int,
@start datetime,
@end datetime
as
select * from (
select ROW_NUMBER() over(PARTITION by ro.RoomTypeCode order by ro.AddDate DESC ) num, ro.HotelId as HotelCode,ro.Floor,ro.Facility,ro.RoomTypeName,ro.RoomTypeCode,rp.StartTime,rp.AmountBeforeTax,rp.NumberOfBreakfast,ro.Size,
ro.BedTypeCode,ro.Quantity,rp.CancelAmount,ro.RoomSize,ro.NonSmoking from T_HotelRoomInfo ro
left join T_HotelRoomRatePlan rp on ro.RoomTypeCode = rp.RoomTypeCode
where ro.HotelId = @hotelid and rp.StartTime>=@start and rp.StartTime<=@end ) t0
where t0.num<=1
