using RihalChallenge.Client.Stores.ClassesStore;

namespace RihalChallenge.Client.Models.Classes;

public record DeleteClassClientResponse(IEnumerable<Class> Classes);