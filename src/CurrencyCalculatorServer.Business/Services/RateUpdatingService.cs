using CurrencyCalculatorServer.Business.Fetchers;
using CurrencyCalculatorServer.Business.Models;
using CurrencyCalculatorServer.Business.Repositories;

namespace CurrencyCalculatorServer.Business.Services
{
    /// <summary>
    /// Rate updating service
    /// </summary>
    /// <seealso cref="CurrencyCalculatorServer.Business.Services.IRateUpdatingService" />
    public class RateUpdatingService : IRateUpdatingService
    {
        private readonly IRatesFetcher _ratesFetcher;
        private readonly ICurrencyManagmentService _currencyManagmentService;
        private readonly IRatesRepository _ratesRepository;
        private readonly IDataContext _dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RateUpdatingService"/> class.
        /// </summary>
        /// <param name="ratesFetcher">The rates fetcher.</param>
        /// <param name="currencyManagmentService">The currency managment service.</param>
        /// <param name="ratesRepository">The rates repository.</param>
        /// <param name="dataContext">The data context.</param>
        public RateUpdatingService(IRatesFetcher ratesFetcher, ICurrencyManagmentService currencyManagmentService, IRatesRepository ratesRepository, IDataContext dataContext)
        {
            _ratesFetcher = ratesFetcher;
            _currencyManagmentService = currencyManagmentService;
            _ratesRepository = ratesRepository;
            _dataContext = dataContext;
        }

        /// <summary>
        /// Updates the daily rates.
        /// </summary>
        /// <param name="token">The token.</param>
        public async Task UpdateDailyRates(CancellationToken token)
        {
            var dailyRateModels = await _ratesFetcher.GetDailyRatesForToday(token);

            var dailyRates = await GetRates(dailyRateModels, RateType.Daily, token);

            await _ratesRepository.InsertOrUpdateRange(dailyRates, token);

            await _dataContext.SaveChanges(token);
        }

        /// <summary>
        /// Updates the monthly rates.
        /// </summary>
        /// <param name="token">The token.</param>
        public async Task UpdateMonthlyRates(CancellationToken token)
        {
            var monthlyRateModels = await _ratesFetcher.GetMonthlyRatesForThisMonth(token);

            var monthlyRates = await GetRates(monthlyRateModels, RateType.Monthly, token);

            await _ratesRepository.InsertOrUpdateRange(monthlyRates, token);

            await _dataContext.SaveChanges(token);
        }

        private async Task<List<Rate>> GetRates(IEnumerable<RateModel> rates, RateType type, CancellationToken token)
        {
            foreach (var rate in rates)
            {
                await _currencyManagmentService.AddCurrencyIfItNotExists(rate.Cur_ID, token);
            }

            return rates.Select(e => new Rate
            {
                CurrencyId = e.Cur_ID,
                Date = e.Date,
                Price = Convert.ToDecimal(e.Cur_OfficialRate) / e.Cur_Scale,
                Type = type
            }).ToList();
        }
    }
}
