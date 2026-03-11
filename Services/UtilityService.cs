using IPOApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IPOApi.Models.UtilityModel;


namespace IPOApi.STADataAccess
{
	public class UtilityService
	{
		public static DataTable getJobStatusList(JobStatusList objobstatus, headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				UtilityData objutility = new UtilityData();
				ds = objutility.jobstatusData(objobstatus, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable getJobtypeList(headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				UtilityData objutility = new UtilityData();
				ds = objutility.jobtypeData(headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}


		public (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory, string y)
		{
			string jobid = y;
			int filelength = jobid.Length;
			var zipName = $"archive-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";
			var files = Directory.GetFiles(subDirectory).ToList();
			string supportedExtensions = String.Concat(jobid.ToString(), ".csv,", jobid.ToString(), "_*.*");

			List<string> myList = new List<string>();

			foreach (string file in Directory.GetFiles(subDirectory, String.Concat(jobid, ".*"), SearchOption.AllDirectories).Union(
									Directory.GetFiles(subDirectory, String.Concat(jobid, "_*.*"), SearchOption.AllDirectories)))
			{

				var fil = Path.GetFileName(file);
				string filess = file;
				myList.Add(filess);

			}


			using (var memoryStream = new MemoryStream())
			{
				using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
				{
					myList.ForEach(file =>
					{
						var filename = Path.GetFileName(file);
						//var theFile = archive.CreateEntry(file);
						var theFile = archive.CreateEntry(filename);

						// var res= theFile.Name;

						using (var streamWriter = new StreamWriter(theFile.Open()))
						{
							streamWriter.Write(File.ReadAllText(file));
						}
						// }

					});
				}
				return ("application/zip", memoryStream.ToArray(), zipName);
			}

		}

		public static DataTable objJobCompletedservice(JobCompleted objJobCompleted, headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				UtilityData objutility = new UtilityData();
				ds = objutility.objJobCompletedData(objJobCompleted, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		//jobinpogressservice

		public static DataTable jobinpogressservice(JobCompleted objJobCompleted, headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				UtilityData objutility = new UtilityData();
				ds = objutility.jobinpogressData(objJobCompleted, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
        public static DataTable jobinQueueservice(JobCompleted objJobCompleted, headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                UtilityData objutility = new UtilityData();
                ds = objutility.jobinQueueData(objJobCompleted, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
        public static DataTable SuspendKoQueueService(KoQueued objkoQueued, headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                UtilityData objutility = new UtilityData();
                ds = objutility.SuspendKoQueueData(objkoQueued, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}
