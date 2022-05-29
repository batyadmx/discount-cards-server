namespace DiscountCards.API.Controllers.Cards.Dto
{
    public class CreateCardDto
    {
        public string UserLogin { get; set; }
        public string ShopName { get; set; }
        public string Number { get; set; }
        public int Standart { get; set; }
    }
}
