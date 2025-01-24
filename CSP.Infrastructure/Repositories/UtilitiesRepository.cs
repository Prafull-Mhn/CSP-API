using CSP.Application.Responses.Utilities;
using CSP.Shared.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using CSP.Application.Interfaces;
using System.Data.SqlClient;

namespace CSP.Infrastructure.Repositories
{
    public class UtilitiesRepository :IUtilitiesRepository
    {
       // private readonly DatabaseConnection _dbConnection;
       // private readonly ThirdPartyEndpoints _endpoints;
        private readonly string _insertAPILogSP; 
        private readonly string _apiLink;
        private  string _endPointName, _endpoint;
        //string _endpoints = 

        private readonly SqlConnection _connection;

        public UtilitiesRepository( IConfiguration configuration) //:  base(dbConnection)
        {
            //_dbConnection = dbConnection;
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            _apiLink = configuration["ThirdPartyEndpoints:APILink"];
            _insertAPILogSP = configuration["StoredProcedures:InsertAPILog"];
        }

        

        public async Task<HLRCheckResponse> HLRCheckAsync(long number, string type, CancellationToken cancellationToken)
        {
            var payload = new { number, type };
            _endPointName = "recharge/hlrapi/hlrcheck";
            _endpoint = _apiLink + _endPointName;
            var requestBody = JsonSerializer.Serialize(payload);

            // Make the third-party API call
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, _endpoint);
            request.Content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");
            // request.Headers.Add("Authorization", $"Bearer {_endpoints.ApiKey}");

            string token = Token.GenerateToken();
            request.Headers.Add("accept", "application/json");
            request.Headers.Add("Token", token);
            request.Headers.Add("Authorisedkey", "ODRlMmIzNThhZDAyNmUyMzYzZGE5NDI5MzZjNGRmZGY=");

            var response = await client.SendAsync(request, cancellationToken);
            var responseBody = await response.Content.ReadAsStringAsync();

            //// Log the request and response
            //await _dbConnection.ExecuteStoredProcedureAsync("LogAPICall",
            //    new
            //    {
            //        APIName = "HLRCheck",
            //        Request = requestBody,
            //        Response = responseBody,
            //        Status = response.IsSuccessStatusCode ? "Success" : "Failed"
            //    });

        //    using var connection = CreateConnection();
            await _connection.ExecuteAsync(_insertAPILogSP, new
            {
                TenantID = 1,
                APIName = _endPointName,
                Request = requestBody,
                Response = responseBody,
                Endpoint = _endpoint,
                ResponseCode = response.StatusCode,
                Status = response.IsSuccessStatusCode ? "Success" : "Failed",
                CreatedBy = "System"
            }, commandType: CommandType.StoredProcedure);

            return JsonSerializer.Deserialize<HLRCheckResponse>(responseBody);
        }

        public async Task<DTHInfoResponse> DTHInfoAsync(long canumber, string op, CancellationToken cancellationToken)
        {
            var payload = new { canumber, op };
            _endPointName = "recharge/hlrapi/dthinfo";
            _endpoint = _apiLink + _endPointName;
            var requestBody = JsonSerializer.Serialize(payload);

            // Make the third-party API call
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, _endpoint);
            request.Content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");
            // request.Headers.Add("Authorization", $"Bearer {_endpoints.ApiKey}");

            string token = Token.GenerateToken();
            request.Headers.Add("accept", "application/json");
            request.Headers.Add("Token", token);
            request.Headers.Add("Authorisedkey", "ODRlMmIzNThhZDAyNmUyMzYzZGE5NDI5MzZjNGRmZGY=");

            var response = await client.SendAsync(request, cancellationToken);
            var responseBody = await response.Content.ReadAsStringAsync();

            //// Log the request and response
            //await _dbConnection.ExecuteStoredProcedureAsync("LogAPICall",
            //    new
            //    {
            //        APIName = "HLRCheck",
            //        Request = requestBody,
            //        Response = responseBody,
            //        Status = response.IsSuccessStatusCode ? "Success" : "Failed"
            //    });

            //    using var connection = CreateConnection();
            await _connection.ExecuteAsync(_insertAPILogSP, new
            {
                TenantID = 1,
                APIName = _endPointName,
                Request = requestBody,
                Response = responseBody,
                Endpoint = _endpoint,
                ResponseCode = response.StatusCode,
                Status = response.IsSuccessStatusCode ? "Success" : "Failed",
                CreatedBy = "System"
            }, commandType: CommandType.StoredProcedure);

            return JsonSerializer.Deserialize<DTHInfoResponse>(responseBody);
        }



    }
}
