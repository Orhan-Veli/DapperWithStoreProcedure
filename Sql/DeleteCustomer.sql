create proc DeleteCustomer(
@CustomerId uniqueidentifier
)as
begin 
delete from CustomerLibraryRelation where CustomerId = @CustomerId
delete from Customers where Id = @CustomerId 
end