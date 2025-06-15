using DG.Tweening;
using UnityEngine;

/// <summary>
/// Impl�mente une simple transition dans l'�cran de chargement.
/// </summary>
public class ChargementEcran : MonoBehaviour
{

    /// <summary>
    /// Racine du canvas
    /// </summary>
    private CanvasGroup racineCanvas;

    /// <summary>
    /// Panel contenant les ressources de l'�cran.
    /// </summary>
    private GameObject racinePanel;

    private void Start()
    {

        racineCanvas = gameObject.GetComponentInChildren<CanvasGroup>();
        racinePanel = racineCanvas.transform.GetChild(0).gameObject;

        // Remet � z�ro au pr�alable.
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
    /// Enl�ve le menu de chargement.
    /// � ex�cuter lorsque le chargement est termin�.
    /// </summary>
    public void OnCompletion()
    {
        racineCanvas.DOFade(0f, .5f).OnComplete(() => Destroy(gameObject)).SetEase(Ease.OutFlash);
    }
}