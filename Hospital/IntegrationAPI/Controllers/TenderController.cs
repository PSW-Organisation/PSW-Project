using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Pharmacies.Service.ServiceInterfaces;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private ITenderService tenderService;

        private IPharmacyService pharmacyService;

        public TenderController(ITenderService tenderService, IPharmacyService pharmacyService)
        {
            this.tenderService = tenderService;
            this.pharmacyService = pharmacyService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<TenderDTO> tenderDtos = new List<TenderDTO>();
            //tenderService.Get().ToList().ForEach(tender => tenderDtos.Add(TenderAdapter.TenderToTenderDto(tender)));
            foreach(Tender tender in tenderService.Get())
            {
                if(tender.TenderCloseDate < DateTime.Now)
                {
                    CloseTender(tender.Id);
                    
                }
                tenderDtos.Add(TenderAdapter.TenderToTenderDto(tender));
            }
            return Ok(tenderDtos);
        }

        [HttpPost]
        public IActionResult Add(TenderDTO dto)
        {
            return Ok(tenderService.Add(dto.TenderItems, TenderAdapter.TenderDtoToTender(dto)));
        }

        [HttpGet("{id?}")]
        public IActionResult Get(int id)
        {
            Tender tender = tenderService.Get(id);
            if (tender == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(TenderAdapter.TenderToTenderDto(tender));
            }
        }
        
        [HttpGet("close/{id?}")]
        public IActionResult CloseTender(int id)
        {
            Tender tender = tenderService.Get(id);
            if (tender == null)
            {
                return NotFound();
            }
            tender.Open = false;
            tenderService.Update(tender);
            foreach(Pharmacy pharmacy in pharmacyService.GetAll())
            {
                var client = new RestClient(pharmacy.PharmacyUrl);
                var request = new RestRequest("/tender/notwon/" + id, Method.GET);
                var cancellationTokenSource = new CancellationTokenSource();
                client.ExecuteAsync(request, cancellationTokenSource.Token);
            }
            return Ok();
        }

        [HttpGet("statisticsPharmacyWinningsDefeat/{apiKey?}")]
        public IActionResult statisticsPharmacyWinningsDefeat(String apiKey)
        {
            if (apiKey == null)
            {
                return NotFound();
            } else
            {
                List<int> stat = this.tenderService.statisticPharmacyWinningsDefeat(apiKey);
                StatisticPharmacyWinningDefeatDTO array = new StatisticPharmacyWinningDefeatDTO();
                array.Statistic = stat;
                return Ok(array);
            }  
        }

        [HttpGet("statisticsPharmacyParticipate/{apiKey?}")]
        public IActionResult statisticPharmacyParticipation(String apiKey)
        {
            if (apiKey == null)
            {
                return NotFound();
            }
            else
            {
                List<int> ret = this.tenderService.statisticPharmacyParticipation(apiKey);
                StatisticPharmacyWinningDefeatDTO array = new StatisticPharmacyWinningDefeatDTO();
                array.Statistic = ret;
                return Ok(array);
            }
        }

        [HttpGet("statisticPharmacyWinnerOffers/{apiKey?}")]
        public IActionResult statisticPharmacyWinnerOffers(String apiKey)
        {
            if (apiKey == null)
            {
                return NotFound();
            }
            else
            {
                BarChartStatistic ret = this.tenderService.statisticPharmacyWinnerOffers(apiKey);
                return Ok(new BarChartStatisticDTO(ret.X, ret.Y));
            }
        }

        [HttpGet("statisticPharmacyAcitiveTenderOffers/{apiKey?}")]
        public IActionResult statisticPharmacyAcitiveTenderOffers(String apiKey)
        {
            if (apiKey == null)
            {
                return NotFound();
            }
            else
            {
                BarChartStatistic ret = this.tenderService.statisticPharmacyAcitveTenderOffers(apiKey);
                return Ok(new BarChartStatisticDTO(ret.X, ret.Y));
            }
        }

        [HttpPost("statisticTenderWinnerOffers")]
        public IActionResult statisticTenderWinnerOffers(StatisticsDTO statistics)
        {
            if (statistics == null)
            {
                return NotFound();
            }
            else
            {
                BarChartTenderStatistic ret = this.tenderService.statisticTenderWinnerOffers(statistics.DateStart, statistics.DateEnd);
                return Ok(new BarChartTenderStatisticsDTO(ret.X, ret.Y));
            }
        }

        [HttpPost("statisticTenderPharmacyProfits")]
        public IActionResult statisticTenderPharmacyProfits(StatisticsDTO statistics)
        {
            if (statistics == null)
            {
                return NotFound();
            }
            else
            {
                BarChartTenderStatistic ret = this.tenderService.statisticTenderPharmacyProfits(statistics.DateStart, statistics.DateEnd);
                return Ok(new BarChartTenderStatisticsDTO(ret.X, ret.Y));
            }
        }

        [HttpPost("statisticTenderWinningDefeat")]
        public IActionResult statisticTenderWinningDefeat(StatisticsDTO statistics)
        {
            if (statistics == null)
            {
                return NotFound();
            }
            else
            {
                TwoBarChartStatistic ret = this.tenderService.statisticTenderWinningDefeat(statistics.DateStart, statistics.DateEnd);
                return Ok(new TwoBarChartStatisticDTO(ret.X, ret.Y, ret.Z));
            }
        }

        [HttpPost("statisticTenderParticipate")]
        public IActionResult statisticTenderParticipate(StatisticsDTO statistics)
        {
            if (statistics == null)
            {
                return NotFound();
            }
            else
            {
                TwoBarChartStatistic ret = this.tenderService.statisticTenderWinningParticipate(statistics.DateStart, statistics.DateEnd);
                return Ok(new TwoBarChartStatisticDTO(ret.X, ret.Y, ret.Z));
            }
        }
    }
}
