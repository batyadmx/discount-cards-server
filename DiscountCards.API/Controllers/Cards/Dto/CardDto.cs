namespace DiscountCards.API.Controllers.Cards.Dto
{
    public class CardDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShopId { get; set; }
        public string Number { get; set; }
        public int Standart { get; set; }
    }
}
