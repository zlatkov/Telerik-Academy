using System;
using System.Collections.Generic;
using System.Linq;

public class DocumentSystem
{
    static List<IDocument> documents = new List<IDocument>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    public static void AddDocument(IDocument newDocument, string[] attributes)
    {
        foreach (var attribute in attributes)
        {
            string[] parts = attribute.Split('=');
            newDocument.LoadProperty(parts[0], parts[1]);
        }
        if (newDocument.Name == null)
        {
            Console.WriteLine("Document has no name");
        }
        else
        {
            Console.WriteLine("Document added: " + newDocument.Name);
            documents.Add(newDocument);
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        AddDocument(new TextDocument(), attributes);
    }


    private static void AddPdfDocument(string[] attributes)
    {
        AddDocument(new PDFDocument(), attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        AddDocument(new WordDocument(), attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AddDocument(new ExcelDocument(), attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AddDocument(new AudioDocument(), attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AddDocument(new VideoDocument(), attributes);
    }

    private static void ListDocuments()
    {
        if (documents.Count > 0)
        {
            foreach (var document in documents)
            {
                Console.WriteLine(document.ToString());
            }
        }
        else
        {
            Console.WriteLine("No documents found");
        }
    }

    private static void EncryptDocument(string name)
    {
        bool documentFound = false;
        foreach (var document in documents)
        {
            if (document.Name == name)
            {
                documentFound = true;

                IEncryptable encryptableDocument = document as IEncryptable;
                if (encryptableDocument != null)
                {
                    encryptableDocument.Encrypt();
                    Console.WriteLine("Document encrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: " + name);
                }
            }
        }
        if (!documentFound)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool documentFound = false;
        foreach (var document in documents)
        {
            if (document.Name == name)
            {
                documentFound = true;

                IEncryptable encryptableDocument = document as IEncryptable;
                if (encryptableDocument != null)
                {
                    encryptableDocument.Decrypt();
                    Console.WriteLine("Document decrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: " + name);
                }
            }
        }
        if (!documentFound)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool documentEncrypted = false;
        foreach (var document in documents)
        {
            IEncryptable encryptableDocument = document as IEncryptable;
            if (encryptableDocument != null)
            {
                documentEncrypted = true;
                encryptableDocument.Encrypt();
            }
        }

        if (documentEncrypted)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool documentFound = false;
        foreach (var document in documents)
        {
            if (document.Name == name)
            {
                documentFound = true;

                IEditable editableDocument = document as IEditable;
                if (editableDocument != null)
                {
                    editableDocument.ChangeContent(content);
                    Console.WriteLine("Document content changed: " + name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: " + name);
                }
            }
        }

        if (!documentFound)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }
}
