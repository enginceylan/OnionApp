namespace OnionApp.Domain.Entities.Abstraction
{
    public abstract class BaseEntity<TId>
    {
        public virtual TId Id { get; set; } // OrderDetail entitysi bu property'i kullanmayacak, bunu property'i ef üzerinde ignore edeceğiz, ignore edebilmemiz için virtual tanımlamalıyız.

        // AUDIT DATA
        public int? CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
    }
}
