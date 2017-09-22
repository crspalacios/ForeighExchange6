

namespace ForeighExchange6.Interfaces
{ 
    using System.Globalization;

    public interface ILocalize
    {
        CultureInfo GetCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}
