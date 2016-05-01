using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace packageProduct.Test
{
	public class TestHelper
	{
		/// <summary>
		/// TestResourceフォルダのパス
		/// </summary>
		public static string ResourcePath
		{
			get
			{
				var dir = System.IO.Path.GetFullPath(@"..\..\..\packageProduct.Test\TestResource");
				return dir;
			}
		}
	}
}
