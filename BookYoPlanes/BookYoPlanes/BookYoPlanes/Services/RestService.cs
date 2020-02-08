using BookYoPlanes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookYoPlanes.Services
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Plane>> GetPlanes(string uri)
        {
            List<Plane> data = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<Plane>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return data;
        }
        public async Task<List<Booking>> GetBookings(string uri)
        {
            List<Booking> data = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<Booking>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return data;
        }
        public async Task Post(string queryString)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(queryString);

            try
            {
                HttpResponseMessage response = await client.PostAsync(queryString, null);
                var result = await response.Content.ReadAsStringAsync();
            }
            catch (Exception er)
            {
                Console.WriteLine(er);
            }
        }
    }
}
