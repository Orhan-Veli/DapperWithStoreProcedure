create proc GetManager(
@ManagerId uniqueidentifier
)as
begin
select m.[Name] as ManagerName, m.LastName as ManagerLastName, l.[Name] as LibraryName from Managers as m
inner join Libraries as l on l.Id = m.LibraryId
where m.Id = @ManagerId
end