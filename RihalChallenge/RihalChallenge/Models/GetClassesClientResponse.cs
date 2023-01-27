using RihalChallenge.Client.Stores.ClassesStore;

namespace RihalChallenge.Client.Models;

public record GetClassesClientResponse(IEnumerable<Class> Classes);