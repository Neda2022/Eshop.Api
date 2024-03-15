using Shop.Domain.Entities.SellerAgg;
using Shop.Domain.Entities.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers
{
    public class SellerDomainService : ISellerDomainService
    {
        public bool CheckSellerInfo(Seller seller)
        {
            throw new NotImplementedException();
        }

        public bool IsNationalCodeExistInDatabase(string nationalCode)
        {
            throw new NotImplementedException();
        }
    }
}
