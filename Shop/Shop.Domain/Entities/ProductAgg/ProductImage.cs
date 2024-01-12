using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.Entities.ProductAgg;

public class ProductImage : BaseEntity
    {
    public ProductImage(string imageName, int sequence)
    {
        NullOrEmtyDomainDataException.CheckString(imageName,nameof(imageName));
        ImageName = imageName;
        Sequence = sequence;
    }

    public long ProductId { get; internal set; }
    public string ImageName { get; private set; }
    public int Sequence { get; private set; }
                               

}

