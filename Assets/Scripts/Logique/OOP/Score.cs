using UnityEngine;

/// <summary>
/// Supporte le score d'une partie.
/// </summary>
public class Score
{

    /// <summary>
    /// Coefficient initial multiplicateur.
    /// </summary>
    public const float MultiplieurBase = 1f;

    /// <summary>
    /// Score maximum pouvant être atteint.
    /// </summary>
    private const long ScoreMax = 999999999;

    /// <summary>
    /// Score minimum pouvant être atteint.
    /// </summary>
    private const long ScoreMin = 0;

    /// <summary>
    /// Multiplicateur à chaque incrément du score.
    /// </summary>
    private float multiplieur;

    /// <summary>
    /// Score de la partie
    /// </summary>
    private long score;

    public Score()
    {
        score = ScoreMin;
        multiplieur = MultiplieurBase;
    }

    /// <summary>
    /// Augmente le score
    /// </summary>
    /// <param name="scoreAjout">Le score à ajouter</param>
    public void Ajouter(long scoreAjout)
    {

        long nouveauScore = score + (long)(scoreAjout * multiplieur);
        if (nouveauScore <= ScoreMax)
        {
            score = nouveauScore;
        } 
        
        else
        {
            score = ScoreMax;
        }
    }

    /// <summary>
    /// Diminue le score et remet à zéro le multiplieur.
    /// </summary>
    /// <param name="scoreDiminution">Le score à diminuer</param>
    public void Diminuer(long scoreDiminution)
    {

        SetMultiplieur(1f);
        long nouveauScore = score - scoreDiminution;

        if (nouveauScore >= ScoreMin)
        {
            score = nouveauScore;
        }
        
        else
        {
            score = ScoreMin;
        }
    }

    /// <returns>Le multiplieur</returns>
    public float GetMultiplieur()
    {
        return multiplieur;
    }

    /// <returns>Le score</returns>
    public long GetScore()
    {
        return score;
    }

    /// <summary>
    /// Règle manuellement le multiplieur.
    /// </summary>
    /// <param name="nouveauCoefficient">Le nouveau coefficient</param>
    public void SetMultiplieur(float nouveauCoefficient)
    {
        multiplieur = nouveauCoefficient;
    }

    /// <summary>
    /// Règle manuellement le nouveau score.
    /// </summary>
    /// <param name="score">Le score a changer</param>
    public void SetScore(long score)
    {
        this.score = score;
    }

    /// <summary>
    /// Formate le score de la manière suivante :
    /// 000 000 000
    /// </summary>
    /// <returns>Le score formaté</returns>
    public override string ToString()
    {
        return score.ToString().PadLeft(9, '0')
            .Insert(3, " ").Insert(7, " ").Insert(11, ""); 
    }
}
