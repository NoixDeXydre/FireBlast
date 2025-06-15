using DG.Tweening;
using UnityEngine;

/// <summary>
/// Implémente une simple transition dans l'écran de chargement.
/// </summary>
public class ChargementEcran : MonoBehaviour
{

    /// <summary>
    /// Racine du canvas
    /// </summary>
    private CanvasGroup racineCanvas;

    /// <summary>
    /// Panel contenant les ressources de l'écran.
    /// </summary>
    private GameObject racinePanel;

    private void Start()
    {

        racineCanvas = gameObject.GetComponentInChildren<CanvasGroup>();
        racinePanel = racineCanvas.transform.GetChild(0).gameObject;

        // Remet à zéro au préalable.
        racineCanvas.alpha = 0f;
        racinePanel.SetActive(false);

        DeclencherDebutTransition();
    }

    /// <summary>
    /// Affiche le menu de chargement.
    /// </summary>
    private void DeclencherDebutTransition()
    {
        racinePanel.SetActive(true);
        racineCanvas.DOFade(1f, 1f).SetEase(Ease.InFlash);
    }

    /// <summary>
    /// Enlève le menu de chargement.
    /// À exécuter lorsque le chargement est terminé.
    /// </summary>
    public void OnCompletion()
    {
        racineCanvas.DOFade(0f, .5f).OnComplete(() => Destroy(gameObject)).SetEase(Ease.OutFlash);
    }
}