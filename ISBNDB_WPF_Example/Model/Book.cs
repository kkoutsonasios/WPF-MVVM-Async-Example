using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;

namespace ISBNDB_WPF_Example.Model
{
    public class Book : BaseModel
    {
        public Book()
        {
            this.Title = string.Empty;
            this.TitleLong = string.Empty;
            this.AuthorsText = string.Empty;
            this.PublisherText = string.Empty;
            this.ISBN = "ISBN to look up";
            this.LoadingISBN = false;
        }

        private string _ISBN;
        public string ISBN { get { return _ISBN; } set { _ISBN = value; RaisePropertyChangedEvent("ISBN"); } }

        private string _title;
        public string Title { get { return _title; } set { _title = value; RaisePropertyChangedEvent("Title"); } }

        private string _titleLong;
        public string TitleLong { get { return _titleLong; } set { _titleLong = value; RaisePropertyChangedEvent("TitleLong"); } }

        private string _authorsText;
        public string AuthorsText { get { return _authorsText; } set { _authorsText = value; RaisePropertyChangedEvent("AuthorsText"); } }

        private string _publisherText;
        public string PublisherText { get { return _publisherText; } set { _publisherText = value; RaisePropertyChangedEvent("PublisherText"); } }

        private bool _loadingISBN;
        public bool LoadingISBN { get { return _loadingISBN; } set { _loadingISBN = value; RaisePropertyChangedEvent("LoadingISBN"); } }



        public void GetDataFromISBN()
        {
            LoadingISBN = true;
            string URLPath = string.Format("http://isbndb.com/api/books.xml?access_key=VOHXWVXM&index1=isbn&value1={0}", ISBN);
            WebRequest request = WebRequest.Create(URLPath);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            ParseXML(responseFromServer);
            LoadingISBN = false;
        }

        private void ParseXML(string XMLString)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(XMLString);

            XmlNodeList Title = xmlDoc.GetElementsByTagName("Title");
            XmlNodeList TitleLong = xmlDoc.GetElementsByTagName("TitleLong");
            XmlNodeList AuthorsText = xmlDoc.GetElementsByTagName("AuthorsText");
            XmlNodeList PublisherText = xmlDoc.GetElementsByTagName("PublisherText");

            
            this.Title = Title.Count > 0 ? Title[0].InnerText: string.Empty;
            this.TitleLong = TitleLong.Count > 0 ? TitleLong[0].InnerText: string.Empty;
            this.AuthorsText = AuthorsText.Count > 0 ? AuthorsText[0].InnerText: string.Empty;
            this.PublisherText = PublisherText.Count > 0 ? PublisherText[0].InnerText: string.Empty;        }
    }
}
