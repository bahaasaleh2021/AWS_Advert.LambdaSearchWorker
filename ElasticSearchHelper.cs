using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.LambdaSearchWorker
{
    public class ElasticSearchHelper
    {
        
        private static IElasticClient _Client;
        public static IElasticClient Instance
        {
            get
            {
                if (_Client == null)
                {
                    var url = "https://search-advertapisearch-cmotn4nkzcdgjh7n7lco7zgnfa.us-east-2.es.amazonaws.com/";
                    var settings = new ConnectionSettings(new Uri(url)).DefaultIndex("adverts")
                        .DefaultMappingFor<AdvertType>(m=>m.IdProperty(x=>x.Id));

                    _Client = new ElasticClient(settings);
                }

                return _Client;
               
            }
        }
    }
}
