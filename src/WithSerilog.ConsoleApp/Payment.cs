using Destructurama.Attributed;

internal class Payment
{
    public int PaymentId { get; set; }
    [LogMasked(ShowFirst = 3)]
    public required string Email { get; set; }
    public Guid UserId { get; set; }
    public DateTime OccuredAt { get; set; }
}