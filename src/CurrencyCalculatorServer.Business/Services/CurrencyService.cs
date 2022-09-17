using AutoMapper;
using CurrencyCalculatorServer.Business.Fetchers;
using CurrencyCalculatorServer.Business.Models;
using CurrencyCalculatorServer.Business.Providers;
using CurrencyCalculatorServer.Business.Repositories;

namespace CurrencyCalculatorServer.Business.Services
{
    /// <summary>
    /// Currency service
    /// </summary>
    /// <seealso cref="CurrencyCalculatorServer.Business.Services.ICurrencyInitializingService" />
    /// <seealso cref="CurrencyCalculatorServer.Business.Services.ICurrencyManagmentService" />
    public class CurrencyService : ICurrencyInitializingService, ICurrencyManagmentService
    {
        private readonly ICurrenciesFetcher _currenciesFetcher;
        private readonly ICurrenciesRepository _currenciesRepository;
        private readonly ICurrenciesProvider _currenciesProvider;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyService"/> class.
        /// </summary>
        /// <param name="currenciesFetcher">The currencies fetcher.</param>
        /// <param name="currenciesRepository">The currencies repository.</param>
        /// <param name="currenciesProvider">The currencies provider.</param>
        /// <param name="dataContext">The data context.</param>
        /// <param name="mapper">The mapper.</param>
        public CurrencyService(ICurrenciesFetcher currenciesFetcher, ICurrenciesRepository currenciesRepository, ICurrenciesProvider currenciesProvider, IDataContext dataContext, IMapper mapper)
        {
            _currenciesFetcher = currenciesFetcher;
            _currenciesRepository = currenciesRepository;
            _currenciesProvider = currenciesProvider;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Initializes the currencies.
        /// </summary>
        /// <param name="token">The token.</param>
        public async Task InitializeCurrencies(CancellationToken token)
        {
            var currencyModels = await _currenciesFetcher.GetAllCurrencies(token);

            var currencies = _mapper.Map<List<Currency>>(currencyModels);

            await _currenciesRepository.AddRange(currencies, token);

            await _dataContext.SaveChanges(token);
        }

        /// <summary>
        /// Clears the currencies table.
        /// </summary>
        /// <param name="token">The token.</param>
        public async Task Clear(CancellationToken token)
        {
            await _currenciesRepository.Clear(token);

            await _dataContext.SaveChanges(token);
        }

        /// <summary>
        /// Adds the currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <param name="token">The token.</param>
        public async Task AddCurrencyIfItNotExists(int currencyId, CancellationToken token)
        {
            var isExisting = await _currenciesProvider.GetCurrencyById(currencyId, token) is not null;

            if (isExisting)
                return;

            var currencyModel = await _currenciesFetcher.GetCurrency(currencyId, token);

            var currency = _mapper.Map<Currency>(currencyModel);

            await _currenciesRepository.Add(currency, token);
        }
    }
}
