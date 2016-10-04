using System;

namespace GameServices
{
	public interface IPosition
	{
		void Initialize (int width, int height); // Komponens inicializáló.

		void Spawn();							// Pontok létrehozása.

		void Dispose (int id);					// Pontok törlése.

		string GetPositions ();					// Pontok lekéréséhez.
	}
}

