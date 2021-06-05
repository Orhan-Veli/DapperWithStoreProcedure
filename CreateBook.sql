--create type id_list as table(id uniqueidentifier not null);
create proc CreateBooks(
@Name nvarchar(50),
@WriterId uniqueidentifier,
@CategoryIds id_list readonly
)as
begin 
	declare @BookId uniqueidentifier
	set @BookId = NEWID();
	insert into Books values(@BookId,@Name,@WriterId);
	declare @tempId uniqueidentifier
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
	close bookCursor
	deallocate bookCursor
end