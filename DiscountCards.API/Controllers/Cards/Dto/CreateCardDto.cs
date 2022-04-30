using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCards.API.Controllers.Cards.Dto
{
    public class CreateCardDto
    {
        public string Number { get; set; }
        public int UserId { get; set; }
    }
}
