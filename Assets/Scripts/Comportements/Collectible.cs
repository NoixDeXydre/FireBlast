using DG.Tweening;
using UnityEngine;

/// <summary>
/// Comportement d'un collectible
/// </summary>
public class Collectible : MonoBehaviour
{

    /// <summary>
    /// Marge sur laquelle le collectible 
    /// est presque en train de disparaître.
    /// </summary>
    private const float TempsSurLePointDeDisparaitre = 5.0f;

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
    private TimerEcoulement timerEcoulement;

    /// <summary>
    /// Sprite du collectible.
    /// </summary>
    private SpriteRenderer spriteCollectible;

    /// <summary>
    /// Animation (à assigner) lors de la disparition du collectible.
    /// </summary>
    private Tween animationDisparition;

    /// <summary>
    /// Initialise le collectible
    /// </summary>
    private void Awake()
    {

        controleurScore = GestionJeuUtils.GetScriptGestionJeu().controleurScore;
        timerEcoulement = new TimerEcoulement(dureeApparition, TempsSurLePointDeDisparaitre, true);

        spriteCollectible = GetComponent<SpriteRenderer>();

        InitialiserAnimationDisparition();
    }

    /// <summary>
    /// Se déclenche lorsque le joueur récupère le collectible.
    /// </summary>
    /// <param name="collision">L'objet en collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag(TagLayers.TagJoueur)) 
        {
            controleurScore.Ajouter(nombrePointsCollection);
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Met à jour le timer pour la disparition de l'entité.
    /// </summary>
    private void FixedUpdate()
    {

        timerEcoulement.Update();
        if (!animationDisparition.IsPlaying() && timerEcoulement.IsTimerEnAvertissement())
        {
            animationDisparition.Play();
        }
    }

    /// <summary>
    /// Se remet à zéro lors de la désactivation.
    /// </summary>
    private void OnDisable()
    {

        timerEcoulement.ResetTimer();
        timerEcoulement.SetPauseTimer(true);

        DoTweenUtils.ReinitialiserApparenceSpriteRenderer(spriteCollectible);

        InitialiserAnimationDisparition();
    }

    private void OnEnable()
    {
        timerEcoulement?.SetPauseTimer(false);
    }

    /// <summary>
    /// (Ré)initalise l'animation de disparition
    /// </summary>
    private void InitialiserAnimationDisparition()
    {

        // Animation tuée si null
        animationDisparition?.Kill();

        animationDisparition = spriteCollectible.DOFade(AffichageUtils.ALPHA_NUL, 0.2f)
            .SetLoops(DoTweenUtils.CalculerCyclesLoopYoyo(TempsSurLePointDeDisparaitre, 0.2f), LoopType.Yoyo)
            .OnComplete(() => gameObject.SetActive(false)).Pause();
    }
}
