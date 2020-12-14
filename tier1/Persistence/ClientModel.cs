// using System.Collections.Generic;
// using System.Net.Http;
// using System.Text;
// using System.Text.Json;
// using System.Threading.Tasks;
// using Models;
//
// namespace tier1.Models
// {
//     public class ClientModel
//     {
//         
//         
//             public static ClientModel clientModel;
//             private ClientModel()
//             {}
//
//             public static ClientModel getInstance()
//             {
//                 if (clientModel == null)
//                 {
//                     clientModel = new ClientModel();
//                 }
//
//                 return clientModel;
//             }
//             public string GetAdultJson()
//             {
//                 Task<string> data = GetDataAsync();
//                 string result = data.GetAwaiter().GetResult();
//                 return result;
//             }
//             public void addAdult(Adult adult)
//             {
//                 PostData(adult);
//             }
//             static async Task<string> GetDataAsync()
//         {
//             HttpClient client = new HttpClient();
//             string s = await client.GetStringAsync("http://dnp.metamate.me/Adults");
//             return s;
//         }
//         static async Task<string> PostData(Adult adult)
//         {
//             HttpClient client = new HttpClient();
//             string adultSerialized = JsonSerializer.Serialize(adult);
//             StringContent content = new StringContent(
//                 adultSerialized,Encoding.UTF8,
//                 "application/json"
//                 );
//             HttpResponseMessage response = await client.PutAsync("http://dnp.metamate.me/Adults", content);
//             return response.ToString();
//         }
//         
//     }
// }