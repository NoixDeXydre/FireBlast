using UnityEngine;

/// <summary>
/// Classe utilitaire pour la gestion des animations.
/// </summary>
public static class DoTweenUtils
{
    
    /// <summary>
    /// Retourne le nombre de cycles nécessaires 
    /// pour effectuer une animation Yoyo proprement.
    /// </summary>
    /// <param name="dureeTotaleAnimation">La durée totale de l'animation</param>
    /// <param name="dureeAnimationParCycle">La durée d'une seule animation par cycle</param>
    /// <returns></returns>
    public static int CalculerCyclesLoopYoyo(float dureeTotaleAnimation,
        float dureeAnimationParCycle)
    {
        return (int)Mathf.Round(dureeTotaleAnimation / dureeAnimationParCycle);
    }
}
