using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;

namespace GovernmentData.Models
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);

            List<AwardRecipient> dataList = GetDataFromJson();

            context.AwardRecipients.AddRange(dataList);
            context.SaveChanges();
        }

        private List<AwardRecipient> GetDataFromJson()
        {
            string json;

            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("https://inventory.data.gov/api/3/action/datastore_search?resource_id=d22a4624-ce58-42d7-8739-9457efc60921");
            }

            JObject jsonObject = JsonConvert.DeserializeObject<JObject>(json);
            JArray jsonArray = (JArray)jsonObject["result"]["records"];

            List<AwardRecipient> dataList = jsonArray.ToObject<List<AwardRecipient>>();

            return dataList;
        }
    }
}