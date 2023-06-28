﻿namespace Application.Features.CardFeatures.GetCard
{
    public class GetCardResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Balance { get; set; }
        public double BalanceLimit { get; set; }
    }
}
