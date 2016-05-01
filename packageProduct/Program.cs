using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace packageProduct
{
	internal class Program
	{
		internal static void Main(string[] args)
		{
			if (args.Length ==0)
			{
				Console.WriteLine("引数に圧縮対象のモジュールのパスを指定してください。");
				Console.WriteLine("  packageProduct bin\\aa.exe");
				Console.WriteLine("  aa.exeが2016/1/2のタイムスタンプでver3.4.5.6の出力例：aa_3_4_160102.zip");
				Thread.Sleep(12000);
				return;
			}

			var argFileName = args[0];
			var targetDir = Path.GetDirectoryName(argFileName);
			var zipFile = GenerateFileName(argFileName) + ".zip";

			if (File.Exists(zipFile))
			{
				File.Delete(zipFile);
			}

			Console.WriteLine(string.Format("引数\t{0}", argFileName));
			Console.WriteLine(string.Format("圧縮対象Dir\t{0}", targetDir));
			Console.WriteLine(string.Format("Zipファイル名\t{0}", zipFile));

			ZipReduced.ZipCompress(targetDir, zipFile);

			Thread.Sleep(12000);
		}

		/// <summary>
		/// アセンブリ情報からzipファイル名を生成する。
		/// </summary>
		internal static string GenerateFileName(string appName)
		{
			var fullPath = Path.GetFullPath(appName);
			var assembly = Assembly.LoadFile(fullPath);
			var assemblyName = assembly.GetName();
			var version = assemblyName.Version;
			var simpleName = assemblyName.Name;

			var day = new DateTime(2000, 1, 1);
			day = day.AddDays(version.Build);
			return simpleName + "_" + version.Major + "_" + version.Minor + "_" + day.ToString("yyMMdd");
		}



	}
}
