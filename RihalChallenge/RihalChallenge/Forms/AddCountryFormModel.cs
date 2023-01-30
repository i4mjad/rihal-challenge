using System.ComponentModel.DataAnnotations;

namespace RihalChallenge.Client.Forms;

public class AddCountryFormModel
{
    [Required]
    public string Name { get; set; }
}