select d.HotelID,d.HotelCityCode,d.HotelName,d.BrandName,d.BrandCode,p.AmountBeforeTax,d.HotelStarRate,p.AddDate,d.ZoneId,d.ZoneName,d.AreaName,d.AreaID from T_HotelDescription d
inner join T_HotelPrice p on p.HotelID = d.HotelID
select * from T_HotelRefPointInfo where HotelID=83
