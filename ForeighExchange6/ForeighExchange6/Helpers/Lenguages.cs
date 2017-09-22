

namespace ForeighExchange6.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using Resources;
    public static class Lenguages
    {
      static Lenguages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }
        public static string Accept
        {
            get { return Resource.Accept; }
        }
        public static string AmountLabel
        {
            get { return Resource.AmountLabel; }
        }

        public static string AmountNumericValidation
        {
            get { return Resource.AmountNumericValidation; }
        }

        public static string AmountPlaceHolde
        {
            get { return Resource.AmountPlaceHolder; }
        }

        public static string AAmountValidation
        {
            get { return Resource.AmountValidation; }
        }

        public static string Convert
        {
            get { return Resource.Convert; }
        }
        public static string Error
        {
            get { return Resource.Error; }
        }
        public static string Loading
        {
            get { return Resource.Loading; }
        }
        public static string Ready
        {
            get { return Resource.Ready; }
        }
        public static string ASourceRateLabel
        {
            get { return Resource.SourceRateLabel; }
        }
        public static string SourceRateLabel
        {
            get { return Resource.SourceRateLabel; }
        }
        public static string SourceRateTarget
        {
            get { return Resource.SourceRateTarget; }
        }
        public static string SourceRateTitle
        {
            get { return Resource.SourceRateTitle; }
        }
        public static string SourceRateValidation
        {
            get { return Resource.SourceRateValidation; }
        }
        public static string TargetRateTitle
        {
            get { return Resource.TargetRateTitle; }
        }
        public static string TargetRateValidation
        {
            get { return Resource.TargetRateValidation; }
        }
        public static string Title
        {
            get { return Resource.Title; }
        }


    }
}
