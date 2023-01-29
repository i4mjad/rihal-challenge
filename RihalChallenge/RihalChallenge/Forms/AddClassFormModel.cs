using System.ComponentModel.DataAnnotations;

namespace RihalChallenge.Client.Forms;

public class AddClassFormModel
{
    [Required]
    public string Name { get; set; }
}