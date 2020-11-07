using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    /// <summary>
    /// IPollution Interface to declare service methods   
    /// </summary>
    public interface IPollution
    {
        PollutionResponse GetPollutionByGeographic(PollutionRequest pollutionRequest);
        
    }
}
