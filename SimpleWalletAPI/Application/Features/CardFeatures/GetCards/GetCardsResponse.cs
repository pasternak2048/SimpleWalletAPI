namespace Application.Features.CardFeatures.GetCards
{
    public sealed class GetCardsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Balance { get; set; }
    }
}
