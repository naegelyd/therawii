using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;

/*
 * Methods should be called in the following order
 * DScsv() to create the object
 * Initialize(string, Profile, Session) to set new file
 * 
 * Repeat the following methods for each task
 * startTask(string) to name the task
 * addField(string) name each column 
 * writeHeader() write the header cols to the file
 * newRecord(DateTime) to set a new record time
 * setData(string fieldname,string data) to add a new piece of data
 * writeRecord() to write the record to file and clear record from memory
 * 
 * closeFile() to close the file when all tasks have been written to file for a given session
 */

namespace TheraWii
{
    public class DScsv
    {
        public Hashtable fieldData;
		public List<String> hashKeyOrder;
        public TimeSpan gameTime;
        public Session session;
        
        private StreamWriter sw;
        
        public DScsv()
        {            
        }

        public void Initialize(Session s)
        {
			session = s;
            gameTime = new TimeSpan();
            fieldData = new Hashtable();
            Initialize();
        }

        public void Initialize()
        {            
            sw = new StreamWriter(session.GetDataFilePath(), true);
            sw.WriteLine("#Profile:," + session.profile);
            sw.WriteLine("#Date:," + "{0:d}", session.createDate);
            sw.WriteLine("#Time:," + "{0:t}", session.createDate);
            sw.WriteLine("#Therapy:," + session.therapy);
        }

        //names new task
        public void startTask(Task t)
        {
            sw.WriteLine("#Task Name:," + t.Name);
            sw.WriteLine("#Task Type:," + t.GetType().ToString());
            fieldData.Clear();
        }

        //add field to hash map
        public void addField(string fieldName)
        {
			fieldData.Add(fieldName, "");
        }

        //write the header to file
        public void writeHeader()
        {
            sw.Write("#ActionTime,");  //this is populated independently from the hashtable
			hashKeyOrder = new List<String>();
			//sorting field names alphabetically - going to list is simplier than rolling own sort.
            foreach (string s in fieldData.Keys)
			{
				hashKeyOrder.Add(s);
            }
			hashKeyOrder.Sort((s1, s2) => string.Compare(s1, s2));

			//now we write the field names alphabetically
			foreach (string s in hashKeyOrder)
			{
				sw.Write(s + ",");
			}
            sw.WriteLine();
        }

        //new Record
        public void newRecord(TimeSpan gt)
        {
            this.gameTime += gt;
        }

        //set data in hash map
        public void setData(string field, string data)
        {
			if (fieldData.ContainsKey(field))
				fieldData[field] = data;
			else
				throw new KeyNotFoundException();
        }

        //write record and clear from hash map
        public void writeRecord()
        {
            sw.Write(gameTime + ",");
			for (int i = 0; i < hashKeyOrder.Count; i++)
            {
                sw.Write(fieldData[hashKeyOrder[i]] + ",");
				fieldData[hashKeyOrder[i]] = "";
            }
            sw.WriteLine();
        }

        //close file
        public void closeFile()
        {
            sw.Close();
        }

        public List<string[]> getData(string filename)
        {
            List<string[]> d = new List<string[]>();
            StreamReader sr = File.OpenText(filename);
            
            string input;
            while ((input = sr.ReadLine()) != null)
            {
                d.Add(input.Split(new char[1]{','}));
            }
			sr.Close();
            return d;

        }

        public static void exportSession(Session session, String saveFile)
        {
            File.Copy(session.GetDataFilePath(), saveFile);
        }

        public void delete(String file)
        {
            try
            {
                FileInfo f = new FileInfo(file);
                f.Delete();
            }
            catch (IOException)
            {
                
            }
        }

        public void WriteLine(String s)
        {
            sw.WriteLine(s);
        }
    }
}
