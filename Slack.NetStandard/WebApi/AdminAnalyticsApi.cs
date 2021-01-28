﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Slack.NetStandard.WebApi
{
    internal class AdminAnalyticsApi : IAdminAnalyticsApi
    {
        private readonly IWebApiClient _client;
        public AdminAnalyticsApi(IWebApiClient client)
        {
            _client = client;
        }

        public Task<HttpResponseMessage> GetFile(string type, DateTime? date = null)
        {
            var dict = new Dictionary<string, string>
            {
                {"type", type}
            };
            if (date.HasValue)
            {
                dict.Add("date", date.Value.ToUniversalTime().ToString("yyyy-MM-dd"));
            }

            return _client.MakeRawUrlEncodedCall("admin.analytics.getFile", dict);
        }
    }
}