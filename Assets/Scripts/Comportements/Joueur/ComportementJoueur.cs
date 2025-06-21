using DG.Tweening;
using UnityEngine;
using Zenject;

/// <summary>
/// À part les contrôles de base,
/// défini ses autres comportements.
/// </summary>
public class ComportementJoueur : MonoBehaviour
{

    /// <summary>
    /// Temps où le joueur ne peut pas bouger après un dommage.
    /// </summary>
    private const float TempsMouvementsInactif = .8f;

    /// <summary>
    /// Nombre de points perdus lorsque le joueur est touché.
    /// </summary>
    public int nombrePointsPerdusDommage;

    /// <summary>
    /// Temps d'invinsibilité du joueur 
    /// si touché par un projectile.
    /// </summary>
    public float tempsInvincibilite;

    /// <summary>
    /// Permet de modifier le score.
    /// </summary>
    [Inject] private readonly ControleurScore _controleurScore;

    /// <summary>
    /// Permet de modifier la vie du personnage.
    /// </summary>
    [Inject] private readonly ControleurVie _controleurVie;

    [Inject] private readonly EtatsJeu _etatsJeu;

    /// <summary>
    /// Le temps écoulé en étant invincible.
    /// </summary>
    private float timerInvincibilite;

    /// <summary>
    /// Défini le moment où le joueur est invincible.
    /// </summary>
    private bool estInvincible;

    /// <summary>
    /// Module permetant de bouger le joueur.
    /// </summary>
    private PhysiqueJoueur physiqueJoueur;

    /// <summary>
    /// Rendu du sprite.
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Prépare le joueur et sa physique.
    /// </summary>
    private void Start()
    {

        timerInvincibilite = .0f;
        estInvincible = false;

        physiqueJoueur = GetComponent<ControlesJoueur>().physiqueJoueur;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Se déclenche lorsque le joueur subit un dégât.
    /// </summary>
    /// <param name="collision">L'objet en collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Lorsque le joueur est touché par un projectile.
        if (!estInvincible && collision.collider.CompareTag(TagLayers.TagProjectile))
        {

            _controleurVie.Diminuer();
            _controleurScore.Ajouter(nombrePointsPerdusDommage);

            estInvincible = true;
            _etatsJeu.SontMouvementsBloqueesParDommage = true;

            // Propulse le joueur dans la direction du projectile.
            Vector2 vitesseProjectile = collision.rigidbody.linearVelocity;
            physiqueJoueur.Propulser(-vitesseProjectile * vitesseProjectile.magnitude 
                * collision.otherRigidbody.mass);

            // Animation lorsque touché
            spriteRenderer.DOFade(0f, .2f).OnComplete(() => spriteRenderer.DOFade(AffichageUtils.ALPHA_COMPLET, .5f))
                .SetLoops(DoTweenUtils.CalculerCyclesLoopYoyo(tempsInvincibilite, .2f));
        }

        // Lorsque le joueur rebondit dans un mur.
        else if (collision.collider.CompareTag(TagLayers.TagMur))
        {

            // TODO réduire et optimiser l'expression. 
            transform.DOScale((Vector2)transform.localScale - new Vector2(Mathf.Abs(collision.otherRigidbody.linearVelocity.x),
                Mathf.Abs(collision.otherRigidbody.linearVelocity.y)) / 100.0f, .1f)
                .SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutSine).OnComplete(() => transform.localScale = new Vector2(1, 1));
        }
    }

    /// <summary>
    /// Gère le temps d'invincibilité du joueur.
    /// </summary>
    private void FixedUpdate()
    {
        if (estInvincible)
        {

            timerInvincibilite += Time.deltaTime;
            if (timerInvincibilite > TempsMouvementsInactif)
            {
                _etatsJeu.SontMouvementsBloqueesParDommage = false;
            }


            if (timerInvincibilite >= tempsInvincibilite)
            {
                timerInvincibilite = .0f;
                estInvincible = false;
            }
        }
    }
}
