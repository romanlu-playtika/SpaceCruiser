using System.IO;
using UnityEditor;
using UnityEngine;

public class AudioPostProcessing : AssetPostprocessor
{
    void OnPreprocessAudio()
    {
        var settings = new AudioImporterSampleSettings();
        var fileSize = new FileInfo(assetPath).Length / 1024;
        if (fileSize <= 200)
        {
            Debug.Log($"file size is {fileSize} kb, loadtype settings: {settings.loadType}");
            settings.loadType = AudioClipLoadType.DecompressOnLoad;
        }
        else if (fileSize < 5000)
        {
            settings.loadType = AudioClipLoadType.CompressedInMemory;
            Debug.Log($"file size is {fileSize} kb, loadtype settings: {settings.loadType}");
        }
        else
        {
            settings.loadType = AudioClipLoadType.Streaming;
            Debug.Log($"file size is {fileSize} kb, loadtype settings: {settings.loadType}");
        }
    }
}