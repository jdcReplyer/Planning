using Common.Constants;
using Microsoft.Extensions.Configuration;

namespace Planning.DataAccess.Http.Client
{

    public  class Client
    {
    
        static HttpClient client = new HttpClient();
        public Client(IConfiguration config)
        {
            client.BaseAddress = new Uri(config["VolumePredictionBaseUrl"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add(LayerWatersConstants.SD_LOGISTIC_TRUCK_VOLUM_PREDICTION_HEADER_KEY, config["VolumePredictionApiKey"]);

        }
        public static void Initialize(IConfiguration config)
        {
            client.BaseAddress = new Uri(config["VolumePredictionBaseUrl"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add(LayerWatersConstants.SD_LOGISTIC_TRUCK_VOLUM_PREDICTION_HEADER_KEY, config["VolumePredictionApiKey"]);
        }
        public static HttpClient GetClient()
        {
            return client;
        }
    }
}
