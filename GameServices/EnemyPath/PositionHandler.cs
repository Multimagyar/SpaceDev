using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnemyPath
{	
	public class PositionHandler : IPosition		
	{
		private List<Position> positions;

		private static int id = 0;
		private const int limit = 50;
		private int width, height;
	

		public PositionHandler (int w, int h)	
		{
			positions = new List<Position> ();		
			Resolution s = new Resolution ();	

			s.DimCheck (w, h);
			width = w;
			height = h;
		}

		public void Spawn ()				// Új kezdőpontok létrehozása az alapvonalon.
		{
			if(positions.Count < limit) 
			{
				Position p = new Position ();

				p.x = newX ();
				p.y = height;
				p.id = ++id;
				GenerateAttribute (p);

				positions.Add (p);
			}

			else {
				throw new Exception("Spawn limit reached.");
			}
		}

		public int newX()
		{
			Random rnd = new Random ();
			int x = rnd.Next (20, width - 20);		// Kijelöl egy kezdőpontot a kezdővonalon.
			return x;
		}

		public void Dispose (int id)	// Adott pont törlése a rajzterületről.
		{
			foreach (Position p in positions)
			{
				if (p.id == id) 
				{
					positions.Remove (p);
					Spawn ();
					return;
				}
			}

			throw new Exception ("The given id does not exists.");

		}

		public string GetPositions ()	// Objektum szerializálás JSON sztringbe.
		{
			return JsonConvert.SerializeObject (positions.ToArray ());
		}
			

		public void UpdateAttribute (int id = -1)		// Sebesség, részhossz, szög.
		{
			foreach (Position p in positions) 
			{
				if (id >= 0) { // Egy pont tulajdonságait frissíti.
					GenerateAttribute (p);
					return;
				}

				else if (id == -1) {
					GenerateAttribute (p);	// Az összesét.
				}

				else {
					throw new Exception ("The given id does not exists.");
				}
			}
		}

		private static void GenerateAttribute (Position p) {
			Random rnd = new Random ();
			p.angle = rnd.Next (45, 135);		
			p.waypoint = rnd.Next (37, 264);	// ~ 1 & 7 cm közötti
		}

		public void Motion()		// Pontok mozgatása két jelenet között. 
		{
			foreach (Position p in positions) 
			{
				if (p.waypoint == p.y) {
					UpdateAttribute (p.id); 
				}

				p.x -= (int) Math.Cos (p.angle) * p.waypoint;  	// xn = xn-1 + Cos(szög), yn = yn-1 + Sin(szög)
				p.y -= (int) Math.Sin (p.angle) * p.waypoint;

				if (p.y < 0)
					Dispose (p.id);			// Kiért a rajzterületről.
			}
		}
			
	}
}

