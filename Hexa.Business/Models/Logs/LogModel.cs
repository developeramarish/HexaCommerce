using Hexa.Business.Models.Shared;

namespace Hexa.Business.Models.Logs
{
    public class LogModel : BaseModel
    {
        public string ShortMessage { get; set; }

        public string FullMessage { get; set; }

        public string IpAddress { get; set; }

        public int? CustomerId { get; set; }

        public string PageUrl { get; set; }

        public string PageReferrer { get; set; }
    }
}
