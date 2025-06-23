using UnityEngine;
using Zenject;

/// <summary>
/// D�fini les d�pendances � un injecter dans la sc�ne Jeu.
/// </summary>
public class InstallerJeu : MonoInstaller
{

    /// <summary>
    /// D�fini et injecte
    /// </summary>
    public override void InstallBindings()
    {

        // Base de donn�es

        Container.Bind<CollectionEcransChargement>().FromResource(nameof(CollectionEcransChargement));
        Container.Bind<CollectionEntites>().FromResource(nameof(CollectionEntites));

        // Composants principaux

        Container.Bind<EtatsJeu>().AsSingle();

        Container.Bind<MapVirtuelle>().FromComponentInHierarchy().AsSingle();

        Container.Bind<EntitesCreateur>().AsSingle();

        // Contr�leurs 
        Container.Bind<ControleurScore>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ControleurTemps>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ControleurVie>().FromComponentInHierarchy().AsSingle();

        // Usines
        Container.BindInterfacesAndSelfTo<UsineJoueur>().AsSingle();
        Container.BindInterfacesAndSelfTo<EntitesGroupePool>().AsSingle().WithArguments(200);
    }
}