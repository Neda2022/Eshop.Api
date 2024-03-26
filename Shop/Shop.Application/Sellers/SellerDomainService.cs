using Shop.Domain.Entities.SellerAgg;
using Shop.Domain.Entities.SellerAgg.Repository;
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
        private readonly ISellerRepository _repository;

        public SellerDomainService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public bool CheckSellerInfo(Seller seller)
        {
            return _repository.Exists(r=>r.NationalCode == seller.NationalCode|| r.UserId==seller.UserId);
        }

        public bool IsNationalCodeExistInDatabase(string nationalCode)
        {
            return _repository.Exists(r => r.NationalCode == nationalCode);

        }
    }
}
