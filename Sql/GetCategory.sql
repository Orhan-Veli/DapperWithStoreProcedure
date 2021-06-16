USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[GetCategory]    Script Date: 16.06.2021 22:45:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[GetCategory](
@CategoryId uniqueidentifier
)
as
begin
select * from Category
select [Name] from Category where  Id = @CategoryId  
end