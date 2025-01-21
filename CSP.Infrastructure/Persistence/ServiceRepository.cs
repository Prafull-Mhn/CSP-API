using CSP.Application.Common.Interfaces;
using CSP.Application.Services.Handlers;
using CSP.Domain.Entities;
using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CSP.Infrastructure.Persistence
{
    public class ServiceRepository : IServiceRepository
    {

        private readonly HttpClient _httpClient;
        public ServiceRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    
            public async Task<HLRList> PostHLRCheckAsync(Int64 number, string type, CancellationToken cancellationToken)
            {

            var request = new HttpRequestMessage(HttpMethod.Post, "https://sit.paysprint.in//service-api/api/v1/service/recharge/hlrapi/hlrcheck");

           // var client = new RestClient(options);
           // var request = new RestRequest("");
            string token = Token.GenerateToken();
            request.Headers.Add("accept", "application/json");
            request.Headers.Add("Token", token);
            request.Headers.Add("Authorisedkey", "ODRlMmIzNThhZDAyNmUyMzYzZGE5NDI5MzZjNGRmZGY=");

            // Add JSON body
            //var body = new { number, type };

            // Create the request payload
            var payload = new
            {
                number = number,
                type = type
            };

            // Serialize the payload to JSON
            //var content = new StringContent(
            //       JsonSerializer.Serialize(payload, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
            //    Encoding.UTF8,
            //    "application/json"
            //);

           // request.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
           // request.Content=
            
            var response = await _httpClient.SendAsync(request, cancellationToken);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Deserialize the response content
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<HLRList>(
                responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );


            request.AddJsonBody("\"{\\\"number\\\":\\\"" + number + ",\\\"type\\\":\\\"" + type + "\\\"}\"", false);
            //var response = await client.PostAsync(request);

            ////  var options = new RestClientOptions("https://sit.paysprint.in//service-api/api/v1/service/recharge/hlrapi/hlrcheck");
            //var client = new RestClient(options);
            //    var request = new RestRequest("");
            //      string token = Token.GenerateToken ();
            //    request.AddHeader("accept", "application/json");
            //    request.AddHeader("Token", token);
            //    request.AddHeader("Authorisedkey", "ODRlMmIzNThhZDAyNmUyMzYzZGE5NDI5MzZjNGRmZGY=");
            //    request.AddJsonBody("\"{\\\"number\\\":\\\"" + number + ",\\\"type\\\":\\\"" + type + "\\\"}\"", false);
            //    var response = await client.PostAsync(request);
            //    var obj = JsonConvert.DeserializeObject<HLRList>(response.Content);
            // List<HLRList> results = response.Content Re.ToList();
          //  return obj;
                //return await _connection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
            }
        
    }
}
