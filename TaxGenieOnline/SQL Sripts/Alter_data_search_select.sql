USE [Dev_TaxGenie]
GO
/****** Object:  StoredProcedure [dbo].[Data_Search_Select]    Script Date: 09/03/2012 11:19:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Data_Search_Select]
@searchstr nvarchar(100)
AS
BEGIN

select CEC.Id,CEC.FileNumber as columnvalue,IST.TABLE_NAME from CECNotifications as CEC,INFORMATION_SCHEMA.TABLES as IST 
where freetext(CEC.*,@searchstr) and IST.TABLE_NAME='CECNotifications'
 union all

select C.Id,C.CircularNumber+C.Category+C.GroupType as columnvalue,IST.TABLE_NAME from Circulars as C,INFORMATION_SCHEMA.TABLES as IST 
where freetext(C.*,@searchstr) and IST.TABLE_NAME='Circulars' and C.CircularNumber+C.Category+C.GroupType is not null
 union all
 
 select CE.Id,CE.IndexName as columnvalue,IST.TABLE_NAME from CentralExcise as CE,INFORMATION_SCHEMA.TABLES as IST 
where freetext(CE.*,@searchstr) and IST.TABLE_NAME='CentralExcise'
 union all
 
 select CT.Id,CT.IndexName as columnvalue,IST.TABLE_NAME from Custom_Tariff as CT,INFORMATION_SCHEMA.TABLES as IST 
where freetext(CT.*,@searchstr) and IST.TABLE_NAME='Custom_Tariff'
 union all
 
 select CET.Id,CET.IndexName as columnvalue,IST.TABLE_NAME from CentralExcise_Tariff as CET,INFORMATION_SCHEMA.TABLES as IST 
where freetext(CET.*,@searchstr) and IST.TABLE_NAME='CentralExcise_Tariff'
union all

select CU.Id,CU.IndexName as columnvalue,IST.TABLE_NAME from Customs as CU,INFORMATION_SCHEMA.TABLES as IST 
where freetext(CU.*,@searchstr) and IST.TABLE_NAME='Customs'
union all

select CUN.Id,CUN.FileNumber as columnvalue,IST.TABLE_NAME from CustomsNotifications as CUN,INFORMATION_SCHEMA.TABLES as IST 
where freetext(CUN.*,@searchstr) and IST.TABLE_NAME='CustomsNotifications'
union all

select S.Id,S.IndexName as columnvalue,IST.TABLE_NAME from ServiceTax as S,INFORMATION_SCHEMA.TABLES as IST 
where freetext(S.*,@searchstr) and IST.TABLE_NAME='ServiceTax' 
union all

select STN.Id,STN.FileNumber as columnvalue,IST.TABLE_NAME from ServiceTaxNotifications as STN,INFORMATION_SCHEMA.TABLES as IST 
where freetext(STN.*,@searchstr) and IST.TABLE_NAME='ServiceTaxNotifications' 
union all

select STC.Id,STC.IndexName as columnvalue,IST.TABLE_NAME from STCaselaws as STC,INFORMATION_SCHEMA.TABLES as IST 
where freetext(STC.*,@searchstr) and IST.TABLE_NAME='STCaselaws' 
union all

select DGF.Id,DGF.IndexName as columnvalue,IST.TABLE_NAME from DGFT as DGF,INFORMATION_SCHEMA.TABLES as IST 
where freetext(DGF.*,@searchstr) and IST.TABLE_NAME='DGFT' 
union all

select DGFP.Id,DGFP.IndexName as columnvalue,IST.TABLE_NAME from DGFT_Publicnotices as DGFP,INFORMATION_SCHEMA.TABLES as IST 
where freetext(DGFP.*,@searchstr) and IST.TABLE_NAME='DGFT_Publicnotices' 
union all

select DGFN.Id,DGFN.IndexName as columnvalue,IST.TABLE_NAME from DGFT_Publicnotices as DGFN,INFORMATION_SCHEMA.TABLES as IST 
where freetext(DGFN.*,@searchstr) and IST.TABLE_NAME='DGFT_FTDR_Notifications' 
union all

select L.Id,L.IndexName as columnvalue,IST.TABLE_NAME from Library as L,INFORMATION_SCHEMA.TABLES as IST 
where freetext(L.*,@searchstr) and IST.TABLE_NAME='Library' 
union all

select ITA.Id,ITA.IndexName as columnvalue,IST.TABLE_NAME from IncomeTax_Acts as ITA,INFORMATION_SCHEMA.TABLES as IST
where freetext(ITA.*,@searchstr) and IST.TABLE_NAME='IncomeTax_Acts'
union all

select ITCN.Id,ITCN.IndexName as columnvalue,IST.TABLE_NAME from IncomeTax_CircularsNotification as ITCN,INFORMATION_SCHEMA.TABLES as IST
where freetext(ITCN.*,@searchstr) and IST.TABLE_NAME='IncomeTax_CircularsNotification'
union all

select ITCR.Id,ITCR.IndexName as columnvalue,IST.TABLE_NAME from IncomeTax_Rules as ITCR,INFORMATION_SCHEMA.TABLES as IST
where freetext(ITCR.*,@searchstr) and IST.TABLE_NAME='IncomeTax_Rules'

END