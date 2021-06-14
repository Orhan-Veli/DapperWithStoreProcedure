USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[UpdateWriter]    Script Date: 14.06.2021 22:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateWriter](
@Id uniqueidentifier,
@Name nvarchar(50),
@LastName nvarchar(50)
)as
begin
Update Writers
set [Name] = @Name,
LastName = @LastName
where Id = @Id
end