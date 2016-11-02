using System;
using EnemyPath;
using NUnit.Framework;

namespace EnemyPath.Test
{
	[TestFixture]
	public class PathTest
	{
		
		[Test]											// Komponens teszt.
		public void GetPath_GeneralTest_NoException()
		{
			Path p = new Path (800, 600);

			int frames = 0;		// 10 másodperces teszt -> @60 fps -> 600 frame
			string output = string.Empty;
			System.IO.StreamWriter file = new System.IO.StreamWriter (Environment.CurrentDirectory + "/json.txt");

			while (frames < 600)
			{
				output += p.GetPath () + '\n';
				frames++;
			}

			file.Write (output);

			Assert.AreEqual ("probe", output);
		}
	}

}

