using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.Entities.ProductAgg;

public class ProductSpecification : BaseEntity
{
    public ProductSpecification(string key, string value)
    {
        NullOrEmtyDomainDataException.CheckString(key, nameof(key));
        NullOrEmtyDomainDataException.CheckString(value, nameof(value));

        this.key = key;
        Value = value;
    }

    public long ProductId { get; internal set; }
    public string key { get; private set; }
    public string Value { get; private set; }


}

