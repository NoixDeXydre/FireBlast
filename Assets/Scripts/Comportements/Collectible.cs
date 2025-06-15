using DG.Tweening;
using UnityEngine;

/// <summary>
/// Comportement d'un collectible
/// </summary>
public class Collectible : MonoBehaviour
{

    /// <summary>
    /// Marge sur laquelle le collectible 
    /// est presque en train de dispara�tre.
    /// </summary>
    private const float TempsSurLePointDeDisparaitre = 5.0f;

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
    private TimerEcoulement timerEcoulement;

    /// <summary>
    /// Sprite du collectible.
    /// </summary>
    private SpriteRenderer spriteCollectible;

    /// <summary>
    /// Animation (� assigner) lors de la disparition du collectible.
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
    /// Se d�clenche lorsque le joueur r�cup�re le collectible.
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
    /// Met � jour le timer pour la disparition de l'entit�.
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
    /// Se remet � z�ro lors de la d�sactivation.
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
    /// (R�)initalise l'animation de disparition
    /// </summary>
    private void InitialiserAnimationDisparition()
    {

        // Animation tu�e si null
        animationDisparition?.Kill();

        animationDisparition = spriteCollectible.DOFade(AffichageUtils.ALPHA_NUL, 0.2f)
            .SetLoops(DoTweenUtils.CalculerCyclesLoopYoyo(TempsSurLePointDeDisparaitre, 0.2f), LoopType.Yoyo)
            .OnComplete(() => gameObject.SetActive(false)).Pause();
    }
}
