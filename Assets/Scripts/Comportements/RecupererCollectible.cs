using UnityEngine;

/// <summary>
/// Comportement lorsqu'un collectible est récupéré.
/// </summary>
public class RecupererCollectible : MonoBehaviour
{

    /// <summary>
    /// Durée du collectible avant de disparaître.
    /// </summary>
    public float dureeApparition;

    /// <summary>
    /// Nombre de points gagnés lors de la collection de l'objet.
    /// </summary>
    public long nombrePointsCollection;

    /// <summary>
    /// Permet de manipuler le score.
    /// </summary>
    private ControleurScore controleurScore;

    /// <summary>
    /// Contrôle la disparition de l'objet.
    /// </summary>
    private DisparitionEntite controleurDisparitionEntite;

    /// <summary>
    /// Récupère le gestionnaire du score.
    /// </summary>
    private void Start()
    {
        controleurScore = GestionJeuUtils.GetScriptGestionJeu().controleurScore;
        controleurDisparitionEntite = new DisparitionEntite(gameObject, dureeApparition);
    }

    /// <summary>
    /// Se déclenche lorsque le joueur récupère le collectible.
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
    /// Met à jour le timer pour la disparition de l'entité.
    /// </summary>
    private void FixedUpdate()
    {
        controleurDisparitionEntite.Update();
    }
}
