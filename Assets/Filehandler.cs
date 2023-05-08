using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using static NativeFilePicker;

public class FileHandler : MonoBehaviour
{
    string[] fileTypes = new string[] { "image/*", "application/pdf" };
    public string currentFileLocation = "";
    public bool isAndroid = false;


    void Start()
    {

    }


    public void UploadFileToStorage()
    {
        // Don't attempt to import/export files if the file picker is already open
        if (NativeFilePicker.IsFilePickerBusy())
            return;

        // Pick a file
        NativeFilePicker.Permission permission = NativeFilePicker.PickFile((pathToFile) =>
        {
            if (pathToFile == null)
                Debug.Log("Operation cancelled");
            else
                Debug.Log("Picked file: " + pathToFile);
            string fileExtension = Path.GetExtension(pathToFile);
            string fileName = Path.GetFileName(pathToFile);
            Debug.Log("extension is: " + fileExtension);
            Debug.Log("Can we export files?: " + NativeFilePicker.CanExportFiles());

            // Copy chosen file to persistent data path with incremental number
            Debug.Log("Printing persistent data path: " + Application.persistentDataPath);

            string pathToUploadedFile = Application.persistentDataPath + "/" + fileName;
            File.Copy(pathToFile, pathToUploadedFile, true);
            currentFileLocation = pathToUploadedFile;
            //Application.ExternalEval($"window.open({pathToFile})");

            string fullPath = "file:///" + currentFileLocation;
            print("Full path with three slashes is: " + fullPath);

            if (isAndroid == true)
            {
                print("IN IF IS ANDROID TRUE");
                AndroidContentOpenerWrapper.OpenContent(pathToFile);
            }
            else
            {
                print("IN ELSE IS ANDROID FALSE");

                Application.OpenURL(pathToFile);
            }

        }, fileTypes);


       
        Debug.Log("Permission result: " + permission);
    }
}


