using System;

namespace EnemyPath
{
	public class Resolution
	{
		public void DimCheck(int w, int h) 	// Használható rajzfelület kijelölése.
		{
			string supported = "SupportedResolutions.txt";
			string path = System.IO.Path.Combine (Environment.CurrentDirectory, supported);

			string[] resolutions = System.IO.File.ReadAllLines (path);
			foreach(string r in resolutions)
			{
				string[] resolution = r.Split ('x');
				if((Convert.ToInt32(resolution[0]) * Convert.ToInt32(resolution[1])) == (w * h))
				{
					return;
				}
			}

			throw new Exception("The provided resolution is not supported.");
		}
	}
}

