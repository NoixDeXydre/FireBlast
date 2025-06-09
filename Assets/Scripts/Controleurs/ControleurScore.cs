using TMPro;
using DG.Tweening;

/// <summary>
/// Pilote entre les donn�es et le score affich�.
/// </summary>
public class ControleurScore
{

    /// <summary>
    /// Niveau d'augmentation du multiplieur tout les x secondes.
    /// </summary>
    private const float AugmentationMultiplieur = .1f;

    /// <summary>
    /// D�fini le nombre de secondes � chaque it�ration
    /// pour que le multiplieur augmente.
    /// </summary>
    private const int NombreSecondesAugmentationMultiplieur = 4;

    /// <summary>
    /// Le nombre de points ajout�s � chaque seconde.
    /// </summary>
    private const int PointsParSeconde = 50;

    /// <summary>
    /// Temps �coul� du timer � un instant donn�.
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
    /// Initialise le contr�leur du score.
    /// </summary>
    /// <param name="score">Le service score</param>
    /// <param name="compteurScore">Le compteur UI affichant le score</param>
    /// <param name="timer">TimerPartie influan�ant le score</param>
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
    /// <param name="scoreAjout">Le score � ajouter ou diminuer</param>
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
    /// Augmente le score selon le nombre de secondes �coul�s.
    /// </summary>
    public void Update()
    {

        int secondesActuellesTimer = timer.GetTempsEcoule();
        float multiplicateurScore = score.GetMultiplieur();
        if (secondesTimer != secondesActuellesTimer)
        {

            // Le multiplieur est augment� par un nombre de secondes.
            if (secondesActuellesTimer % NombreSecondesAugmentationMultiplieur == 0)
            {
                score.SetMultiplieur(multiplicateurScore + AugmentationMultiplieur);
            }

            Ajouter(PointsParSeconde);
            secondesTimer = secondesActuellesTimer;
        }
    }
}
