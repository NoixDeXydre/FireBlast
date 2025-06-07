using TMPro;
using DG.Tweening;

/// <summary>
/// Pilote entre les données et le score affiché.
/// </summary>
public class ControleurScore
{

    /// <summary>
    /// Niveau d'augmentation du multiplieur tout les x secondes.
    /// </summary>
    private const float AugmentationMultiplieur = .1f;

    /// <summary>
    /// Défini le nombre de secondes à chaque itération
    /// pour que le multiplieur augmente.
    /// </summary>
    private const int NombreSecondesAugmentationMultiplieur = 4;

    /// <summary>
    /// Le nombre de points ajoutés à chaque seconde.
    /// </summary>
    private const int PointsParSeconde = 50;

    /// <summary>
    /// Temps écoulé du timer à un instant donné.
    /// </summary>
    private int secondesTimer;

    /// <summary>
    /// Stocke le score
    /// </summary>
    private readonly Score score;

    /// <summary>
    /// Stocke le score avant un gain ou une perte afin
    /// d'effectuer des animations.
    /// </summary>
    private readonly Score scoreInstantPrecedent;

    /// <summary>
    /// Influence le score 
    /// et permet de faire gagner des points chaque seconde.
    /// </summary>
    private readonly TimerPartie timer;

    /// <summary>
    /// Affiche le score
    /// </summary>
    private readonly TextMeshProUGUI compteurScore;

    /// <summary>
    /// Initialise le contrôleur du score.
    /// </summary>
    /// <param name="score">Le service score</param>
    /// <param name="compteurScore">Le compteur UI affichant le score</param>
    /// <param name="timer">TimerPartie influançant le score</param>
    public ControleurScore(Score score, TextMeshProUGUI compteurScore, TimerPartie timer)
    {

        this.score = score;
        this.compteurScore = compteurScore;
        this.timer = timer;

        scoreInstantPrecedent = new Score();

        secondesTimer = 0;

        compteurScore.SetText(score.ToString());
    }

    /// <summary>
    /// Augmente ou baisse le score.
    /// </summary>
    /// <param name="scoreAjout">Le score à ajouter ou diminuer</param>
    public void Ajouter(long scoreAjout)
    {

        long ancienScore = score.GetScore();

        if (scoreAjout < 0)
        {
            score.Diminuer(-scoreAjout);
        }

        else
        {
            score.Ajouter(scoreAjout);
        }

        // Animation de gain ou de perte.
        DOTween.To(() => ancienScore, nouvelleCible => {
            ancienScore = nouvelleCible;
            scoreInstantPrecedent.SetScore(ancienScore);
            compteurScore.text = scoreInstantPrecedent.ToString();
        }, score.GetScore(), .8f).SetEase(Ease.InOutSine);
    }

    /// <summary>
    /// Augmente le score selon le nombre de secondes écoulés.
    /// </summary>
    public void Update()
    {

        int secondesActuellesTimer = timer.GetTempsEcoule();
        float multiplicateurScore = score.GetMultiplieur();
        if (secondesTimer != secondesActuellesTimer)
        {

            // Le multiplieur est augmenté par un nombre de secondes.
            if (secondesActuellesTimer % NombreSecondesAugmentationMultiplieur == 0)
            {
                score.SetMultiplieur(multiplicateurScore + AugmentationMultiplieur);
            }

            Ajouter(PointsParSeconde);
            secondesTimer = secondesActuellesTimer;
        }
    }
}
