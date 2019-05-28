using ZESoft.Common.Models;

namespace IEX.Net
{
    public class DataRange : TypeSafeEnum
    {
        public string IEXRangeString { get; }
        public DataRange(int value, string name, string iexRangeString) : base(value, name)
        {
            IEXRangeString = iexRangeString;
        }

        public static DataRange FiveYears = new DataRange(DataRanges.Five_Years, nameof(DataRanges.Five_Years), "5y");
        public static DataRange TwoYears = new DataRange(DataRanges.Two_Years, nameof(DataRanges.Two_Years), "2y");
        public static DataRange OneYear = new DataRange(DataRanges.One_Year, nameof(DataRanges.One_Year), "1y");
        public static DataRange YearToDate = new DataRange(DataRanges.Year_to_Date, nameof(DataRanges.Year_to_Date), "ytd");
        public static DataRange SixMonths = new DataRange(DataRanges.Six_Months, nameof(DataRanges.Six_Months), "6m");
        public static DataRange ThreeMonths = new DataRange(DataRanges.Three_Months, nameof(DataRanges.Three_Months), "3m");
        public static DataRange OneMonth = new DataRange(DataRanges.One_Month, nameof(DataRanges.One_Month), "1m");
        public static DataRange Next = new DataRange(DataRanges.Next, nameof(DataRanges.Next), "next");


        /// <summary>
        /// Gets the IEX expected name of the data range.
        /// </summary>
        /// <returns>
        /// The <c>IEXRangeString</c> property value.
        /// </returns>
        public override string ToString()
        {
            return IEXRangeString;
        }

        public static class DataRanges
        {
            public const int Five_Years = 0;
            public const int Two_Years = 1;
            public const int One_Year = 2;
            public const int Year_to_Date = 3;
            public const int Six_Months = 4;
            public const int Three_Months = 5;
            public const int One_Month = 6;
            public const int @Next = 7;
        }
    }
}
