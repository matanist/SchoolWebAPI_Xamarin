using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XamarinTutorial1WebApi.Models
{
	public class WebAPIService
	{
		private HttpClient _client;
		Uri uri = new Uri(@"http://192.168.1.24/SchoolDBWebAPI/api/student");
		public WebAPIService()
		{
			_client = new HttpClient();
		}
		public async Task<ObservableCollection<Student>> GetData()
		{

			var items = new ObservableCollection<Student>();

			var response = await _client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				items = JsonConvert.DeserializeObject<ObservableCollection<Student>>(content);
			}
			return items;

		}
		public async Task<string> AddStudentAsync(Student student)
		{

			var json = JsonConvert.SerializeObject(student);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			HttpResponseMessage response = null;
			response = await _client.PostAsync(uri, content);
			if (response.IsSuccessStatusCode)
			{

				return "Success";
			}
			return "Fail";

		}
		public async Task UpdateStudentAsync(Student student)
		{
			var json = JsonConvert.SerializeObject(student);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _client.PutAsync(uri, content);

		}
		public async Task DeleteStudentAsync(int id)
		{
			var json = JsonConvert.SerializeObject(id);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _client.DeleteAsync(uri + "/" + id);
		}
	}

}
