﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MS_Learn_Scoreboard.Controllers
{
    public class MicrosoftLearnUtil
    {
        public static string GetUserId(string username)
        {
            using (WebClient webClient = new WebClient())
            {
                string userInfoString = webClient.DownloadString("https://docs.microsoft.com/api/profiles/" + username);
                dynamic userInfo = JsonConvert.DeserializeObject<dynamic>(userInfoString);
                return userInfo.userId;
            }
        }

        public static int GetXP(string userId) 
        {
            using (WebClient webClient = new WebClient()) {
                string userStatusString = webClient.DownloadString("https://docs.microsoft.com/api/gamestatus/" + userId);
                dynamic userStatus = JsonConvert.DeserializeObject<dynamic>(userStatusString);
                string totalPoints = userStatus.totalPoints;

                int totalPointsInt = int.Parse(totalPoints);
                return totalPointsInt;
            }
        }
    }
}
