using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using ZESoft.Mvvm.Models;

namespace IEX.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ZESoft.Mvvm.Models.ObservableObject" />
    public class Company : ObservableObject
    {
        string _symbol;
        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>
        /// Refers to the stock ticker.
        /// </value>
        [JsonProperty("symbol")]
        public string Symbol
        {
            get { return _symbol; }
            set { SetProperty(ref _symbol, value); }
        }

        string _companyName;
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// Refers to the name of the company.
        /// </value>
        [JsonProperty("companyName")]
        public string CompanyName
        {
            get { return _companyName; }
            set { SetProperty(ref _companyName, value); }
        }

        string _exchange;
        /// <summary>
        /// Gets or sets the exchange.
        /// </summary>
        /// <value>
        /// Refers to the exchange that the company is traded on.
        /// </value>
        [JsonProperty("exchange")]
        public string Exchange
        {
            get { return _exchange; }
            set { SetProperty(ref _exchange, value); }
        }

        string _industry;
        /// <summary>
        /// Gets or sets the industry.
        /// </summary>
        /// <value>
        /// The industry.
        /// </value>
        [JsonProperty("industry")]
        public string Industry
        {
            get { return _industry; }
            set { SetProperty(ref _industry, value); }
        }

        Uri _website;
        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        [JsonProperty("website")]
        public Uri Website
        {
            get { return _website; }
            set { SetProperty(ref _website, value); }
        }

        string _description;
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        string _ceo;
        /// <summary>
        /// Gets or sets the ceo.
        /// </summary>
        /// <value>
        /// The ceo.
        /// </value>
        [JsonProperty("CEO")]
        public string Ceo
        {
            get { return _ceo; }
            set { SetProperty(ref _ceo, value); }
        }

        string _securityName;
        /// <summary>
        /// Gets or sets the name of the security.
        /// </summary>
        /// <value>
        /// The name of the security.
        /// </value>
        [JsonProperty("securityName")]
        public string SecurityName
        {
            get { return _securityName; }
            set { SetProperty(ref _securityName, value); }
        }

        string _issueType;
        /// <summary>
        /// Gets or sets the type of the issue.
        /// </summary>
        /// <value>
        /// refers to the common issue type of the stock. 
        ///ad – American Depository Receipt(ADR’s)
        ///re – Real Estate Investment Trust(REIT’s)
        ///ce – Closed end fund(Stock and Bond Fund)
        ///si – Secondary Issue
        ///lp – Limited Partnerships
        ///cs – Common Stock
        ///et – Exchange Traded Fund(ETF)
        ///(blank) = Not Available, i.e., Warrant, Note, or(non-filing) Closed Ended Funds
        /// </value>
        [JsonProperty("issueType")]
        public string IssueType
        {
            get { return _issueType; }
            set { SetProperty(ref _issueType, value); }
        }

        string _sector;
        /// <summary>
        /// Gets or sets the sector.
        /// </summary>
        /// <value>
        /// The sector.
        /// </value>
        [JsonProperty("sector")]
        public string Sector
        {
            get { return _sector; }
            set { SetProperty(ref _sector, value); }
        }

        long _employees;
        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        /// <value>
        /// The number of employees.
        /// </value>
        [JsonProperty("employees")]
        public long Employees
        {
            get { return _employees; }
            set { SetProperty(ref _employees, value); }
        }

        ObservableCollection<string> _tags = new ObservableCollection<string>();
        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// A collection of strings used to classify the company.
        /// </value>
        [JsonProperty("tags")]
        public ObservableCollection<string> Tags
        {
            get { return _tags; }
            set { SetProperty(ref _tags, value); }
        }

        /// <summary>
        /// Creates a <c>Company</c> object from a json string.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns>Deserialized <c>Company</c> object.</returns>
        public static Company FromJson(string json) => JsonConvert.DeserializeObject<Company>(json, Converter.Settings);
    }
}
