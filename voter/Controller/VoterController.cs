using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voter.Controller
{
    class VoterController
    {
        public string vote(string url)
        {

            Request re = new Request(url, "127.0.0.1", 1080);

            string response = Http.CreateGetHttpResponse(re);

            return response;
                
        }
    }
}
