using UnityEngine;

/// <summary>
/// Classe utilitaire pour la gestion des animations.
/// </summary>
public static class DoTweenUtils
{
    
    /// <summary>
    /// Retourne le nombre de cycles n�cessaires 
    /// pour effectuer une animation Yoyo proprement.
    /// </summary>
    /// <param name="dureeTotaleAnimation">La dur�e totale de l'animation</param>
    /// <param name="dureeAnimationParCycle">La dur�e d'une seule animation par cycle</param>
    /// <returns></returns>
    public static int CalculerCyclesLoopYoyo(float dureeTotaleAnimation,
        float dureeAnimationParCycle)
    {
        return (int)Mathf.Round(dureeTotaleAnimation / dureeAnimationParCycle);
    }

    /// <summary>
    /// R�initialise les couleurs d'un sprite
    /// </summary>
    /// <param name="sprite">Le sprite renderer</param>
    public static void ReinitialiserApparenceSpriteRenderer(SpriteRenderer sprite)
    {

        Color couleur = sprite.color;
        couleur.a = 1f;

        sprite.color = couleur;
    }
}
