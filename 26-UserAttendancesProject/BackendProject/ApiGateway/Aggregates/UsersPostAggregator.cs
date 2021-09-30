using ApiGateway.Aggregates.UserAggregates;
using ApiGateway.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiGateway.Aggregates
{
    public class UsersPostAggregator : IDefinedAggregator
    {
        private readonly ILogger<UsersPostAggregator> _logger;

        public UsersPostAggregator(ILogger<UsersPostAggregator> logger)
        {
            _logger = logger;
        }

        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            _logger.LogInformation($"La respuesta: {responses.Count}");
            var userResponseContent = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var postResponseContent = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserAggregator>(userResponseContent);
            var attendances = JsonConvert.DeserializeObject<List<Attendance>>(postResponseContent);
            user.attendances.AddRange(attendances);

            if(user.nickname is not null)
            {
                var userAttendancesString = JsonConvert.SerializeObject(user);

                var stringContent = new StringContent(userAttendancesString)
                {
                    Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                };
                return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
            } 
            else
            {
                var stringContent = new StringContent("")
                {
                    Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                };
                return new DownstreamResponse(stringContent, HttpStatusCode.NotFound, new List<KeyValuePair<string, IEnumerable<string>>>(), "Not Found");
            }
            

        }
    }
}
