using System;
using System.Collections.Generic;

namespace GameServices
{
	public class Path
	{
		private PositionHandler ph;

		public Path (int w, int h)			// A komponens felhasználásához más kompnens csak ezt az osztályt használhatja.
		{
			ph = new PositionHandler ();
			ph.Initialize (w, h);

			while (true)
			{
				try {
					
					ph.Spawn ();
					ph.UpdatePositions = Motion (ph.GetPositions);
				} 

				catch(Exception e) {
					// Loggolunk.
				}
				System.Threading.Thread.Sleep (100);		

			}
		}
			

		private List<Position> Motion(List<Position> ps)		// Pontok mozgatása két jelenet között. 
		{
			// todo: algoritmus kidolgozására és implementációjára vár.
		}
	}
}

