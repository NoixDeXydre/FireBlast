using UnityEngine;

/// <summary>
/// Comportement lorsqu'un collectible est r�cup�r�.
/// </summary>
public class RecupererCollectible : MonoBehaviour
{

    /// <summary>
    /// Nombre de points gagn�s lors de la collection de l'objet.
    /// </summary>
    public long nombrePointsCollection;

    private ControleurScore controleurScore;

    /// <summary>
    /// R�cup�re le gestionnaire du score.
    /// </summary>
    private void Start()
    {
        controleurScore = GestionJeuUtils.GetScriptGestionJeu().controleurScore;
    }

    /// <summary>
    /// Se d�clenche lorsque le joueur r�cup�re le collectible.
    /// </summary>
    /// <param name="collision">L'objet en collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag.Equals(TagLayers.TagJoueur)) 
        {
            controleurScore.Ajouter(nombrePointsCollection);
            Object.Destroy(gameObject);
        }
    }
}
