using System;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// Contrôleur de la logique et 
/// de l'affichage de données de l'écran de chargement.
/// </summary>
public class GestionEcranChargement : MonoBehaviour
{

    /// <summary>
    /// Défini le temps de transition lors de l'apparition.
    /// </summary>
    private const float TempsTransitionEcranVisible = .5f;

    /// <summary>
    /// Défini le temps de transition lors de la disparition.
    /// </summary>
    private const float TempsTransitionEcranInvisible = 1.5f;

    /// <summary>
    /// Se déclenche lorsque l'écran de chargement 
    /// est complètement visible.
    /// </summary>
    public event Action OnEcranTotalementVisible;

    /// <summary>
    /// Se déclenche lorsque l'écran de chargement 
    /// a complètement disparu.
    /// </summary>
    public event Action OnEcranTotalementInvisible;

    /// <summary>
    /// L'écran de chargement
    /// </summary>
    public CanvasGroup ecranChargement;

    /// <summary>
    /// Affiche l'écran de chargement
    /// </summary>
    public void SetEcranVisible()
    {
        ecranChargement.DOFade(1f, TempsTransitionEcranVisible).SetEase(Ease.InFlash)
            .OnComplete(() => OnEcranTotalementVisible?.Invoke());
    }

    /// <summary>
    /// Enlève l'écran de chargement.
    /// </summary>
    public void SetEcranNonVisible()
    {
        ecranChargement.DOFade(0f, TempsTransitionEcranInvisible).SetEase(Ease.OutFlash)
            .OnComplete(() => OnEcranTotalementInvisible?.Invoke());
    }

}
