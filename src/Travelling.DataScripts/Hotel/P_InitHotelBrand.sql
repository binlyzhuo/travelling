truncate table OTA_TCHotel.dbo.T_HotelBrand

insert into OTA_TCHotel.dbo.T_HotelBrand(BrandID,ZhunaBrandID,BrandName,BrandImg,UnionID)
select b.BrandID,d.lsid,d.liansuo,d.tupian,1 from OTA_Hotel.dbo.T_XC_HotelBrandDetailInfo b
inner join OTA_TCHotel.dbo.Zhuna_HotelChain d on b.BrandID=d.ctripbrandid

insert into  OTA_TCHotel.dbo.T_HotelBrand(BrandID,ZhunaBrandID,BrandName,BrandImg,UnionID)
select BrandID,0,BrandName,BrandImg,0 from OTA_Hotel.dbo.T_XC_HotelBrandDetailInfo where BrandID not in(select b.BrandID from OTA_Hotel.dbo.T_XC_HotelBrandDetailInfo b
inner join OTA_TCHotel.dbo.Zhuna_HotelChain d on b.BrandID=d.ctripbrandid
)
insert into  OTA_TCHotel.dbo.T_HotelBrand(BrandID,ZhunaBrandID,BrandName,BrandImg,UnionID)
select 0,lsid,liansuo,tupian,1 from OTA_TCHotel.dbo.Zhuna_HotelChain where ctripbrandid=0

update OTA_TCHotel.dbo.T_HotelBrand set BrandID = 10000+ID where BrandID=0 
