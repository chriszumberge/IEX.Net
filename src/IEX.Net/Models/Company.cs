using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace IEX.Net
{
    public class Company : ObservableObject
    {
        string _symbol;
        [JsonProperty("symbol")]
        public string Symbol
        {
            get { return _symbol; }
            set { SetProperty(ref _symbol, value); }
        }

        string _companyName;
        [JsonProperty("companyName")]
        public string CompanyName
        {
            get { return _companyName; }
            set { SetProperty(ref _companyName, value); }
        }

        string _exchange;
        [JsonProperty("exchange")]
        public string Exchange
        {
            get { return _exchange; }
            set { SetProperty(ref _exchange, value); }
        }

        string _industry;
        [JsonProperty("industry")]
        public string Industry {
            get { return _industry; }
            set { SetProperty(ref _industry, value); }
        }

        Uri _website;
        [JsonProperty("website")]
        public Uri Website {
            get { return _website; }
            set { SetProperty(ref _website, value); }
        }

        string _description;
        [JsonProperty("description")]
        public string Description {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        string _ceo;
        [JsonProperty("CEO")]
        public string Ceo {
            get { return _ceo; }
            set { SetProperty(ref _ceo, value); }
        }

        string _securityName;
        [JsonProperty("securityName")]
        public string SecurityName {
            get { return _securityName; }
            set { SetProperty(ref _securityName, value); }
        }

        string _issueType;
        [JsonProperty("issueType")]
        public string IssueType {
            get { return _issueType; }
            set { SetProperty(ref _issueType, value); }
        }

        string _sector;
        [JsonProperty("sector")]
        public string Sector {
            get { return _sector; }
            set { SetProperty(ref _sector, value); }
        }

        long _employees;
        [JsonProperty("employees")]
        public long Employees {
            get { return _employees; }
            set { SetProperty(ref _employees, value); }
        }

        ObservableCollection<string> _tags = new ObservableCollection<string>();
        [JsonProperty("tags")]
        public ObservableCollection<string> Tags {
            get { return _tags; }
            set { SetProperty(ref _tags, value); }
        }

        public static Company FromJson(string json) => JsonConvert.DeserializeObject<Company>(json, Converter.Settings);
    }
}
