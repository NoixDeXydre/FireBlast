using DG.Tweening;
using UnityEngine;

/// <summary>
/// Contr�leur de la logique et 
/// de l'affichage de donn�es de l'�cran de chargement.
/// </summary>
public class GestionEcranChargement : MonoBehaviour
{

    /// <summary>
    /// L'�cran de chargement
    /// </summary>
    public CanvasGroup ecranChargement;

    /// <summary>
    /// Affiche l'�cran de chargement
    /// </summary>
    public void SetEcranVisible()
    {
        ecranChargement.DOFade(1f, 2f);
    }

    /// <summary>
    /// Enl�ve l'�cran de chargement.
    /// </summary>
    public void SetEcranNonVisible()
    {
        ecranChargement.DOFade(0f, 2f);
    }

}
