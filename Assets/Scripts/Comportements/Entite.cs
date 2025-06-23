using UnityEngine;

/// <summary>
/// Repr�sente une entit�
/// </summary>
public class Entite : MonoBehaviour
{

    /// <summary>
    /// Rendu graphique du sprite
    /// </summary>
    public SpriteRenderer SpriteRenderer { get; private set; }

    /// <summary>
    /// Initialisation des composants
    /// </summary>
    protected void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
