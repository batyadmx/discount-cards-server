namespace DiscountCards.API.Controllers.Cards.Dto
{
    public class CreateCardDto
    {
        public string UserLogin { get; set; }
        public int ShopId { get; set; }
        public string Number { get; set; }
    }
}
