using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace packageProduct
{
	using System.IO;
	using System.Reflection;
	using System.Threading;

	class Program
	{
		static void Main(string[] args)
		{
			//var versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(args[0]);	//ファイルバージョンなら取得可能
				
			var targetDir = Path.GetDirectoryName(args[0]);
			var zipRootDir = GenerateFileName(args[0]);
			if (!Directory.Exists(targetDir))
			{
				Console.WriteLine(targetDir + "が見つかりません。");
			}

			var zipFile = Path.GetFullPath(zipRootDir) + ".zip";
			if (File.Exists(zipFile))
			{
				File.Delete(zipFile);
			}

			Console.WriteLine(string.Format("引数\t{0}", args[0]));
			Console.WriteLine(string.Format("圧縮対象Dir\t{0}", targetDir));
			Console.WriteLine(string.Format("Zipファイル内のルートフォルダ\t{0}", zipRootDir));
			Console.WriteLine(string.Format("Zipファイル名\t{0}", zipFile));

			ZipFileCreateFromDirector(targetDir, zipFile, zipRootDir);

			Thread.Sleep(12000);
		}

		/// <summary>
		/// アセンブリ情報からzipファイル名を生成する。
		/// </summary>
		static string GenerateFileName(string appName)
		{
			var fullPath = Path.GetFullPath(appName);
			var assembly = Assembly.LoadFile(fullPath);
			var assemblyName = assembly.GetName();
			var version = assemblyName.Version.ToString();
			var simpleName = assemblyName.Name;

			return simpleName + "_" + version;
		}


		public static void ZipFileCreateFromDirector(string targetDir, string zipFileName, string zipRootDir)
		{
			using (var zip = new Ionic.Zip.ZipFile())
			{
				//IBM437でエンコードできないファイル名やコメントをUTF-8でエンコード
				//zip.AlternateEncoding = Encoding.GetEncoding("shift_jis");
				zip.AlternateEncoding = Encoding.UTF8;
				zip.AlternateEncodingUsage = Ionic.Zip.ZipOption.Always;
    

				//圧縮レベルを変更
				zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;

				//必要な時はZIP64で圧縮する。デフォルトはNever。
				zip.UseZip64WhenSaving = Ionic.Zip.Zip64Option.AsNecessary;

				//エラー発生時は例外をスロー。
				zip.ZipErrorAction = Ionic.Zip.ZipErrorAction.Throw;

				//フォルダを追加する
				zip.AddDirectory(targetDir, zipRootDir);

				//ZIP書庫を作成する
				zip.Save(zipFileName);
			}
		}
	}
}
