using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace Foundation.Editor
{
	public class Packages
	{
		#region Methods
		public static async Task LoadNewManifest(string id, string user = "DaveVanVerdegem")
		{
			string url = GetGistUrl(id, user);
			string contents = await GetContents(url);
			ReplacePackagesFile(contents);
		}

		static string GetGistUrl(string gistId, string user = "DaveVanVerdegem")
		{
			return $"https://gist.githubusercontent.com/{user}/{gistId}/raw/";
		}

		static async Task<string> GetContents(string url)
		{
			using HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync(url);
			string content = await response.Content.ReadAsStringAsync();

			return content;
		}

		static void ReplacePackagesFile(string contents)
		{
			string existing = Path.Combine(Application.dataPath, "../Packages/manifest.json");
			File.WriteAllText(existing, contents);
			UnityEditor.PackageManager.Client.Resolve();
		}
		#endregion
	}
}
