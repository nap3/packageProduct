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

        [TestMethod]
        public void ZipCompress_圧縮対象フォルダがpackageProductと同じフォルダの場合にzipファイルが作成されること()
        {
            ZipReduced.ZipCompress(Directory.GetCurrentDirectory(), "ZipCompress_curentDir.zip");
            Assert.IsTrue(File.Exists(@"ZipCompress_curentDir.zip"));
        }

	}
}
