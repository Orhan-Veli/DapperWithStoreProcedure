USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[UpdateBook]    Script Date: 14.06.2021 22:24:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateBook](
@BookId uniqueidentifier,
@BookName nvarchar(50),
@WriterId uniqueidentifier
)as
begin
	Update Books
	set Books.[Name] = @BookName
	where Id = @BookId
	Update Books
	set WriterId = @WriterId
	where Id = @BookId
end
