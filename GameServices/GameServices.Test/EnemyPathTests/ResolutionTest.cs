using System;
using NUnit.Framework;
using EnemyPath;

namespace EnemyPath.Test
{
	[TestFixture]
	public class ResolutionTest
	{
		private Resolution s = null;

		[SetUp]
		public void SetUp()
		{
			s = new Resolution ();
		}
			
		[Test]	
		[ExpectedException(typeof(Exception), ExpectedMessage = "The provided resolution is not supported.")]
		public void DimCheck_NonSupportedResolution_ThrowsException()
		{
			s.DimCheck(8343, 3443);			
		}

		[TearDown]
		public void TearDown()
		{
			s = null;
		}
			
		
	}
}

