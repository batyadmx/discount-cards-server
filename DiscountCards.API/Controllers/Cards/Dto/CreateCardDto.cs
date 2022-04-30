namespace DiscountCards.API.Controllers.Cards.Dto
{
    public class CreateCardDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string ImageSource { get; set; }
    }
}
