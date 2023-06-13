using Bemerkto.Helpers.Repositories;
using Bemerkto.Models.Entities;
using System.Diagnostics;

namespace Bemerkto.Helpers.Services;

public class AddressService
{
    private readonly AddressRepository _addressRepository;
    private readonly UserAddressRepository _userAddressRepository;

    public AddressService(AddressRepository addressRepository, UserAddressRepository userAddressRepository)
    {
        _addressRepository = addressRepository;
        _userAddressRepository = userAddressRepository;
    }

    public async Task<AddressEntity> GetOrCreateAsync(AddressEntity entity)
    {
        var _entity = await _addressRepository.GetAsync(x => x.StreetName == entity.StreetName && x.PostalCode == entity.PostalCode && x.City == entity.City);
        _entity ??= await _addressRepository.AddAsync(entity);

        return _entity;
    }

    public async Task<bool> AddUserAddress(string userId, int addressId)
    {
        try
        {
            var entity = await _userAddressRepository.AddAsync(new UserAddressEntity
            {
                UserId = userId,
                AddressId = addressId
            });

            if (entity != null)
                return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
    }
}
