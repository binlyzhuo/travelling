if object_id('SP_HotelLowestPriceImport') is not null
drop proc SP_HotelLowestPriceImport
GO
create proc SP_HotelLowestPriceImport
as
with cte2 as(
select *,ROW_NUMBER() over(PARTITION by HotelId order by AmountBeforeTax asc) num from T_CtripHotelRoomRatePlanRecord
) 
INSERT into T_CtripHotelPrice([HotelID]
      ,[RoomCode]
      ,[AmountBeforeTax]
      ,[ListPrice]
      ,[StartDate]
      ,[EndDate]
      ,[AddDate]
      ,[UpdateDate])
select [HotelID]
      ,[RoomTypeCode]
      ,[AmountBeforeTax]
      ,[ListPrice]
      ,[Starttime]
      ,[Endtime]
      ,[AddDate]
      ,[AddDate] from cte2 where num<=1


