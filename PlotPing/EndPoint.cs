using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlotPing
{
    class EndPoint
    {

        public EndPoint(string hostOrIp, string comment)
        {
            HostOrIp = hostOrIp;
            Comment = comment;
        }

        public EndPoint(string hostOrIp)
        {
            HostOrIp = hostOrIp;
        }

        string hostOrIp;

        public string HostOrIp
        {
            get { return hostOrIp; }
            set { hostOrIp = value; }
        }

        string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(comment))
            {
                return hostOrIp;
            }
            else
            {
                return hostOrIp + " " + comment;
            }
        }

    }

}
