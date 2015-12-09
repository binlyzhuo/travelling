if object_id('SP_HotelRoomPlanSearch') is not null
drop proc SP_HotelRoomPlanSearch
GO
CREATE proc SP_HotelRoomPlanSearch
@hotelid int,
@startdate datetime,
@enddate datetime
as
select rinfo.HotelId as HotelCode,rinfo.RoomTypeName,rp.NumberOfBreakfast,rp.Breakfast,rinfo.Size,rinfo.BedTypeCode,rp.AmountBeforeTax,rp.CancelAmount from T_CtripHotelRoomInfo rinfo 
inner join T_CtripHotelRoomRatePlan rp on rinfo.RoomTypeCode = rp.RoomTypeCode
where rinfo.HotelId = @hotelid and StartTime>=@startdate and EndTime<@enddate
