using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MS_Learn_Scoreboard.Controllers
{
    public class MicrosoftLearnUtil
    {
        public static int GetXP(string username) 
        {
            using (WebClient webClient = new WebClient()) {
                string userInfoString = webClient.DownloadString("https://docs.microsoft.com/api/profiles/" + username);
                dynamic userInfo = JsonConvert.DeserializeObject<dynamic>(userInfoString);
                string userId = userInfo.userId;

                string userStatusString = webClient.DownloadString("https://docs.microsoft.com/api/gamestatus/" + userId);
                dynamic userStatus = JsonConvert.DeserializeObject<dynamic>(userStatusString);
                string totalPoints = userStatus.totalPoints;

                int totalPointsInt = int.Parse(totalPoints);
                return totalPointsInt;
            }
        }
    }
}
