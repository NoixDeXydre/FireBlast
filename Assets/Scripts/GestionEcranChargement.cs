using System;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// Contr�leur de la logique et 
/// de l'affichage de donn�es de l'�cran de chargement.
/// </summary>
public class GestionEcranChargement : MonoBehaviour
{

    /// <summary>
    /// D�fini le temps de transition lors de l'apparition.
    /// </summary>
    private const float TempsTransitionEcranVisible = .5f;

    /// <summary>
    /// D�fini le temps de transition lors de la disparition.
    /// </summary>
    private const float TempsTransitionEcranInvisible = 1.5f;

    /// <summary>
    /// Se d�clenche lorsque l'�cran de chargement 
    /// est compl�tement visible.
    /// </summary>
    public event Action OnEcranTotalementVisible;

    /// <summary>
    /// Se d�clenche lorsque l'�cran de chargement 
    /// a compl�tement disparu.
    /// </summary>
    public event Action OnEcranTotalementInvisible;

    /// <summary>
    /// L'�cran de chargement
    /// </summary>
    public CanvasGroup ecranChargement;

    /// <summary>
    /// Affiche l'�cran de chargement
    /// </summary>
    public void SetEcranVisible()
    {
        ecranChargement.DOFade(1f, TempsTransitionEcranVisible).SetEase(Ease.InFlash)
            .OnComplete(() => OnEcranTotalementVisible?.Invoke());
    }

    /// <summary>
    /// Enl�ve l'�cran de chargement.
    /// </summary>
    public void SetEcranNonVisible()
    {
        ecranChargement.DOFade(0f, TempsTransitionEcranInvisible).SetEase(Ease.OutFlash)
            .OnComplete(() => OnEcranTotalementInvisible?.Invoke());
    }

}
