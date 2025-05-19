using UnityEngine;
using UnityEditor;

public class BatchTextureCompressor : EditorWindow
{
    [MenuItem("Tools/Compress All Textures")]
    public static void CompressTextures()
    {
        string[] textureGuids = AssetDatabase.FindAssets("t:Texture");

        foreach (string guid in textureGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;

            if (importer != null)
            {
                importer.textureCompression = TextureImporterCompression.CompressedHQ;
                importer.crunchedCompression = true;
                importer.compressionQuality = 50;
                importer.maxTextureSize = 512;
                importer.SaveAndReimport();
            }
        }

        Debug.Log("✅ All textures compressed with Crunch.");
    }
}