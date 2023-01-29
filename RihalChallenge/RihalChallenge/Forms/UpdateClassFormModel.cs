using System.ComponentModel.DataAnnotations;

namespace RihalChallenge.Client.Forms;

public class UpdateClassFormModel
{
    [Required]
    public string Name { get; set; }
}