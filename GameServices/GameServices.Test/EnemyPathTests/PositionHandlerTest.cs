using System;
using System.Collections.Generic;
using EnemyPath;
using NUnit.Framework;
using Newtonsoft.Json;

namespace EnemyPath.Test
{
	[TestFixture]
	public class PositionHandlerTest
	{
		private PositionHandler ph = null;
		private List<Position> ps = null;

		[SetUp]
		public void SetUp()
		{
			ph = new PositionHandler (800, 600);
			ps = new List<Position> ();
		}

		[Test]
		[ExpectedException(typeof(Exception), ExpectedMessage = "Spawn limit reached.")]
		public void Spawn_OversizedSpawnNumber_ThrowsException()
		{
			while (true) {
				ph.Spawn ();
			}
		}

		[Test]
		[ExpectedException(typeof(Exception), ExpectedMessage = "The given id does not exists.")]
		public void Dispose_WrongIdNumber_ThrowsException()
		{
			ph.Dispose (-22);
		}

		[Test]
		public void GetPositions_JSonStringComparison_AreEqual()
		{
			
			Position p = new Position ();

			p.id = 14;
			p.x = 342;
			p.y = 599;
			p.angle = 102;
			p.waypoint = 26;

			string expected = "[{" +
				"\"id\":14," +
				"\"x\":342," +
				"\"y\":599," +
				"\"angle\":102," +
				"\"waypoint\":26" +
				"}]";

			ps.Add (p);
			string result = JsonConvert.SerializeObject (ps.ToArray ());

			Assert.AreEqual (expected, result);
		}

		[Test]
		[Ignore("This test is broken currently.")]
		public void UpdateAttribute_WrongIdNumber_ThrowsException()
		{
			ph.UpdateAttribute (1);		
		}


		[TearDown]
		public void TearDown()
		{
			ph = null;
			ps = null;
		}
	}
}

