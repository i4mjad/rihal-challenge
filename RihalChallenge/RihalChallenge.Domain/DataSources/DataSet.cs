namespace RihalChallenge.Domain.DataSources;

public class DataSet<T>
{
    public List<T> Items;

    public void Add(T item)
    {
        Items.Add(item);
    }

    public List<T> GetAll()
    {
        return Items;
    }

    public void Delete(T item)
    {
        Items.Remove(item);
    }

    public void Update(T current,T updated)
    {
        Items[Items.IndexOf(current)] = updated;
    }



}