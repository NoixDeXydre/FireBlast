using TMPro;
using DG.Tweening;
using UnityEngine;
using Zenject;

/// <summary>
/// G�re le score du joueur graphiquement et num�riquement.
/// </summary>
public class ControleurScore : MonoBehaviour
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
    /// Contr�leur du temps
    /// </summary>
    [Inject] private readonly ControleurTemps _controleurTemps;

    /// <summary>
    /// Temps �coul� du timer � un instant donn�.
    /// </summary>
    private int secondesTimer;

    /// <summary>
    /// Stocke le score
    /// </summary>
    private Score score;

    /// <summary>
    /// Stocke le score avant un gain ou une perte afin
    /// d'effectuer des animations.
    /// </summary>
    private Score scoreInstantPrecedent;

    /// <summary>
    /// Affiche le score
    /// </summary>
    private TextMeshProUGUI compteurScore;

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
    /// Initialise le contr�leur.
    /// </summary>
    private void Start()
    {

        compteurScore = GetComponent<TextMeshProUGUI>();

        score = new();
        scoreInstantPrecedent = new();

        secondesTimer = 0;

        compteurScore.SetText(score.ToString());
    }

    /// <summary>
    /// Augmente le score selon le nombre de secondes �coul�s.
    /// </summary>
    private void Update()
    {

        int secondesActuellesTimer = _controleurTemps.GetTimerPartie().GetTempsEcoule();
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
