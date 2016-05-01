using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace packageProduct.Test
{

	[TestClass]
	public class ZipReducedTest
	{
		[TestMethod]
		public void ZipCompressTest()
		{
			var dir = Path.Combine(TestHelper.ResourcePath, "ZipCompressTest");
			const string ZipFile = "a.zip";
			ZipReduced.ZipCompress(dir, ZipFile);
			ZipReduced.ZipExtract(ZipFile, @".\ZipCompressTest");
			Assert.IsTrue(File.Exists(@".\ZipCompressTest\abc.txt"));
			Assert.IsTrue(File.Exists(@".\ZipCompressTest\あいう.txt"));
			Assert.IsTrue(File.Exists(@".\ZipCompressTest\えお\かきく.txt"));
		}
	}
}
