using UnityEngine;

/// <summary>
/// Paramètres supplémentaires pour le jeu.
/// </summary>
[CreateAssetMenu(fileName = "ParametresFireball", menuName = "Settings/Paramètres Fireball")]
public class ParametresFireball : ScriptableObject
{

    public int numeroBuild;
    public string nomBuild;

    public string dateCopyright;

#if UNITY_EDITOR
    private const string k_SettingsPath = "Assets/Settings/ParametresFireball.asset";

    public static ParametresFireball GetOrCreateSettings()
    {
        var settings = UnityEditor.AssetDatabase.LoadAssetAtPath<ParametresFireball>(k_SettingsPath);
        if (settings == null)
        {
            settings = ScriptableObject.CreateInstance<ParametresFireball>();
            UnityEditor.AssetDatabase.CreateAsset(settings, k_SettingsPath);
            UnityEditor.AssetDatabase.SaveAssets();
        }
        return settings;
    }
#endif
}