using System;

namespace GameServices
{
	public class Spawner
	{
		private static int width, height, range;

		public static void Dimensions(int w, int h) 	// Használható rajzfelület kijelölése.
		{
			width = w;
			height = h;
		}

		public static void Range(int h) 	// A kezdővonal ahol a pontok létrejöhetnek.
		{
			range = h;
		}

		public static int spawnX()
		{
			Random rnd = new Random ();
			int x = rnd.Next (20, width - 20);		// Kijelöl egy kezdőpontot a kezdővonalon.

			return x;
		}

		public static int getX () {
			return width;
		}

		public static int getY () {
			return height;
		}
	}
}

