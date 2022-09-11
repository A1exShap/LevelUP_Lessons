namespace Domain
{
    public interface IItemModel
    {
        Guid Id { get; }
        
        Guid ItemType { get; }
        
        string? Name { get; }
        
        string? Description { get; }
    }
}
