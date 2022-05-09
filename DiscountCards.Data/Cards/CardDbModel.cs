using DiscountCards.Data.Shops;
using DiscountCards.Data.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountCards.Data.Cards
{
    public class CardDbModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual UserDbModel User { get; set; }
        public int ShopId { get; set; }
        public ShopDbModel Shop { get; set; }
        public string Number { get; set; }
    }
    
    internal class Map : IEntityTypeConfiguration<CardDbModel>
    {
        public void Configure(EntityTypeBuilder<CardDbModel> builder)
        {
            builder.HasOne(it => it.User)
                .WithMany(it => it.Cards)
                .HasForeignKey(it => it.UserId);

        }
    }
}
