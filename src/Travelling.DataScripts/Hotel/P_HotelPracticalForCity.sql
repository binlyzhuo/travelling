if object_id('P_HotelPracticalForCity') is not null
drop proc P_HotelPracticalForCity
GO
create proc P_HotelPracticalForCity
@cityid int
as
select top 6 d.HotelID,d.HotelImg,d.HotelName,d.HotelCityCode,p.AmountBeforeTax,p.ListAmount,(p.ListAmount-p.AmountBeforeTax) as PriceDiff  from T_HotelDescription d with(NOLOCK)
inner join T_HotelPrice p WITH(NOLOCK) on d.HotelID = p.HotelID
where d.HotelCityCode=@cityid and isnull(d.HotelImg,'') !='' and p.AmountBeforeTax>0 and (p.ListAmount-p.AmountBeforeTax)>0
order by d.CtripCommRate desc,p.AmountBeforeTax asc,PriceDiff DESC