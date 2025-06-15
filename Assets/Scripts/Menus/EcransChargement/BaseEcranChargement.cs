using DG.Tweening;
using UnityEngine;

/// <summary>
/// Impl�mente une simple transition dans l'�cran de chargement.
/// Comportement de base d'un �cran de chargement.
/// </summary>
public class BaseEcranChargement : MonoBehaviour
{

    /// <summary>
    /// Racine du canvas
    /// </summary>
    protected CanvasGroup racineCanvas;

    /// <summary>
    /// Panel contenant les ressources de l'�cran.
    /// </summary>
    protected GameObject racinePanel;

    private void Start()
    {

        racineCanvas = gameObject.GetComponentInChildren<CanvasGroup>();
        racinePanel = racineCanvas.transform.GetChild(0).gameObject;

        MiseEnPlaceMenu();
    }

    /// <summary>
    /// Met en place le menu et lance la transition de d�but.
    /// </summary>
    public virtual void MiseEnPlaceMenu()
    {

        // Remet � z�ro au pr�alable.
        racineCanvas.alpha = AffichageUtils.ALPHA_NUL;
        racinePanel.SetActive(false);

        DeclencherDebutTransition();
    }

    /// <summary>
    /// Affiche le menu de chargement.
    /// </summary>
    public virtual void DeclencherDebutTransition()
    {
        racinePanel.SetActive(true);
        racineCanvas.DOFade(AffichageUtils.ALPHA_COMPLET, 1f).SetEase(Ease.InFlash);
    }

    /// <summary>
    /// Enl�ve le menu de chargement.
    /// � ex�cuter lorsque le chargement est termin�.
    /// </summary>
    public virtual void OnCompletion()
    {
        racineCanvas.DOFade(AffichageUtils.ALPHA_NUL, .5f).OnComplete(() => Destroy(gameObject)).SetEase(Ease.OutFlash);
    }
}