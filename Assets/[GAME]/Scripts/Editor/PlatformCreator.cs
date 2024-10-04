#if UNITY_EDITOR
using System.IO;
using _GAME_.Scripts.ScriptableObjects;
using UnityEditor;
using UnityEngine;

public class PlatformCreatorEditor : EditorWindow
{
    private PlatformScriptableObject platformDataTemplate;
    private GameObject platformPrefabTemplate;
    private string platformName = "Platform";

    private const string PlatformDataTemplateKey = "PlatformDataTemplate";
    private const string PlatformPrefabTemplateKey = "PlatformPrefabTemplate";
    private const string PlatformNameKey = "PlatformName";

    [MenuItem("Soundlight Interactive/Platform Creator")]
    public static void ShowWindow()
    {
        GetWindow<PlatformCreatorEditor>("Platform Creator");
    }

    private void OnEnable()
    {
        string platformDataPath = EditorPrefs.GetString(PlatformDataTemplateKey, "");
        if (!string.IsNullOrEmpty(platformDataPath))
        {
            platformDataTemplate = AssetDatabase.LoadAssetAtPath<PlatformScriptableObject>(platformDataPath);
        }

        string platformPrefabPath = EditorPrefs.GetString(PlatformPrefabTemplateKey, "");
        if (!string.IsNullOrEmpty(platformPrefabPath))
        {
            platformPrefabTemplate = AssetDatabase.LoadAssetAtPath<GameObject>(platformPrefabPath);
        }

        platformName = EditorPrefs.GetString(PlatformNameKey, "Platform");
    }

    private void OnDisable()
    {
        if (platformDataTemplate != null)
        {
            string platformDataPath = AssetDatabase.GetAssetPath(platformDataTemplate);
            EditorPrefs.SetString(PlatformDataTemplateKey, platformDataPath);
        }

        if (platformPrefabTemplate != null)
        {
            string platformPrefabPath = AssetDatabase.GetAssetPath(platformPrefabTemplate);
            EditorPrefs.SetString(PlatformPrefabTemplateKey, platformPrefabPath);
        }

        EditorPrefs.SetString(PlatformNameKey, platformName);
    }

    private void OnGUI()
    {
        GUILayout.Label("Platform Creator", EditorStyles.boldLabel);

        platformDataTemplate = (PlatformScriptableObject)EditorGUILayout.ObjectField("Platform Data Template", platformDataTemplate, typeof(PlatformScriptableObject), false);
        platformPrefabTemplate = (GameObject)EditorGUILayout.ObjectField("Platform Prefab Template", platformPrefabTemplate, typeof(GameObject), false);
        platformName = EditorGUILayout.TextField("Platform Name", platformName);

        if (GUILayout.Button("Create Platform"))
        {
            CreatePlatform();
        }
    }

    private void CreatePlatform()
    {
        if (platformDataTemplate == null || platformPrefabTemplate == null)
        {
            Debug.LogError("Platform Data Template or Platform Prefab Template is missing. Please assign both.");
            return;
        }

        if (string.IsNullOrEmpty(platformName))
        {
            Debug.LogError("Platform Name is missing. Please provide a name.");
            return;
        }

        string resourcesPath = "Assets/[GAME]/Resources/Platforms";

        if (!AssetDatabase.IsValidFolder(resourcesPath))
        {
            AssetDatabase.CreateFolder("Assets/[GAME]/Resources", "Platforms");
        }

        string[] existingDataAssets = Directory.GetFiles(resourcesPath, "*_Data.asset");
        int platformCount = existingDataAssets.Length;

        PlatformScriptableObject newPlatformData = Instantiate(platformDataTemplate);
        string dataPath = AssetDatabase.GenerateUniqueAssetPath($"{resourcesPath}/{platformName}_{platformCount + 1}_Data.asset");
        AssetDatabase.CreateAsset(newPlatformData, dataPath);

        GameObject newPlatformPrefab = PrefabUtility.InstantiatePrefab(platformPrefabTemplate) as GameObject;
        if (newPlatformPrefab != null)
        {
            string prefabPath = AssetDatabase.GenerateUniqueAssetPath($"{resourcesPath}/{platformName}_{platformCount + 1}.prefab");
            GameObject variantPrefab = PrefabUtility.SaveAsPrefabAsset(newPlatformPrefab, prefabPath);

            SerializedObject serializedPlatformData = new SerializedObject(newPlatformData);
            SerializedProperty platformDataProperty = serializedPlatformData.FindProperty("data");
            if (platformDataProperty != null)
            {
                SerializedProperty platformPrefabProperty = platformDataProperty.FindPropertyRelative("platformPrefab");
                if (platformPrefabProperty != null)
                {
                    platformPrefabProperty.objectReferenceValue = variantPrefab;
                    serializedPlatformData.ApplyModifiedProperties();
                }
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("Platform and data successfully created at Resources/Platforms");

            DestroyImmediate(newPlatformPrefab);
        }
        else
        {
            Debug.LogError("Failed to create platform variant.");
        }
    }
}
#endif