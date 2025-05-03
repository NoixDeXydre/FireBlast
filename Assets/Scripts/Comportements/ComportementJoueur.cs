using DG.Tweening;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// � part les contr�les de base,
/// d�fini ses autres comportements.
/// </summary>
public class ComportementJoueur : MonoBehaviour
{

    /// <summary>
    /// Temps d'invinsibilit� du joueur 
    /// si touch� par un projectile.
    /// </summary>
    public float tempsInvincibilite;

    /// <summary>
    /// Le temps �coul� en �tant invincible.
    /// </summary>
    private float timerInvincibilite;

    /// <summary>
    /// D�fini le moment o� le joueur est invincible.
    /// </summary>
    private bool estInvincible;

    /// <summary>
    /// Module permetant de bouger le joueur.
    /// </summary>
    private PhysiqueJoueur physiqueJoueur;

    /// <summary>
    /// Pr�pare le joueur et sa physique.
    /// </summary>
    private void Start()
    {

        timerInvincibilite = .0f;
        estInvincible = false;

        physiqueJoueur = GestionJeuUtils.GetScriptGestionJeu().physiqueJoueur;
    }

    /// <summary>
    /// Se d�clenche lorsque le joueur subit un d�g�t.
    /// </summary>
    /// <param name="collision">L'objet en collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!estInvincible && collision.collider.CompareTag(TagLayers.TagProjectile))
        {

            estInvincible = true;

            // Propulse le joueur dans la direction du projectile.
            Vector2 vitesseProjectile = collision.rigidbody.linearVelocity;
            physiqueJoueur.Propulser(-vitesseProjectile * vitesseProjectile.magnitude 
                * collision.otherRigidbody.mass);
        }

        else if (collision.collider.CompareTag(TagLayers.TagMur))
        {
            transform.DOScale((Vector2)transform.localScale - new Vector2(Mathf.Abs(collision.otherRigidbody.linearVelocity.x), Mathf.Abs(collision.otherRigidbody.linearVelocity.y)) / 100.0f, .1f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutSine);
        }
    }

    /// <summary>
    /// G�re le temps d'invincibilit� du joueur.
    /// </summary>
    private void FixedUpdate()
    {
        if (estInvincible)
        {
            timerInvincibilite += Time.deltaTime;
            if (timerInvincibilite >= tempsInvincibilite)
            {
                timerInvincibilite = .0f;
                estInvincible = false;
            }
        }
    }
}
