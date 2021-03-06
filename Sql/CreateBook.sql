USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[CreateBooks]    Script Date: 13.06.2021 19:13:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--create type id_list as table(id uniqueidentifier not null);
--create type lib_list as table(id uniqueidentifier not null);
ALTER proc [dbo].[CreateBooks](
@Name nvarchar(50),
@WriterId uniqueidentifier,
@CategoryIds id_list readonly,
@LibraryIds lib_list readonly
)as
begin 
declare @BookId uniqueidentifier
set @BookId = NEWID();
declare @LibraryId uniqueidentifier
set @LibraryId = NEWID();


insert into Books values(@BookId,@Name,@WriterId);
declare @tempId uniqueidentifier
declare @TempLibraryId uniqueidentifier

declare bookCursor cursor for select id from @CategoryIds
open bookCursor
fetch next from bookCursor into @tempId
while(@@FETCH_STATUS = 0)
begin
declare @CategoryBookRelationId uniqueidentifier
set @CategoryBookRelationId = NEWID();
insert into dbo.CategoryBookRelation values(@CategoryBookRelationId,@BookId,@tempId)
fetch next from bookCursor into @tempId
end


declare libraryCursor cursor for select id from @LibraryIds
open libraryCursor
fetch next from libraryCursor into @TempLibraryId
while(@@FETCH_STATUS = 0)
begin 
declare @BookLibraryRelation uniqueidentifier
set @BookLibraryRelation = NEWID()
insert into BookLibraryRelation values(@BookLibraryRelation,@BookId,@TempLibraryId)
fetch next from libraryCursor into @TempLibraryId
end

close bookCursor
deallocate bookCursor
close libraryCursor
deallocate libraryCursor
end