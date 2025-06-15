using DG.Tweening;
using UnityEngine;

/// <summary>
/// Affiche l'UI du jeu
/// </summary>
public class UIJeu : MonoBehaviour
{

    /// <summary>
    /// Racine de l'UI
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

        EtatsJeu.GetInstanceEtatsJeu().OnChangementEstPartieTerminee += DesactiverUI;
    }

    /// <summary>
    /// Enlève l'UI
    /// </summary>
    /// <param name="estPartieTerminee">Dit si la partie est bien terminée</param>
    private void DesactiverUI(bool estPartieTerminee)
    {

        // Vérifie que la partie est bien terminée.
        if (estPartieTerminee)
        {
            groupeCanvas.DOFade(AffichageUtils.ALPHA_NUL, 1f).OnComplete(() => racinePanel.SetActive(false));
        }
    }
}
