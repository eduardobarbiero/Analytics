namespace Application.Domain.Domain
{
    public interface Entity<TId>
    {
        TId Id { get; set; }
    }
}