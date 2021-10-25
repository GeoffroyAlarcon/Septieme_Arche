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
    /// <summary>
///  ce service permet à la septième Arche de faire du reporting pour établir une stratégie afin de piloter  les ventes
///  La méthode StockIsEmpty permet de générer une liste de tous les articles qui est en rupture de stock
///  la méthode TopTenMostSold permet de savoir les dix articles les plus vendus de la septième arche
///  la méthode TopTenMostView permet de savoir les dix articles les plus cliqués de la septième arche 
/// </summary>
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
