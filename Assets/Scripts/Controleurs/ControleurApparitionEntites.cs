using UnityEngine;
using Zenject;

/// <summary>
/// Fait appara�tre les entit�s dans la carte au bon moment,
/// et selon l'�tat du jeu.
/// </summary>
public class ControleurApparitionEntites : MonoBehaviour
{

    [Inject] readonly private MapVirtuelle _map;

    [Inject] readonly private IFactory<Vector3, Joueur> _usineJoueur;

    [Inject] readonly private EntitesGroupePool _pool;

    [Inject] readonly private CollectionEntites _db;

    /// <summary>
    /// Initialise les composants pour rep�rer la map.
    /// </summary>
    private void Start()
    {

        foreach (var entite in _db.datasets)
        {
            _pool.CreateBatch(entite.nombreMaxApparition, entite.nomEntite, entite.entite);
        }

        // On cr�e le joueur
        _usineJoueur.Create(_map.GetCentreMap());

        IterationTournageUsine();
    }

    /// <summary>
    /// Nouveau cycle afin de v�rifier les entit�s � cr�er.
    /// </summary>
    private void IterationTournageUsine()
    {
        Invoke(nameof(SousIterationCollectibles), Aleatoire.ChoisirNombreParmisPlage(5f, 25f, 1.1f));
        Invoke(nameof(SousIterationEnnemis), Aleatoire.ChoisirNombreParmisPlage(10f, 30f, 0.9f));
    }

    private void SousIterationCollectibles()
    {

        GameObject collectible = _pool.GetInstanceTypeEntiteNonActif(_db.groupeCollectibles.ChoisirEntiteAleatoirement());
        if (collectible != null)
        {
            collectible.transform.position = Aleatoire.ChoisirPointParmisDeuxAxes(_map.GetCoordonneesIntervallesX(), _map.GetCoordonneesIntervallesY());
            collectible.gameObject.SetActive(true);
        }

        Invoke(nameof(SousIterationCollectibles), Aleatoire.ChoisirNombreParmisPlage(5f, 10f));
    }

    private void SousIterationEnnemis()
    {

        GameObject collectible = _pool.GetInstanceTypeEntiteNonActif(_db.groupeEnnemis.ChoisirEntiteAleatoirement());
        if (collectible != null)
        {
            collectible.transform.position = Aleatoire.ChoisirPointParmisDeuxAxes(_map.GetCoordonneesIntervallesX(), _map.GetCoordonneesIntervallesY());
            collectible.gameObject.SetActive(true);
        }

        Invoke(nameof(SousIterationEnnemis), Aleatoire.ChoisirNombreParmisPlage(2f, 7f));
    }
}
