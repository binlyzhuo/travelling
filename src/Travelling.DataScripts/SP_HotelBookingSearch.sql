select hf.HotelName from T_CtripHotelInfo hf 
inner join T_CtripHotelPrice hp on hf.HotelID = hp.HotelID
where hf.HotelCityCode in (1,2,3)

select * from T_CtripHotelInfo
go

