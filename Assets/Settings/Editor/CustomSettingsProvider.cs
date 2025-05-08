#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

/// <summary>
/// G�n�re le menu custom pour les param�tres.
/// </summary>
static class CustomSettingsProvider
{
    [SettingsProvider]
    public static SettingsProvider CreateCustomSettingsProvider()
    {

        var provider = new SettingsProvider("Project/ParametresFireball", SettingsScope.Project)
        {

            label = "Param�tres Fireball",
            guiHandler = (searchContext) =>
            {
                var settings = ParametresFireball.GetOrCreateSettings();
                settings.numeroBuild = EditorGUILayout.IntField("Num�ro du build officiel", settings.numeroBuild);
                settings.nomBuild = EditorGUILayout.TextField("Nom du ou des builds", settings.nomBuild);
                settings.dateDebutCopyright = EditorGUILayout.IntField("Date de cr�ation du jeu", settings.dateDebutCopyright);
                settings.dateFinCopyright = EditorGUILayout.IntField("Date de subsistance du jeu", settings.dateFinCopyright);

                if (GUI.changed)
                {
                    EditorUtility.SetDirty(settings);
                }
            },

            keywords = new System.Collections.Generic.HashSet<string>(new[] { "custom", "settings", "mycustom" })
        };

        return provider;
    }
}
#endif