using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
using IntegrationLibrary.Statistics.Model;
using IntegrationLibrary.Statistics.Service.ServiceImpl;
using IntegrationLibrary.Tendering.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class TenderStatisticsController : Controller
    {
        private IStatisticsService statistcsService;

        public TenderStatisticsController(IStatisticsService statistcsService)
        {
            this.statistcsService = statistcsService;
        }

        [HttpGet("statisticsPharmacyWinningsDefeat/{apiKey?}")]
        public IActionResult statisticsPharmacyWinningsDefeat(String apiKey)
        {
            if (apiKey == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(StatisticPharmacyWinningDefeatAdapter.ToStatisticPharmacyWinningDefeatDTO(this.statistcsService.statisticPharmacyWinningsDefeat(apiKey)));
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
                return Ok(StatisticPharmacyWinningDefeatAdapter.ToStatisticPharmacyWinningDefeatDTO(this.statistcsService.statisticPharmacyParticipation(apiKey)));
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
                return Ok(BarChartStatisticAdapter.BarChartStatisticToBarChartStatisticDTO(statistcsService.statisticPharmacyWinnerOffers(apiKey)));
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
                return Ok(BarChartStatisticAdapter.BarChartStatisticToBarChartStatisticDTO(this.statistcsService.statisticPharmacyAcitveTenderOffers(apiKey)));
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
                return Ok(BarChartTenderStatisticsAdapter.BarChartStatisticToBarChartStatisticDTO(this.statistcsService.statisticTenderWinnerOffers(statistics.DateStart, statistics.DateEnd)));
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
                return Ok(BarChartTenderStatisticsAdapter.BarChartStatisticToBarChartStatisticDTO(this.statistcsService.statisticTenderPharmacyProfits(statistics.DateStart, statistics.DateEnd)));
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
                return Ok(TwoBarChartStatisticAdapter.BarChartStatisticToBarChartStatisticDTO(this.statistcsService.statisticTenderWinningDefeat(statistics.DateStart, statistics.DateEnd)));
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
                return Ok(TwoBarChartStatisticAdapter.BarChartStatisticToBarChartStatisticDTO(this.statistcsService.statisticTenderWinningParticipate(statistics.DateStart, statistics.DateEnd)));
            }
        }
    }
}
