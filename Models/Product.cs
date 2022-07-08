using System.ComponentModel.DataAnnotations;

namespace RelationTest.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name="商品名稱")]
        public string Name { get; set; }

        [Display(Name = "商品描述")]
        public string Description { get; set; }

        [Display(Name = "商品分類")]
        public int CategoryId { get; set; }
        public CheeseCategory? Category { get; set; }
    }
}
