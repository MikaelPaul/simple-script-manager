using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SSM
{
	public class JsonHelper
	{

		public JsonHelper()
		{

		}

		public static bool FileExists(string path)
		{
			return (!string.IsNullOrWhiteSpace(path) && File.Exists(path));
		}

		public static void CreateConfigFile(string target, string filename)
		{
			// Error handling
			if (string.IsNullOrWhiteSpace(target))
				throw new ArgumentNullException("Target directory cannot be empty");
			if (string.IsNullOrWhiteSpace(filename))
				throw new ArgumentNullException("Filename cannot be empty");
			if (!Directory.Exists(target))
				throw new DirectoryNotFoundException($"The following directory does not exist: {target}");

			// Get the config file
			string[] files = Directory.GetFiles(IOHelper.GetApplicationRoot(), filename);

			// Copy the files and overwrite destination files if they already exist
			foreach (string s in files)
			{
				var destPath = Path.Combine(target, Path.GetFileName(s));
				File.Copy(s, destPath, true);
			}
		}
		
		public static StreamReader GetStreamReader(string path)
		{
			return File.OpenText(path);
		}

		public static void Serialize(object value, Stream s)
		{
			using (StreamWriter writer = new StreamWriter(s))
			using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
			{
				JsonSerializer ser = new JsonSerializer();
				ser.Serialize(jsonWriter, value);
				jsonWriter.Flush();
			}
		}

		public static T Deserialize<T>(Stream s)
		{
			using (StreamReader reader = new StreamReader(s))
			using (JsonTextReader jsonReader = new JsonTextReader(reader))
			{
				JsonSerializer ser = new JsonSerializer();
				return ser.Deserialize<T>(jsonReader);
			}
		}

	}
}
