namespace BugStore.Application.Requests.Orders;

public class GetOrdersByCustomer : PagedRequest
{
    public Guid CustomerId { get; set; }
}
