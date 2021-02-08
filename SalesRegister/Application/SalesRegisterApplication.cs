using AutoMapper;
using SalesRegisterWebAPI.Domain.DTO;
using SalesRegisterWebAPI.Domain.Enums;
using SalesRegisterWebAPI.Domain.Models;
using SalesRegisterWebAPI.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesRegisterWebAPI.Application
{
    public class SalesRegisterApplication : ISalesRegisterApplication
    {
        private readonly IMapper _mapper;
        private readonly ISalesRegisterRepository _salesRegisterRepository;
        public SalesRegisterApplication(IMapper mapper, ISalesRegisterRepository salesRegisterRepository)
        {
            this._mapper = mapper;
            this._salesRegisterRepository = salesRegisterRepository;
        }
        public async Task<SalesRegister> CreateSalesRegisterAsync(SalesRegisterDTO salesRegisterDTO)
        {
            var vehicles = new List<Vehicle>();
            
            foreach (var vehicleDTO in salesRegisterDTO.VehicleDTOs)
            {
                var vehicle = _mapper.Map<Vehicle>(vehicleDTO);

                vehicles.Add(vehicle);
            }

            var seller = _mapper.Map<Seller>(salesRegisterDTO.SellerDTO);

            var salesRegister = new SalesRegister(DateTime.Now, seller, vehicles);

            return await _salesRegisterRepository.SaveSalesRegisterAsync(salesRegister);            
        }

        public async Task<SalesRegister> GetSalesRegisterByIdAsync(long idSalesRegister)
        {
            return await _salesRegisterRepository.GetSalesRegisterAsync(idSalesRegister);
        }

        public async Task<SalesRegister> UpdateSalesRegisterAsync(SalesRegisterPutDTO salesRegisterPutDTO)
        {
            var salesRegister = await _salesRegisterRepository.GetSalesRegisterAsync(salesRegisterPutDTO.IdSalesRegister);

            salesRegister.Status = salesRegisterPutDTO.Status;

            return await _salesRegisterRepository.UpdateSalesRegisterAsync(salesRegister);
        }

        public async Task<bool> ValidateStatusChangeSalesRegister(SalesStatus newStatus, long idSalesRegister)
        {
            var salesRegister = await _salesRegisterRepository.GetSalesRegisterAsync(idSalesRegister);

            switch (salesRegister.Status)
            {
                case SalesStatus.PaymentPending:
                    if ((newStatus != SalesStatus.PaymentApproved) && (newStatus != SalesStatus.Canceled))
                        return false;
                    break;
                case SalesStatus.PaymentApproved:
                    if ((newStatus != SalesStatus.Shipping) && (newStatus != SalesStatus.Canceled))
                        return false;
                    break;
                case SalesStatus.Shipping:
                    if (newStatus != SalesStatus.Delivered)
                        return false;
                    break;
                case SalesStatus.Delivered:
                  return false;
                case SalesStatus.Canceled:
                    return false;
            }

            return true;
        }
    }
}