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
                Console.WriteLine("  aa.exeのバージョンが2.0.5887.34699のzipファイル名 aa_2_0_160213.zip (日付は5887を変換している。)");
				Thread.Sleep(12000);
				return;
			}

			var argFileName = Path.GetFullPath(args[0]);
			var targetDir = Path.GetDirectoryName(argFileName);
			var zipFile = GenerateFileName(argFileName) + ".zip";


			Console.WriteLine(string.Format("引数\t{0}", argFileName));
			Console.WriteLine(string.Format("圧縮対象Dir\t{0}", targetDir));
			Console.WriteLine(string.Format("Zipファイル名\t{0}", zipFile));

            if (File.Exists(zipFile))
            {
                File.Delete(zipFile);
                Console.WriteLine("同名のZipファイルが存在していたため削除しました。");
            }

			ZipReduced.ZipCompress(targetDir, zipFile);

			Thread.Sleep(12000);
		}

		/// <summary>
		/// アセンブリ情報からzipファイル名を生成する。
		/// </summary>
		internal static string GenerateFileName(string appName)
		{
			var fullPath = Path.GetFullPath(appName);
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("指定されたファイルが見つかりません。（" + fullPath + "）");
            }

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
