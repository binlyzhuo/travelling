if object_id('P_HotelLuceneSearch') is not null
drop proc P_HotelLuceneSearch
GO

create proc P_HotelLuceneSearch
as
select *,(select max(rp.StartTime) from T_HotelRoomRatePlan rp where rp.HotelId = d2.HotelID),(select min(rp.StartTime) from T_HotelRoomRatePlan rp where rp.HotelId = d2.HotelID) from (select a.HotelID,d.HotelName,dbo.getStrvalue(a.HotelID) nm from T_CityAreaInfo a
inner join T_HotelDescription d on d.HotelID = a.HotelID

group by a.HotelID,d.HotelName) t0
inner JOIN T_HotelDescription d2 on t0.HotelID = d2.HotelID
inner join T_HotelPrice p on p.HotelID = d2.HotelID
