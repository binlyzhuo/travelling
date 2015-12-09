use TRAVEL
GO
select rp.Name,rp.RefPointCategoryCode,c.CityID,c.CityName,rp.RefPointName from T_HotelRefPointInfo rp
inner join T_HotelDescription h on h.HotelID = rp.HotelID
inner join T_City c on c.CityID = h.HotelCityCode
group by c.CityID,c.CityName,rp.RefPointCategoryCode,rp.RefPointName,rp.Name
