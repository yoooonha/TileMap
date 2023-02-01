using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public class CsvController : MonoBehaviour
{
    public List<stHeroData> lstHero = new List<stHeroData>();
   
    // Start is called before the first frame update
    void Start()
    {
        //ReadFile();
        //WriteFile();
       
    
    }

    void WriteFile()
    {
        string fileName = "saveFile" + DateTime.Now.ToString("yyMMddHHmmss") + ".csv";

        string delimiter = ",";
        List<string[]> lists = new List<string[]>();

        string[] datas = new string[] { "Name", "Time", "Stage", "Exp" };
        lists.Add(datas);
        string[] value1 = new string[] { "p1", DateTime.Now.ToString(), "15", "54534" };
        lists.Add(value1);
        string[] value2 = new string[] { "p2", DateTime.Now.ToString(), "5", "544" };
        lists.Add(value2);

        string[][] outPuts = lists.ToArray();

        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < outPuts.Length; i++)
        {
            sb.AppendLine(string.Join(delimiter, outPuts[i]));
        }

        string filePath = Application.dataPath + "/Resources/Datas/" + fileName;

        using (StreamWriter outStream = File.CreateText(filePath))
        {
            outStream.Write(sb);
        }
    }

    void ReadFile()
    {
        string path = Application.dataPath + "/Resources/Datas/Source.csv";
        if(File.Exists(path))
        {
            string source;
            using (StreamReader sr = new StreamReader(path))
            {
                string[] lines;
                source = sr.ReadToEnd();
                lines = Regex.Split(source, @"\r\n|\n\r|\n|\r");
                string[] header = Regex.Split(lines[0], ",");
                for(int i = 1; i < lines.Length; i++)
                {
                    string[] values = Regex.Split(lines[i], ",");
                    if (values.Length == 0 || string.IsNullOrEmpty(values[0])) continue;

                    stHeroData tempData = new stHeroData();
                    tempData.INDEX = int.Parse(values[0]);
                    tempData.NAME = values[1];
                    tempData.EXP = int.Parse(values[2]);
                    tempData.LEVEL =int.Parse(values[3]);
                    tempData.MOVESPEED = float.Parse(values[4]);
                    tempData.ATTACKPOWER = int.Parse(values[5]);

                    lstHero.Add(tempData);
                }
            }
        }

        foreach(stHeroData data in lstHero)
        {
            Debug.Log(data.NAME + ", " + data.LEVEL);
        }
    }
}


public struct stHeroData
{
    public int INDEX;
    public string NAME;
    public int EXP;
    public int LEVEL;
    public float MOVESPEED;
    public int ATTACKPOWER;
}


public struct stskillData
{
    public int INDEX;
    public int LV;
    public int DMG;
    public int BULLET;
    public float RANGE;

   
}