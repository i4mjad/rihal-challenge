using System.ComponentModel.DataAnnotations;

namespace RihalChallenge.Client.Forms
{
    public class ExampleModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public Guid? CountryId { get; set; }

        [Required]
        public Guid? ClassId { get; set; }

        [Required]
        public DateTime? DayOfBirth { get; set; }


    }
}
