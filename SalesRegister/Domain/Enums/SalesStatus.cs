namespace SalesRegisterWebAPI.Domain.Enums
{
    public enum SalesStatus
    {
        PaymentPending = 0, 
        PaymentApproved = 1, 
        Shipping = 2,
        Delivered = 3,
        Canceled = 4
    }
}
