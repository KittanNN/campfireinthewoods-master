#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class MagickBox : MonoBehaviour {

    

    [CanEditMultipleObjects]
    [MenuItem("MagickBox/Texture2Sprite")]
    static void Texture2Sprite()
    {
        Object[] temp = Selection.objects;
        foreach (Object item in temp)
        {
            Texture2D asd = item as Texture2D;
            string path = AssetDatabase.GetAssetPath(asd);
            TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
            ti.textureType = TextureImporterType.Sprite;
            ti.filterMode = FilterMode.Point;
            ti.SaveAndReimport();
        }
    }

    [CanEditMultipleObjects]
    [MenuItem("MagickBox/Texture2Point")]
    static void Texture2Point()
    {
        Object[] temp = Selection.objects;
        foreach (Object item in temp)
        {
            Texture2D asd = item as Texture2D;
            string path = AssetDatabase.GetAssetPath(asd);
            TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
            ti.filterMode = FilterMode.Point;
            ti.SaveAndReimport();
        }
    }

    [CanEditMultipleObjects]
    [MenuItem("MagickBox/Texture2Bilinear")]
    static void Texture2Bilinear()
    {
        Object[] temp = Selection.objects;
        foreach (Object item in temp)
        {
            Texture2D asd = item as Texture2D;
            string path = AssetDatabase.GetAssetPath(asd);
            TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
            ti.filterMode = FilterMode.Bilinear;
            ti.SaveAndReimport();
        }
    }

    [CanEditMultipleObjects]
    [MenuItem("MagickBox/SelectParent %w")]
    static void SelectParent()
    {

        Selection.activeGameObject = Selection.activeGameObject.transform.parent.gameObject;
    }

    [CanEditMultipleObjects]
    [MenuItem("MagickBox/ActiveToggle %a")]
    static void ActiveToggle()
    {
        bool active = Selection.activeGameObject.activeSelf;



        Selection.activeGameObject.SetActive(!active);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
#endif