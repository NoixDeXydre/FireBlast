using UnityEngine;

/// <summary>
/// Représente les données d'une entité.
/// </summary>
[CreateAssetMenu(fileName = "Entite", menuName = "FireBall - Entites/Entite")]
public class Entite : ScriptableObject
{

    /// <summary>
    /// GO de l'entité
    /// </summary>
    public GameObject entite;

    /// <summary>
    /// Nom de l'entité
    /// </summary>
    public string nomEntite;

    /// <summary>
    /// La chance où l'entité peut apparaître.
    /// </summary>
    public float chanceApparition = 1.0f;

    /// <summary>
    /// Nombre maximum d'instances
    /// </summary>
    public int nombreMaxApparition = 1;

    /// <summary>
    /// Tranche de niveaux de difficultés dans lesquelles l'entité
    /// peut apparaître.
    /// </summary>
    public int[] niveauxParution = new int[2] {1, 9};
}
