using DG.Tweening;
using UnityEngine;

/// <summary>
/// Contrôleur de la logique et 
/// de l'affichage de données de l'écran de chargement.
/// </summary>
public class GestionEcranChargement : MonoBehaviour
{

    /// <summary>
    /// L'écran de chargement
    /// </summary>
    public CanvasGroup ecranChargement;

    /// <summary>
    /// Affiche l'écran de chargement
    /// </summary>
    public void SetEcranVisible()
    {
        ecranChargement.DOFade(1f, 2f);
    }

    /// <summary>
    /// Enlève l'écran de chargement.
    /// </summary>
    public void SetEcranNonVisible()
    {
        ecranChargement.DOFade(0f, 2f);
    }

}
