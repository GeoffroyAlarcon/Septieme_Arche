using api.models;
using api.Repository.Interfaces;
using api.septiemarche.Repository.Interfaces;
using api.septiemarche.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.septiemarche.services
{
    public class ReportingService : IReportingService
    {
        IReportingRepository _reportingRepository;
        IUserRepository _userRepository;

        public ReportingService(IReportingRepository reportingRepository, IUserRepository userRepository)
        {
            _reportingRepository = reportingRepository;
            _userRepository = userRepository;
        }
        public List<Item> Stockisempty()
        {
            List<Item> result = _reportingRepository.Stockisempty();
            return result;
                
                }

        public List<Item> TopTenItemMostSold()
        {
            List<Item> result = _reportingRepository.TopTenItemMostSold();
            return result;
        }

        public List<Item> TopTenItemMostView()
        {
            List<Item> result = _reportingRepository.TopTenItemMostView();
            return result;

        }
    }
}
