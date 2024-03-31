namespace AnimalsProject;

using System;
using System.IO;


public class FileOutput
{
    private StreamWriter outStream;
    private string fileName;

    public FileOutput(string fileName)
    {
        this.fileName = fileName;
        try
        {
            using (outStream = new StreamWriter(fileName));
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File Open Error: " + fileName + " " + e);
        }
    }

    public void FileWrite(string line)
    {
        try
        {
            outStream.WriteLine(line);
        }
        catch (Exception e)
        {
            Console.WriteLine("File Write Error: " + fileName + " " + e);
        }
    }

    public void FileClose()
    {
        if (outStream != null)
        {
            try
            {
                outStream.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("File Close Error: " + fileName + " " + e);
            }
        }
    }
}

