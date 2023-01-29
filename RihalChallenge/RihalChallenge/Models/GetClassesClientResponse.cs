using RihalChallenge.Client.Models.Classes;

namespace RihalChallenge.Client.Models;

public record GetClassesClientResponse(IEnumerable<Class> Classes);