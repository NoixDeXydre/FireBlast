using DG.Tweening;
using UnityEngine;
using Zenject;

/// <summary>
/// Affiche les r�sultats du jeu une fois la partie termin�e.
/// </summary>
public class AffichageResultat : MonoBehaviour
{

    [Inject] readonly private EtatsJeu _etatsJeu;

    /// <summary>
    /// Racine des r�sultats
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

        // On fait bien en sorte que tout soit d�sactiv�.
        groupeCanvas.alpha = AffichageUtils.ALPHA_NUL;
        racinePanel.SetActive(false);

        _etatsJeu.OnChangementEstPartieTerminee += AfficherResultats;
    }

    /// <summary>
    /// Affiche les r�sultats en fin de partie.
    /// </summary>
    /// <param name="estPartieTerminee">Dit si la partie est bien termin�e</param>
    private void AfficherResultats(bool estPartieTerminee)
    {

        // V�rifie que la partie est bien termin�e.
        if (estPartieTerminee)
        {
            racinePanel.SetActive(true);
            groupeCanvas.DOFade(AffichageUtils.ALPHA_COMPLET, 1f);
        }
    }
}
