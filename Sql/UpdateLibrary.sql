USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[UpdateLibrary]    Script Date: 14.06.2021 22:57:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateLibrary](
@Id uniqueidentifier,
@Name nvarchar(50)
)as
begin
update Libraries
set [Name] = @Name
where Id = @Id
end