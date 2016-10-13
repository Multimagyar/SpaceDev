using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GameServices
{	
	public class PositionHandler : IPosition		
	{
		private List<Position> positions;

		private static int id = 0;
		private const int limit = 50;		 
	
		public PositionHandler (int width, int height)	
		{
			positions = new List<Position> ();		

			Spawner.Dimensions (width, height);		
			Spawner.Range (height);
		}

		public void Spawn ()				// Új kezdőpontok létrehozása az alapvonalon.
		{
			if(positions.Count < limit) 
			{
				Position p = new Position ();

				p.x = Spawner.spawnX ();
				p.y = Spawner.getY ();
				p.id = ++id;

				positions.Add (p);
			}

			else {
				throw new Exception("Spawn limit reached.");
			}
		}

		public void Dispose (int id)	// Adott pont törlése a rajzterületről.
		{
			foreach (Position p in positions)
			{
				if (p.id == id) 
				{
					positions.Remove (p);					
					return;
				}
			}
		}

		public string GetPositions ()	// Objektum szerializálás JSON sztringbe.
		{
			return JsonConvert.SerializeObject (positions.ToArray ());
		}

		public void UpdatePositions (List<Position> p)
		{
			this.positions = p;
		}

		public void UpdateAttributes (int id = -1)		// Sebesség, részhossz, szög.
		{
			Random rnd = new Random ();

			foreach (Position p in positions) 
			{
				if (id != -1) { // Adott id mozgási tulajdonságainak frissítése.
					GenerateAttributes(p);
					return;
				}

				else {
					GenerateAttributes (p);
				}					
			}
		}

		private static void GenerateAttributes (Position p) {
			p.angle = rnd.Next (45, 135);		
			p.waypoint = rnd.Next (37, 264);	// ~ 1 & 7 cm közötti
		}
			
	}
}

