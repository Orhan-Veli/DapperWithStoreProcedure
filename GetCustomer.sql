create proc GetCustomer(
@CustomerId uniqueidentifier
)as
begin
select a.[Name] as CustomerName ,a.LastName as CustomerLastName,l.[Name] as LibraryName from Customers as a
inner join CustomerLibraryRelation as c on a.Id = c.CustomerId 
inner join Libraries as l on c.LibraryId = l.Id
where a.Id = @CustomerId
end