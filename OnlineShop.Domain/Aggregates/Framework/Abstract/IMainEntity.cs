namespace OnlineShop.Domain.Aggregates.Framework.Abstract
{
    public interface IMainEntity
    {
        string? CreatedDatePersian { get; set; }
        bool isModified { get; set; }
        bool IsSoftDeleted { get; set; }
        string? ModifyDatePersian { get; set; }
        string? SoftDeleteDatePersian { get; set; }
    }
}