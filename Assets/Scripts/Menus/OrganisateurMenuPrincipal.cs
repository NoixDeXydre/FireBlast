using TMPro;
using UnityEngine;

/// <summary>
/// Génère les informations correctes dans le menu principal.
/// </summary>
public class OrganisateurMenuPrincipal : MonoBehaviour
{

    private const string FormatAffichageBuildJeu = "Build {0} - {1}";
    private const string FormatAffichageVersionJeu = "Version {0} - Unity {1}";
    private const string FormatAffichageCopyright = "Fireball {0}, All rights reserved";

    /// <summary>
    /// Paramètres faisant office de métadonnées.
    /// </summary>
    public ParametresFireball metadonneesJeu;

    /// <summary>
    /// Numéro du build et le nom des versions.
    /// </summary>
    public TextMeshProUGUI buildJeu;

    /// <summary>
    /// Copyright
    /// </summary>
    public TextMeshProUGUI copyrightJeu;

    /// <summary>
    /// Version affichée du jeu.
    /// </summary>
    public TextMeshProUGUI versionJeu;

    /// <summary>
    /// Placement des données
    /// </summary>
    public void Start()
    {

        buildJeu.SetText(string.Format(FormatAffichageBuildJeu,
            metadonneesJeu.numeroBuild.ToString().PadLeft(3, '0'), metadonneesJeu.nomBuild));

        versionJeu.SetText(string.Format(FormatAffichageVersionJeu,
            Application.version, Application.unityVersion));

            copyrightJeu.SetText(string.Format(FormatAffichageCopyright,
                metadonneesJeu.dateCopyright));

    }
}
