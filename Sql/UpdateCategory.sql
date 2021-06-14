USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[updatecategory]    Script Date: 14.06.2021 22:56:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[updatecategory](
@CategoryId uniqueidentifier,
@Name nvarchar(50)
)as
begin
update Category
set [Name] = @Name
where Id = @CategoryId
end