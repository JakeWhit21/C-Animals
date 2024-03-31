namespace AnimalsProject;

using System;
using System.IO;

public class FileInput
{
    private StreamReader inStream;
    private string fileName;

    public FileInput(string fileName)
    {
        this.fileName = fileName;
        try
        {
            using (inStream = new StreamReader(fileName));
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File Open Error: " + fileName + " " + e);
        }
    }

    public void FileRead()
    {
        string line;
        try
        {
            while ((line = inStream.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("File Read Error: " + fileName + " " + e);
        }
    }

    public string FileReadLine()
    {
        try
        {
            string line = inStream.ReadLine();
            return line;
        }
        catch (Exception e)
        {
            Console.WriteLine("File Read Error: " + fileName + " " + e);
            return null;
        }
    }

    public void FileClose()
    {
        if (inStream != null)
        {
            try
            {
                inStream.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("File Close Error: " + fileName + " " + e);
            }
        }
    }
}

