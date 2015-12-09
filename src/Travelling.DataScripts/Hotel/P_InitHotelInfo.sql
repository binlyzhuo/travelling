insert into OTA_TCHotel.dbo.T_HotelInfo(HotelID,HotelName,UnionId,Address,CityId,CityName,RefPoint,LocationId,LocationName,HotelImg,BrandId,BrandName,BrandImg,Amount)
SELECT d.HotelID,d.HotelName,0 as UnionId,d.AddressLine,d.HotelCityCode,d.CityName,d.ZoneName,d.AreaID,d.AreaName,d.HotelImg,d.BrandCode,isnull(b.BrandName,'') as BrandName,'',d.TrueAmount from OTA_Hotel.dbo.T_XC_HotelDescription d
left join OTA_TCHotel.dbo.T_HotelBrand b on b.BrandID=d.HotelID


insert into OTA_TCHotel.dbo.T_HotelInfo(HotelID,HotelName,UnionId,Address,CityId,CityName,RefPoint,LocationId,LocationName,HotelImg,BrandId,BrandName,BrandImg,Amount)
select d.id,d.hotelname,1 as UnionId,d.address,c.CityID,c.CityName,d.esdname,l.LocationID,l.LocationName,d.picture,b.BrandID,b.BrandName,'',d.min_jiage from OTA_TCHotel.dbo.Zhuna_HotelInfo d
left join OTA_TCHotel.dbo.T_CityInfo c on d.ecityid=c.ZhunaCityID
left join OTA_TCHotel.dbo.T_LocationInfo l on l.ZhunaLocationID = d.eareaid
left join OTA_TCHotel.dbo.T_HotelBrand b on b.ZhunaBrandID=d.liansuoid

select top 5000 t1.id,t1.hotelname,t1.UnionID,t1.address,t1.CityID,t1.CityName,t1.esdname,t1.LocationID,t1.LocationName,t1.picture,isnull(b.BrandID,0) as BrandID,isnull(b.BrandName,'') as BrandName from (select t0.id,t0.hotelname,1 as UnionID,t0.address,t0.CityID,t0.CityName,t0.esdname,l.LocationID,l.LocationName,t0.picture, t0.liansuoid from(select d.hotelname,d.address,d.id,d.ecityid,c.CityID,c.CityName,d.esdname,d.picture,d.liansuoid from OTA_TCHotel.dbo.Zhuna_HotelInfo d
left join OTA_TCHotel.dbo.T_CityInfo c on d.ecityid=c.ZhunaCityID) t0
left join OTA_TCHotel.dbo.T_LocationInfo l on l.CityID = t0.CityID) t1
LEFT join OTA_TCHotel.dbo.T_HotelBrand b on b.ZhunaBrandID=t1.liansuoid AND b.UnionID=1


-----------------------------------------------------------
select COUNT(1) from (select t0.id,t0.hotelname,1 as UnionID,t0.address,t0.CityID,t0.CityName,t0.esdname,l.LocationID,l.LocationName,t0.picture, t0.liansuoid,t0.eareaid from(select d.hotelname,d.address,d.id,d.ecityid,c.CityID,c.CityName,d.esdname,d.picture,d.liansuoid,d.eareaid from OTA_TCHotel.dbo.Zhuna_HotelInfo d
inner join OTA_TCHotel.dbo.T_CityInfo c on d.ecityid=c.ZhunaCityID) t0
INNER join OTA_TCHotel.dbo.T_LocationInfo l on l.ZhunaLocationID = t0.eareaid and l.ZhunaCityID=t0.ecityid) t1
inner join OTA_TCHotel.dbo.T_HotelBrand b on b.ZhunaBrandID=t1.liansuoid AND b.UnionID=1


select * from OTA_TCHotel.dbo.T_LocationInfo

select t0.eareaid from(select h.id,h.eareaid,h.ecityid from OTA_TCHotel.dbo.Zhuna_HotelInfo h
inner join OTA_TCHotel.dbo.T_CityInfo c on h.ecityid=c.ZhunaCityID
left join OTA_TCHotel.dbo.T_HotelBrand b on b.ZhunaBrandID = h.liansuoid and b.UnionID=1) t0
INNER join OTA_TCHotel.dbo.T_LocationInfo l on t0.ecityid=l.ZhunaCityID and l.ZhunaLocationID = t0.eareaid
where l.ZhunaLocationID!=''


select distinct(h.id),h.hotelname,h.eareaid,l.LocationName,h.ecityid from OTA_TCHotel.dbo.Zhuna_HotelInfo h
left join OTA_TCHotel.dbo.T_LocationInfo l on l.ZhunaLocationID = h.eareaid and h.ecityid=l.ZhunaCityID


SELECT * from OTA_TCHotel.dbo.Zhuna_CityAreaInfo where areaid='0002' and cityid='2103'
select * from OTA_TCHotel.dbo.Zhuna_HotelInfo where id=3954

select * from OTA_TCHotel.dbo.T_CityInfo where ZhunaCityID=1801

select * from OTA_TCHotel.dbo.T_LocationInfo where ZhunaCityID=1801

----------------------------------------------
SELECT distinct(d.id),d.hotelname,d.eareaid,d.ecityid,d.cityname,l.ZhunaLocationID,l.LocationName,b.BrandID,b.BrandName,d.min_jiage from OTA_TCHotel.dbo.Zhuna_HotelInfo d
left JOIN OTA_TCHotel.dbo.T_LocationInfo l on d.eareaid=l.ZhunaLocationID and d.ecityid=l.ZhunaCityID
left JOIN OTA_TCHotel.dbo.T_HotelBrand b on b.ZhunaBrandID = d.liansuoid and b.UnionID=1
inner join OTA_TCHotel.dbo.T_CityInfo c on c.ZhunaCityID=d.ecityid

------------------------------------------------------------
truncate table OTA_TCHotel.dbo.T_HotelInfo

insert into OTA_TCHotel.dbo.T_HotelInfo(HotelID,HotelName,UnionId,Address,CityId,CityName,RefPoint,LocationId,LocationName,HotelImg,BrandId,BrandName,Amount,Lat,Lng,State,Description,HotelStar,ZhunaHotelID)
select d.id,d.hotelname,1 as unionid,d.address,c.ctripcityid,c.cName,d.esdname,isnull(a.ctripareaid,0),isnull(a.areaname,''),d.picture,isnull(h.ctripbrandid,'') ctripbrandid,isnull(h.ls,'') ls,d.min_jiage,d.baidu_lat,d.baidu_lng,1 as state,d.content,d.xingji,0 as ZhunaHotelID from OTA_TCHotel.dbo.Zhuna_HotelInfo d
left join Zhuna_CityAreaInfo a on a.areaid=d.eareaid and a.cityid=d.ecityid
left join Zhuna_HotelChain h on h.id = d.liansuoid
left join Zhuna_CityInfo c on c.cid = d.ecityid


insert into OTA_TCHotel.dbo.T_HotelInfo(HotelID,HotelName,UnionId,Address,CityId,CityName,RefPoint,LocationId,LocationName,HotelImg,BrandId,BrandName,Amount,Lat,Lng,State,Description,HotelStar,ZhunaHotelID)
SELECT d.HotelID,d.HotelName,0 as UnionId,d.AddressLine,d.HotelCityCode,d.CityName,d.ZoneName,d.AreaID,d.AreaName,d.HotelImg,d.BrandCode,isnull(b.BrandName,'') as BrandName,d.TrueAmount,d.Latitude,d.Longitude,1,d.TextItems,d.HotelStarRate,0 from OTA_Hotel.dbo.T_XC_HotelDescription d
left join OTA_TCHotel.dbo.T_HotelBrand b on b.BrandID=d.HotelID



