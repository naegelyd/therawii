using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace TheraWii
{
    public class Session
    {
		public string dataFile, profile, therapy;
		public DateTime createDate;
        public List<TaskData> TaskDatas;

		private DScsv csvOut;

        public Session()
        {
            TaskDatas = new List<TaskData>();
        }

        public void Initialize(Profile p, Therapy t)
        {
			therapy = t.ToString();
            profile = p.Name;
            createDate = System.DateTime.Now;
            string date = createDate.Year + "-" 
                        + createDate.Month + "-"
                        + createDate.Day + " "
                        + createDate.Hour + "-"
                        + createDate.Minute +
						+ createDate.Second;

            dataFile = profile  + "_" + therapy + "_" + date + ".csv";
            csvOut = new DScsv();
            createFile();
        }

        public void Finish()
        {
            // finish writing
            csvOut.closeFile();
        }

        public DScsv GetCSV()
        {
            return csvOut;
        }

        public void createFile()
        {
            csvOut.Initialize((Session)this);
            //csvOut.closeFile();
        }

        public String[] getSubItems()
        {
            String[] subItems = new String[] {createDate.ToString(), therapy.ToString()};
            return subItems;
        }

        public void delete()
        {
            string fullPath = GetDataFilePath();
            if (System.IO.File.Exists(fullPath))
				System.IO.File.Delete(fullPath);
        }

        public string GetDataFilePath()
        {
            return Path.Combine(
                    Path.Combine(DataStorage.DATA_STORE_FOLDER, profile),
                    dataFile);
        }
    }
}