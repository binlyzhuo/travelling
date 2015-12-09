truncate table OTA_TCHotel.dbo.T_CityInfo
INSERT into OTA_TCHotel.dbo.T_CityInfo(CityID,CityName,ZhunaCityID,HotelCount,PinYin,SuoXie,ABCD,ProvinceId,ProvinceName,BaiDuLat,BaiDuLng)
select d.CityID,d.CityName,isnull(b.cid,'') as cid,0 as state,isnull(b.pinyin,'') as pinyin,isnull(b.suoxie,'') as suoxie,isnull(b.abcd,'') as abcd,d.ProvinceID,d.ProvinceName,ISNULL(b.baidu_lat,'') as lat,ISNULL(b.baidu_lng,'') as lng from OTA_Hotel.dbo.T_XC_HotelCityDetailInfo d
left join OTA_TCHotel.dbo.Zhuna_CityInfo b on d.CityName=b.cName or b.cName like '%'+d.CityName +'%'