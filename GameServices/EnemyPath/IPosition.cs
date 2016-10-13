using System;

namespace GameServices
{
	public interface IPosition
	{
		void Spawn();							// Pontok létrehozása.

		void Dispose (int id);					// Pontok törlése.

		string GetPositions ();					// Pontok lekérése.

		void UpdatePositions(System.Collections.Generic.List<Position> pos); 	// Pontok frissítése.
	}
}

