using UnityEditor;
using UnityEngine;

/// <summary>
/// Paramètres supplémentaires pour le jeu.
/// </summary>
public class ParametresFireball : ScriptableObject
{

    public int numeroBuild;
    public string nomBuild;

    public int dateDebutCopyright;
    public int dateFinCopyright;

    private const string k_MyCustomSettingsPath = "Assets/Settings/ParametresFireball.asset";

    public static ParametresFireball GetOrCreateSettings()
    {
        var settings = AssetDatabase.LoadAssetAtPath<ParametresFireball>(k_MyCustomSettingsPath);
        if (settings == null)
        {
            settings = ScriptableObject.CreateInstance<ParametresFireball>();
            AssetDatabase.CreateAsset(settings, k_MyCustomSettingsPath);
            AssetDatabase.SaveAssets();
        }
        return settings;
    }
}
