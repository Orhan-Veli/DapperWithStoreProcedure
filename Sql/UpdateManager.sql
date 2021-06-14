USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[UpdateManager]    Script Date: 14.06.2021 22:57:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateManager](
@Id uniqueidentifier,
@Name nvarchar(50),
@LastName nvarchar(50),
@LibraryId uniqueidentifier
)as
begin
update Managers
set [Name] = @Name,
LastName = @LastName,
LibraryId = @LibraryId
where Id = @Id
end