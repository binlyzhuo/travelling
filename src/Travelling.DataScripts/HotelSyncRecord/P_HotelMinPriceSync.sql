if object_id('P_HotelMinPriceSync') is not null
drop PROC P_HotelMinPriceSync
GO
create proc P_HotelMinPriceSync
as
with cte2 as(
select *,ROW_NUMBER() over(PARTITION by HotelId order by AmountBeforeTax asc) num from [dbo].[T_HotelSyncRoomRatePlan]
) 
INSERT into T_HotelPriceSyncInfo([HotelID]
      ,[RoomTypeCode]
      ,[AmountBeforeTax]
      ,[ListAmount]
      ,[AddDate])
select [HotelID]
      ,[RoomTypeCode]
      ,[AmountBeforeTax]
      ,[ListPrice]
      ,[AddDate] from cte2 where num<=1