using TMPro;
using UnityEngine;

/// <summary>
/// G�n�re les informations correctes dans le menu principal.
/// </summary>
public class OrganisateurMenuPrincipal : MonoBehaviour
{

    private const string FormatAffichageBuildJeu = "Build {0} - {1}";
    private const string FormatAffichageVersionJeu = "Version {0} - Unity {1}";
    private const string FormatAffichageCopyright = "Fireball {0}, All rights reserved";

    /// <summary>
    /// Param�tres faisant office de m�tadonn�es.
    /// </summary>
    public ParametresFireball metadonneesJeu;

    /// <summary>
    /// Num�ro du build et le nom des versions.
    /// </summary>
    public TextMeshProUGUI buildJeu;

    /// <summary>
    /// Copyright
    /// </summary>
    public TextMeshProUGUI copyrightJeu;

    /// <summary>
    /// Version affich�e du jeu.
    /// </summary>
    public TextMeshProUGUI versionJeu;

    /// <summary>
    /// Placement des donn�es
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
