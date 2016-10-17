using System;

namespace EnemyPath
{
	public interface IPosition
	{
		void Spawn();							// Pontok létrehozása.

		void Dispose (int id);					// Pontok törlése.

		string GetPositions ();					// Pontok lekérése.
	}
}

