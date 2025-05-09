using UnityEngine;

/// <summary>
/// Défini le comportement d'un pic.
/// Un pic va simplement se diriger dans la direction
/// dans laquelle elle pointe.
/// </summary>
public class PropulsionPic : MonoBehaviour
{

    /// <summary>
    /// Durée du projectile avant de disparaître.
    /// </summary>
    public float dureeApparition;

    /// <summary>
    /// Vitesse du projectile.
    /// </summary>
    public float vitesse;

    /// <summary>
    /// Contrôle la disparition de l'objet.
    /// </summary>
    private DisparitionEntite controleurDisparitionEntite;

    /// <summary>
    /// Le projectile à lancer.
    /// </summary>
    private Rigidbody2D projectile;

    /// <summary>
    /// Projette l'entité
    /// </summary>
    private void Start()
    {

        controleurDisparitionEntite = new DisparitionEntite(gameObject, dureeApparition);
        projectile = gameObject.GetComponent<Rigidbody2D>();

        // Propulse le pic selon ça direction.
        projectile.linearVelocity = transform.up * vitesse;
    }

    /// <summary>
    /// Met à jour le timer pour la disparition de l'entité.
    /// </summary>
    private void FixedUpdate()
    {
        controleurDisparitionEntite.Update();
    }
}
