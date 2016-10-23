using System;

namespace EnemyPath
{
	// Komponens felület.

	public class Path
	{
		private PositionHandler ph;

		public Path(int w, int h) 
		{
			ph = new PositionHandler (w, h);		
			ph.Spawn ();
		}


		public string GetPath ()			// Pontok létrehozása & mozgatása.
		{	
			ph.Motion ();
			return ph.GetPositions ();
		}

		public void Dispose(int id)			// Pontok törlése & újraspawnolása.
		{
			ph.Dispose (id);
		}
	}
}

