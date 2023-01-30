using System.ComponentModel.DataAnnotations;

namespace RihalChallenge.Client.Forms;

public class UpdateCountryFormModel
{
    [Required]
    public string Name { get; set; }
}