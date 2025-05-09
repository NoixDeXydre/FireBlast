using DG.Tweening;
using UnityEngine;

/// <summary>
/// � part les contr�les de base,
/// d�fini ses autres comportements.
/// </summary>
public class ComportementJoueur : MonoBehaviour
{

    /// <summary>
    /// Nombre de points perdus lorsque le joueur est touch�.
    /// </summary>
    public int nombrePointsPerdusDommage;

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
    /// Permet de modifier le score.
    /// </summary>
    private ControleurScore controleurScore;

    /// <summary>
    /// Permet de modifier la vie du personnage.
    /// </summary>
    private ControleurVie controleurVie;

    /// <summary>
    /// Script principal du jeu
    /// </summary>
    private GestionJeu scriptGestionJeu;

    /// <summary>
    /// Module permetant de bouger le joueur.
    /// </summary>
    private PhysiqueJoueur physiqueJoueur;

    /// <summary>
    /// Rendu du sprite.
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Pr�pare le joueur et sa physique.
    /// </summary>
    private void Start()
    {

        timerInvincibilite = .0f;
        estInvincible = false;

        scriptGestionJeu = GestionJeuUtils.GetScriptGestionJeu();
        controleurVie = scriptGestionJeu.controleurVie;
        controleurScore = scriptGestionJeu.controleurScore;
        physiqueJoueur = scriptGestionJeu.physiqueJoueur;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Se d�clenche lorsque le joueur subit un d�g�t.
    /// </summary>
    /// <param name="collision">L'objet en collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Lorsque le joueur est touch� par un projectile.
        if (!estInvincible && collision.collider.CompareTag(TagLayers.TagProjectile))
        {

            controleurVie.Diminuer();
            controleurScore.Ajouter(nombrePointsPerdusDommage);

            estInvincible = true;

            // Propulse le joueur dans la direction du projectile.
            Vector2 vitesseProjectile = collision.rigidbody.linearVelocity;
            physiqueJoueur.Propulser(-vitesseProjectile * vitesseProjectile.magnitude 
                * collision.otherRigidbody.mass);

            // Animation lorsque touch�
            spriteRenderer.DOFade(0f, .2f).OnComplete(() => spriteRenderer.DOFade(1f, .5f))
                .SetLoops((int)(tempsInvincibilite / .2f)); // Nombre de loop calcul� avec les secondes.
        }

        // Lorsque le joueur rebondit dans un mur.
        else if (collision.collider.CompareTag(TagLayers.TagMur))
        {

            // TODO r�duire et optimiser l'expression. 
            transform.DOScale((Vector2)transform.localScale - new Vector2(Mathf.Abs(collision.otherRigidbody.linearVelocity.x),
                Mathf.Abs(collision.otherRigidbody.linearVelocity.y)) / 100.0f, .1f)
                .SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutSine).OnComplete(() => transform.localScale = new Vector2(1, 1));
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
