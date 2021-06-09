create proc GetWriter(
@WriterId uniqueidentifier
)as
begin
select * from Writers
where Id = @WriterId
end