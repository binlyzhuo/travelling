if object_id('P_HotelRoomPriceQuery') is not null
drop proc P_HotelRoomPriceQuery
go
create proc P_HotelRoomPriceQuery
as
select * from (
select ROW_NUMBER() OVER(PARTITION by p.RoomTypeCode order by p.AmountBeforeTax asc) num,d.HotelID,rm.RoomTypeName,rm.RoomTypeCode,rm.BedTypeCode,p.Breakfast,p.RatePlanCategory,p.AmountBeforeTax,p.StartTime,p.EndTime,p.AddDate,p.ListPrice from T_HotelRoomRatePlan p
inner join (select top 10 d.HotelID,d.HotelName from T_HotelDescription d where d.HotelCityCode=1 and d.HotelImg!='' order by d.HotelID asc) d on d.HotelID = p.HotelId
inner join T_HotelRoomInfo rm on rm.RoomTypeCode = p.RoomTypeCode
where p.StartTime>='2014-9-28' and p.EndTime<'2014-10-1' and p.RatePlanCategory=16 
) t where t.num<2 order by t.HotelID desc
