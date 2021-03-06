﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace packageProduct.Test
{
	[TestClass]
	public class ProgramTest
	{
		[TestMethod]
		public void GenerateFileNameTest()
		{
			var file = Path.Combine(TestHelper.ResourcePath, "GenerateFileNameTest");
			file = Path.Combine(file, "relayCredentials.dll");

			var actual = Program.GenerateFileName(file);
			Assert.AreEqual("relayCredentials_2_0_160213", actual);
		}

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GenerateFileName_指定されたファイルが存在しない時に例外を出力する()
        {
            var actual = Program.GenerateFileName("notFound.exe");
        }

    }
}
