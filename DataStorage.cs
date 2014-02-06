using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using Ionic.Zip;
using System.Diagnostics;

namespace TheraWii
{
    public class DataStorage
    {
        private DataModel dm;
        private XmlSerializer dm_serializer, therapy_serializer, profile_serializer;
        private string DATA_STORE_FILENAME = "dataModel.xml";
        private string DEMO_DS_FILE = "dataModel.xml";
        public static string DATA_STORE_FOLDER;

        public DataStorage()
        {
            dm_serializer = new XmlSerializer(typeof(DataModel));
            therapy_serializer = new XmlSerializer(typeof(Therapy));
            profile_serializer = new XmlSerializer(typeof(Profile));
			DATA_STORE_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TheraWii";
            DirectoryInfo di = new DirectoryInfo(DATA_STORE_FOLDER);
            if (!di.Exists)
            {
                di.Create();
            }
            DATA_STORE_FILENAME = Path.Combine(DATA_STORE_FOLDER, DATA_STORE_FILENAME);
            DEMO_DS_FILE = Path.Combine(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),"TheraWii"),
                DEMO_DS_FILE);
            
            DeserializeDataModel();
        }

        public DataModel DataModel
        {
            get { return dm; }
        }

        public void SerializeDataModel()
        {
            FileInfo f1 = new FileInfo(DATA_STORE_FILENAME);            
			FileInfo f2 = new FileInfo(DATA_STORE_FILENAME + ".old");            
			if (f2.Exists)                 
				f2.Delete();            
			if (f1.Exists)                
				f1.MoveTo(DATA_STORE_FILENAME + ".old");            
			TextWriter writer = new StreamWriter(DATA_STORE_FILENAME);
            try { dm_serializer.Serialize(writer, dm); }
            catch (Exception e)
            {
                writer.Close();
                FileInfo f3 = new FileInfo(DATA_STORE_FILENAME);
                f3.Delete();
                f1.MoveTo(DATA_STORE_FILENAME);
				string s = e.StackTrace;
                throw new InvalidOperationException("Error Serialzing DataModel - reverted to old xml");

            }
            if (writer != null)
                writer.Close();

         }

        public void SerializeTherapy(string filename, Therapy t)
        {
            TextWriter writer = new StreamWriter(filename);

            try
            {
                therapy_serializer.Serialize(writer, t);
            }
            catch (Exception e)
            {
                writer.Close();
                string s = e.StackTrace;
                throw new InvalidOperationException("Error Serialzing Therapy");
            }

            if (writer != null)
                writer.Close();
        }
        
        public void SerializeProfile(string filename, Profile p)
        {
            Stream stream = new MemoryStream();
            TextWriter writer = new StreamWriter(stream);

            try
            {
                profile_serializer.Serialize(writer, p);
            }
            catch (Exception e)
            {
                writer.Close();
                string s = e.StackTrace;
                throw new InvalidOperationException("Error Serialzing Profile");
            }

            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddEntry("profile.twp", stream);
                    zip.AddDirectory(p.GetDataFolder(), p.Name);
                    zip.Save(filename);
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error Exporting Profile: " + e.Message);
            }

            if (writer != null)
                writer.Close();
        }

        public void DeserializeDataModel()
        {
            FileInfo fi = new FileInfo(DATA_STORE_FILENAME);

            // Load demo dataStore.xml from Program folder
            if (!fi.Exists)
            {
                FileInfo demoFI = new FileInfo(DEMO_DS_FILE);
                if (demoFI.Exists)
                {
                    System.IO.File.Copy(DEMO_DS_FILE, DATA_STORE_FILENAME);
                }
                fi.Refresh();
            }

            if (fi.Exists)
            {
                TextReader reader = new StreamReader(DATA_STORE_FILENAME);
                try
                {
                    dm = (DataModel)dm_serializer.Deserialize(reader);
                }
                catch (Exception)
                {
                    string date = String.Format("{0:g}", DateTime.Now);
                    fi.MoveTo(DATA_STORE_FILENAME + ".fail.xml");
                    MessageBox.Show("Unable to Load Data.  Moving failed data file to: " + fi.FullName,
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dm = new DataModel();
                }
                finally
                {
                    reader.Close();
                }
            }
            else
            {
                dm = new DataModel();
            }
        }

        public void DeserializeTherapy(string filename, ref Therapy t)
        {
            FileInfo fi = new FileInfo(filename);

            if (fi.Exists)
            {
                TextReader reader = new StreamReader(filename);
                try
                {
                    t = (Therapy)therapy_serializer.Deserialize(reader);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Invalid File Format");
                }
                finally
                {
                    reader.Close();
                }
            }
            else
            {
                throw new FileNotFoundException("Could not locate file: " + filename);
            }
        }

        public void DeserializeProfile(string filename, ref Profile p)
        {
            FileInfo fi = new FileInfo(filename);

            if (fi.Exists)
            {
                using (ZipFile zip = ZipFile.Read(filename))
                {
                    string profFile = "profile.twp";

                    foreach (string fileInZip in zip.EntryFileNames)
                    {
                        if (fileInZip.Equals(profFile, StringComparison.InvariantCultureIgnoreCase))
                        {
                            Debug.WriteLine("Found profile file in ZIP archive. Extracting it now");

                            zip[fileInZip].Extract(profFile);
                            profFile = Path.Combine(DATA_STORE_FOLDER, profFile);
                            TextReader reader = new StreamReader(profFile);

                            try
                            {
                                p = (Profile)profile_serializer.Deserialize(reader);
                            }
                            catch (Exception)
                            {
                                throw new InvalidOperationException("Invalid File Format");
                            }
                            finally
                            {
                                reader.Close();
                            }

                            if (dm.isProfileNameUnique(p.Name) && !Directory.Exists(p.GetDataFolder()))
                            {
                                zip.ExtractAll(DATA_STORE_FOLDER, ExtractExistingFileAction.OverwriteSilently);
                            }
                            else
                            {
                                throw new InvalidOperationException("There is already an existing profile named "
                                    + p.Name + ".  Delete or rename it before importing.");
                            }

                            File.Delete(profFile);
                        }
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("Could not locate file: " + filename);
            }
        }        
    }
}

