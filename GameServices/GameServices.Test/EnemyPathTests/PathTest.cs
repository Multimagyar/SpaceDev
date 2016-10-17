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
				file.WriteLine (p.GetPath() + '\n');
				frames++;
			}

			Assert.AreEqual ("probe", output);
		} 

		[Test]
		public void Motion_GeneralTest_NoException()
		{
			// todo...
		}

		[Test]
		public void Dispose_ValidIdNumber_IsTrue()
		{
			// todo...
		}	
	}

}

