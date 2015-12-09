if object_id('SP_HotelRoomInfo') is not null
drop proc SP_HotelRoomInfo
GO
create proc SP_HotelRoomInfo
@hotelid int,
@roomtypecode int
as
select top 1 hi.HotelName,hi.AreaID,hi.AddressLine,hi.CityName,ro.RoomTypeName,ro.BedTypeCode,ro.Floor,ro.RoomSize,ro.Facility,ro.Quantity,rp.AmountBeforeTax,hi.HotelID as HotelCode from T_CtripHotelInfo hi
inner join T_CtripHotelRoomInfo ro on hi.HotelID = ro.HotelId
inner JOIN T_CtripHotelRoomRatePlan rp on rp.RoomTypeCode = ro.RoomTypeCode
where hi.HotelID=@hotelid and ro.RoomTypeCode=@roomtypecode
