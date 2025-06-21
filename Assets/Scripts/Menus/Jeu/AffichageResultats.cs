using DG.Tweening;
using UnityEngine;
using Zenject;

/// <summary>
/// Affiche les résultats du jeu une fois la partie terminée.
/// </summary>
public class AffichageResultat : MonoBehaviour
{

    [Inject] readonly private EtatsJeu _etatsJeu;

    /// <summary>
    /// Racine des résultats
    /// </summary>
    private GameObject racinePanel;

    /// <summary>
    /// Groupe de transparence
    /// </summary>
    private CanvasGroup groupeCanvas;

    private void Start()
    {

        groupeCanvas = GetComponent<CanvasGroup>();
        racinePanel = transform.GetChild(0).gameObject;

        // On fait bien en sorte que tout soit désactivé.
        groupeCanvas.alpha = AffichageUtils.ALPHA_NUL;
        racinePanel.SetActive(false);

        _etatsJeu.OnChangementEstPartieTerminee += AfficherResultats;
    }

    /// <summary>
    /// Affiche les résultats en fin de partie.
    /// </summary>
    /// <param name="estPartieTerminee">Dit si la partie est bien terminée</param>
    private void AfficherResultats(bool estPartieTerminee)
    {

        // Vérifie que la partie est bien terminée.
        if (estPartieTerminee)
        {
            racinePanel.SetActive(true);
            groupeCanvas.DOFade(AffichageUtils.ALPHA_COMPLET, 1f);
        }
    }
}
