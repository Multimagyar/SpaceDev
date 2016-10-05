using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GameServices
{	
	public class PositionHandler : IPosition		
	{
		private List<Position> positions;
		private static int id = 0;

		private static int deletions = 0;	// Segédváltozók spawn-felügyelethez.
		private const int limit = 50;	
		 
	
		public void Initialize (int width, int height)	
		{
			positions = new List<Position> ();		

			Spawner.Dimensions (width, height);		
			Spawner.Range (height);
		}

		public void Spawn ()				// Új kezdőpontok létrehozása az alapvonalon.
		{
			if((limit + deletions) > 0) 
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
				if (p.id == id) {
					positions.Remove (p);

					--deletions;
					
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

	}
}

