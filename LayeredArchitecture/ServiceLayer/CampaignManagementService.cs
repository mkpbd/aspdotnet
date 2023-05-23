using BusnessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface CampaignManagementService
    {
        CampaignDetails CreateCampaign(CampaignDetails details);
        CampaignDetails Publish(long id, string schedule);
        CampaignDetails Deactivate(long id);
        CampaignDetails AddDisplayLocation(long id, string newLocation);
    }
}
