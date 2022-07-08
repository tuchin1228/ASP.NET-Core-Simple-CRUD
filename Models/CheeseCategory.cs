using System.ComponentModel.DataAnnotations;

namespace RelationTest.Models
{
    public class CheeseCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="分類名稱為必填")]
        public string Name { get; set; }

        //public IList<Product> Products { get; set; }
        public ICollection<Product> ? Products { get; set; }
    }
}
