using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.Cards
{
    public class Card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int UserId { get; set; }
    }
}
