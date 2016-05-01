using System.Text;
using Ionic.Zip;

namespace packageProduct
{
	public static class ZipReduced
	{
		private const string ShiftJis = "shift_jis";

		/// <summary>
		/// 指定したフォルダのファイルでzipファイルを作る。
		/// </summary>
		/// <param name="targetDir">圧縮するフォルダ</param>
		/// <param name="zipFileName">作成するzipファイル名</param>
		public static void ZipCompress(string targetDir, string zipFileName)
		{
			using (var zip = new Ionic.Zip.ZipFile())
			{
				//IBM437でエンコードできないファイル名やコメントをshift_jisでエンコード
				zip.AlternateEncoding = Encoding.GetEncoding(ShiftJis);	//Windowsエクスプローラでの解凍でファイル名が文字化けするのでShift-JIS固定にする。
				//zip.AlternateEncoding = Encoding.UTF8;
				zip.AlternateEncodingUsage = Ionic.Zip.ZipOption.Always;

				zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
				zip.UseZip64WhenSaving = Ionic.Zip.Zip64Option.AsNecessary;		//必要な時はZIP64で圧縮する。デフォルトはNever。
				zip.ZipErrorAction = ZipErrorAction.Throw;						//エラー発生時は例外をスロー。
				
				var dir = System.IO.Path.GetFullPath(targetDir);
				zip.AddDirectory(dir);
				zip.Save(zipFileName);
			}
		}

		/// <summary>
		/// Zipファイルを解凍する。
		/// </summary>
		/// <param name="zipFile">Zipファイルのパス</param>
		/// <param name="extractDir">解凍先ディレクトリ</param>
		public static void ZipExtract(string zipFile, string extractDir)
		{
			var options = new ReadOptions();
			options.Encoding = Encoding.GetEncoding(ShiftJis);

			using (var zip = ZipFile.Read(zipFile, options))
			{
				zip.ExtractAll(extractDir, ExtractExistingFileAction.Throw);
			}
		}


	}
}
