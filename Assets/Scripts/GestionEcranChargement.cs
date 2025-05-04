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
    /// Se d�clenche lorsque l'�cran de chargement 
    /// est compl�tement visible.
    /// </summary>
    public static event Action OnEcranTotalementVisible;

    /// <summary>
    /// Se d�clenche lorsque l'�cran de chargement 
    /// a compl�tement disparu.
    /// </summary>
    public static event Action OnEcranTotalementInvisible;

    /// <summary>
    /// L'�cran de chargement
    /// </summary>
    public CanvasGroup ecranChargement;

    /// <summary>
    /// Affiche l'�cran de chargement
    /// </summary>
    public void SetEcranVisible()
    {
        ecranChargement.DOFade(1f, 2f).OnComplete(() => OnEcranTotalementVisible?.Invoke());
    }

    /// <summary>
    /// Enl�ve l'�cran de chargement.
    /// </summary>
    public void SetEcranNonVisible()
    {
        ecranChargement.DOFade(0f, 2f).OnComplete(() => OnEcranTotalementInvisible?.Invoke());
    }

}
