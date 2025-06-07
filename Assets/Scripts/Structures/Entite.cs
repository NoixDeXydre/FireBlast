using UnityEngine;

/// <summary>
/// Repr�sente les donn�es d'une entit�.
/// </summary>
[CreateAssetMenu(fileName = "Entite", menuName = "FireBall - Entites/Entite")]
public class Entite : ScriptableObject
{

    /// <summary>
    /// GO de l'entit�
    /// </summary>
    public GameObject entite;

    /// <summary>
    /// Nom de l'entit�
    /// </summary>
    public string nomEntite;

    /// <summary>
    /// La chance o� l'entit� peut appara�tre.
    /// </summary>
    public float chanceApparition = 1.0f;

    /// <summary>
    /// Nombre maximum d'instances
    /// </summary>
    public int nombreMaxApparition = 1;

    /// <summary>
    /// Tranche de niveaux de difficult�s dans lesquelles l'entit�
    /// peut appara�tre.
    /// </summary>
    public int[] niveauxParution = new int[2] {1, 9};
}
