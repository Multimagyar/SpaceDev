using System;

namespace GameServices
{

	// Ez az osztály a pontok leírásához szükséges adatokat írja le.

	public class Position 			
	{
		public int id { get; set; }
		public int x { get; set; }
		public int y { get; set; }
		public int angle { get; set; }
		public int waypoint { get; set; }
	}
}

