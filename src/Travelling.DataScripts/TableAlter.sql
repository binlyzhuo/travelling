update T_HotelRefPointInfo set CityId = HotelCityCode
from T_HotelDescription where T_HotelDescription.HotelID = T_HotelRefPointInfo.HotelID