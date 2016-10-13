using System;
using System.Collections.Generic;

namespace GameServices
{
	public class Path
	{
		private PositionHandler ph;

		public Path(int width, int height) {
			ph = new PositionHandler (width, height);
		}


		public string GetPath (int w, int h)			// A vezérlő ezt a  metódust hívja. JSon string-et ad vissza.
		{
			ph.UpdatePositions(Motion(ph.GetPositions));
			ph.GetPositions ();
		}
			

		private List<Position> Motion(List<Position> ps)		// Pontok mozgatása két jelenet között. 
		{
			foreach (Position p in ps) 
			{
				if (p.waypoint == p.y) {
					ph.UpdateAttributes (p.id); 
				}

				p.x -= Math.Cos (p.angle) * p.waypoint;  	// xn = xn-1 + Cos(szög), yn = yn-1 + Sin(szög)
				p.y -= Math.Sin (p.angle) * p.waypoint;

				if (p.y < 0)
					ph.Dispose (p.id);			// Kiért a rajzterületről.
			}
		}
	}
}

