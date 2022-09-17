using AutoMapper;
using CurrencyCalculatorServer.Business.Models;

namespace CurrencyCalculatorServer.Presentation.Infrastructure.Mappings
{
    /// <summary>
    /// Mappring profile for Currency
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class CurrencyProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyProfile"/> class.
        /// </summary>
        public CurrencyProfile()
        {
            CreateMap<CurrencyModel, Currency>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Cur_ID))
                .ForMember(x => x.Code, y => y.MapFrom(z => z.Cur_Code))
                .ForMember(x => x.Abbreviation, y => y.MapFrom(z => z.Cur_Abbreviation))
                .ForMember(x => x.DateStart, y => y.MapFrom(z => z.Cur_DateStart))
                .ForMember(x => x.DateEnd, y => y.MapFrom(z => z.Cur_DateEnd))
                .ForMember(x => x.Rates, y => y.Ignore());
        }
    }
}
