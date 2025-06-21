using UnityEngine;
using Zenject;

/// <summary>
/// Fait apparaître les entités dans la carte au bon moment,
/// et selon l'état du jeu.
/// </summary>
public class ControleurApparitionEntites : MonoBehaviour
{

    [Inject] private MapVirtuelle _map;
    [Inject] private EntitesCreateur usineEntites;

    private EntitesGroupePool pool;
    private CollectionEntites entitesSrc;

    /// <summary>
    /// Initialise les composants pour repérer la map.
    /// </summary>
    private void Start()
    {

        entitesSrc = Resources.Load<CollectionEntites>(nameof(CollectionEntites));

        pool = new(200);

        // Cache des entités

        foreach(Entite entite in entitesSrc.datasets)
        {
            pool.InstancierTypeEntites(entite.nombreMaxApparition, entite.nomEntite, entite.entite);
        }

        // On crée le joueur
        usineEntites.CreerEntite(entitesSrc.datasetJoueur.entite, _map.GetCentreMap());
        IterationTournageUsine();
    }

    /// <summary>
    /// Nouveau cycle afin de vérifier les entités à créer.
    /// </summary>
    private void IterationTournageUsine()
    {
        Invoke(nameof(SousIterationCollectibles), Aleatoire.ChoisirNombreParmisPlage(5f, 25f, 1.1f));
        Invoke(nameof(SousIterationEnnemis), Aleatoire.ChoisirNombreParmisPlage(10f, 30f, 0.9f));
    }

    private void SousIterationCollectibles()
    {

        GameObject collectible = pool.GetInstanceTypeEntiteNonActif(entitesSrc.groupeCollectibles.ChoisirEntiteAleatoirement());
        if (collectible != null)
        {
            collectible.transform.position = Aleatoire.ChoisirPointParmisDeuxAxes(_map.GetCoordonneesIntervallesX(), _map.GetCoordonneesIntervallesY());
            collectible.SetActive(true);
        }

        Invoke(nameof(SousIterationCollectibles), Aleatoire.ChoisirNombreParmisPlage(5f, 10f));
    }

    private void SousIterationEnnemis()
    {

        GameObject collectible = pool.GetInstanceTypeEntiteNonActif(entitesSrc.groupeEnnemis.ChoisirEntiteAleatoirement());
        if (collectible != null)
        {
            collectible.transform.position = Aleatoire.ChoisirPointParmisDeuxAxes(_map.GetCoordonneesIntervallesX(), _map.GetCoordonneesIntervallesY());
            collectible.SetActive(true);
        }

        Invoke(nameof(SousIterationEnnemis), Aleatoire.ChoisirNombreParmisPlage(2f, 7f));
    }
}
