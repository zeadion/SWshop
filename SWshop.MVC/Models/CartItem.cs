using System.ComponentModel.DataAnnotations;
using SWshop.MVC.ViewModels;

namespace SWshop.MVC.Models
{
    public class CartItem
    {
        public const int NoPromotions = 0;
        //pay 1 take 2
        public const int Promotion1 = 1;
        //3 for $10
        public const int Promotion2 = 2;

        public CartItem()
        {
            PromotionApplied = NoPromotions;
            Count = 0;
        }

        public ProductViewModel Product { get; set; }
        public int Count { get; set; }
        public int PromotionApplied { get; set; }

        [DataType(DataType.Currency)]
        public decimal GetRegularPrice()
        {
            return Product.Price * Count;
            ;
        }

        [DataType(DataType.Currency)]
        public decimal GetPromotionPrice()
        {
            switch (PromotionApplied)
            {
                case Promotion1:
                    return Product.Price * (Count + (Count % 2)) / 2; 
                case Promotion2:
                    return (Count / 3) * 10 + Product.Price * (Count % 3); 
                default:
                    return GetRegularPrice();
            }
        }


        [DataType(DataType.Currency)]
        public decimal GetPromotionPrice(int promotion)
        {
            switch (promotion)
            {
                case Promotion1:
                    return Product.Price * (Count + (Count % 2)) / 2;
                case Promotion2:
                    return (Count / 3) * 10 + Product.Price * (Count % 3);
                default:
                    return GetRegularPrice();
            }
        }
    }
}