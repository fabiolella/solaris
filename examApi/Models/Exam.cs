using System.Collections.Generic;
namespace examApi.Models
{
    public class Exam
    {
        public long Id { get; set; }
        public string professor { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string location { get; set; }
        public string date { get; set; }
        public string deadLineSubscription { get; set; }
        public string type { get; set; }
    }
}