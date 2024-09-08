using System;

namespace HouseRentingSystem.Infrastructure.Contracts
{
    public interface IHouseModel
    {
        public string Title { get; }
        public string Address { get; }
    }
}
