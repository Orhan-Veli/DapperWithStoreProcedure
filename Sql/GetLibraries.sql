USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[GetLibraries]    Script Date: 19.06.2021 03:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[GetLibraries](
@LibraryId uniqueidentifier
)
as
begin
select * from Libraries
select [Name] from Libraries where Id = @LibraryId
end