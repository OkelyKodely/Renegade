using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class Serializer
{
    private const string mysoldier = "soldier.xml";

    private const string antagonists = "antagonists.xml";

    public void Serialize(Soldier soldier, AList list)
    {
        var writer1 = new XmlSerializer(typeof(Soldier));
        
        var writer2 = new XmlSerializer(typeof(AList));

        var file1 = new StreamWriter(mysoldier);

        var file2 = new StreamWriter(antagonists);

        writer1.Serialize(file1, soldier);

        writer2.Serialize(file2, list);

        file1.Close();

        file2.Close();
    }

    public Soldier DeserializeSoldier()
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Soldier));

            StreamReader reader = new StreamReader(mysoldier);

            Soldier obj = (Soldier)serializer.Deserialize(reader);

            reader.Close();

            return obj;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public AList DeserializeAList()
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AList));

            StreamReader reader = new StreamReader(antagonists);

            AList openedList = (AList)serializer.Deserialize(reader);

            reader.Close();

            return openedList;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}