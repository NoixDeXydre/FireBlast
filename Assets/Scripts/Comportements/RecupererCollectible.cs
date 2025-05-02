using UnityEngine;

/// <summary>
/// Comportement lorsqu'un collectible est r�cup�r�.
/// </summary>
public class RecupererCollectible : MonoBehaviour
{

    /// <summary>
    /// Dur�e du collectible avant de dispara�tre.
    /// </summary>
    public float dureeApparition;

    /// <summary>
    /// Nombre de points gagn�s lors de la collection de l'objet.
    /// </summary>
    public long nombrePointsCollection;

    /// <summary>
    /// Permet de manipuler le score.
    /// </summary>
    private ControleurScore controleurScore;

    /// <summary>
    /// Contr�le la disparition de l'objet.
    /// </summary>
    private DisparitionEntite controleurDisparitionEntite;

    /// <summary>
    /// R�cup�re le gestionnaire du score.
    /// </summary>
    private void Start()
    {
        controleurScore = GestionJeuUtils.GetScriptGestionJeu().controleurScore;
        controleurDisparitionEntite = new DisparitionEntite(gameObject, dureeApparition);
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

    /// <summary>
    /// Met � jour le timer pour la disparition de l'entit�.
    /// </summary>
    private void FixedUpdate()
    {
        controleurDisparitionEntite.Update();
    }
}
