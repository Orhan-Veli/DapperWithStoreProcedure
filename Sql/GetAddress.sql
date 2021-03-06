USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[GetAddress]    Script Date: 15.06.2021 22:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[GetAddress](
@CountryId uniqueidentifier,
@CountyId uniqueidentifier,
@DistrictId uniqueidentifier,
@StateId uniqueidentifier

)as
begin
select * from Country   		
	
select [Name] from Country where Id = @CountryId		
select [Name] from County where Id = @CountyId	
select [Name] from State where Id = @StateId
select [Name] from District where Id = @DistrictId
end