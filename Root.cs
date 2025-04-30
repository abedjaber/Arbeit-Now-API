using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
    {
    public class Datum
        {
        public string slug { get; set; }
        public string company_name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool remote { get; set; }
        public string url { get; set; }
        public List<string> tags { get; set; }
        public List<string> job_types { get; set; }
        public string location { get; set; }
        public int created_at { get; set; }
        public DateTime created_at_date { get; set; }

        }

    public class Links
        {
        public string first { get; set; }
        public object last { get; set; }
        public object prev { get; set; }
        public string next { get; set; }
        }

    public class Meta
        {
        public int current_page { get; set; }
        public int from { get; set; }
        public string path { get; set; }
        public int per_page { get; set; }
        public int to { get; set; }
        public string terms { get; set; }
        public string info { get; set; }
        }

    public class Root
        {
        public List<Datum> data { get; set; }
        public Links links { get; set; }
        public Meta meta { get; set; }
        }


    }
