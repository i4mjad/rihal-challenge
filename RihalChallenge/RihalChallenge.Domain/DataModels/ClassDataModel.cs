using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RihalChallenge.Domain.DataModels;

[Table("Classes")]
public class ClassDataModel
{	
	public string Id { get; set; }
	public string ClassName { get; set; }		
}


