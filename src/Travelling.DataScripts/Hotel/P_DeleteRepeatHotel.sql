update OTA_TCHotel.dbo.T_HotelInfo set ZhunaHotelID=HotelID
from (select hotelname from OTA_TCHotel.dbo.T_HotelInfo group by HotelName having count(HotelName)>1) t0
where t0.HotelName = T_HotelInfo.HotelName and UnionId=1

delete from OTA_TCHotel.dbo.T_HotelInfo
where HotelName in(select hotelname from OTA_TCHotel.dbo.T_HotelInfo group by HotelName having count(HotelName)>1) and ZhunaHotelID=0