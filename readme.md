# Project Aspect

---

## Première étape : Installation de Visual Studio 2022

lien direct de téléchargement [ici](https://visualstudio.microsoft.com/fr/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false)

Une fois arrivé à l’étape **`Choisir les charges de travail`** il faudra sélectionner `.NET desktop development` :

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled.png)

Terminer l’installation et passer à l’étape suivante

## Deuxième étape : Installation d’un serveur Unturned en local

Pour cette étape vous pouvez utiliser `SteamCMD` ou installer `UnturnedDedicatedServer` sur Steam (il y a des tutos sur internet donc je vais pas expliquer cette partie)

Une fois le serveur installé, vous devrez avoir une architecture comme celle-ci :

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%201.png)

a partir de la, lancer votre serveur une première fois pour instancier les fichier de votre serveurs (`ServerHelper.bat`). Les fichiers du serveur par default se trouve dans `/Servers/default` (le nom peut changer mais c’est ici que ça ce passe). 

Maintenant il faut mettre Rocket sur votre serveur, pour faire ça, copier le dossier `Rocket.Unturned` présent dans le dossier `Extras` et coller le dans le dossier `Modules` (`Extras` et `Modules` se trouve à la racine du serveur)

Relancer votre serveur puis vérifier qu’un dossier rocket est présent dans les fichiers de votre serveur (`/Servers/default`):

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%202.png)

## Troisième étape : Cloner le dépôt

Ouvrez Visual Studio et faites `Cloner un dépôt` en utilisant le repo GitHub suivant : [https://github.com/Rlvx/PluginExemple](https://github.com/Rlvx/PluginExemple)

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%203.png)

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%204.png)

Une fois terminé vous devrez avoir un truc du style : 

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%205.png)

La partie de droite est votre explorateur de solution, c’est ici que ce trouve vos codes sources et vos dépendances (=références). Vous pouvez accéder au fichiers en cliquant sur votre solution et cliquer sur `Ouvrir le dossier dans l'explorateur de fichiers`

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%206.png)

Revenez d’un dossier en arrière et vous aurez ceci :

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%207.png)

> **Important** : Gardez à l’esprit l’emplacement du dossier `Librairies` il va nous servir pour la suite.
> 

## Quatrième étape : Build la solution

Revenez sur Visual Studio et rendez-vous dans les options de build :

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%208.png)

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%209.png)

Dans chemin de sortie, spécifier le chemin d’accès vers le dossier plugin de votre server (lorsque vous êtes dans les fichiers de votre serveur le chemin d’accès vers le dossier plugins est le suivant `Servers/Default/Rocket/Plugins`)

Une fois cela modifié, vous pouvez démarrer le build de la solution :

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%2010.png)

L’erreur est normale donc vous pouvez la skip.

Vérifier que votre plugins est bien visible dans le dossier plugin de votre server :

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%2011.png)

Dans ce dossier, vous avez le choix, soit vous pouvez laisser les .dll en plus mais cela va générer des messages d’erreurs inoffensif dans la console, soit vous pouvez les supprimer.

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%2012.png)

Perso je supprime pour ne garder que mon plugin

## Cinquième étape : Import de nos librairies dans Rocket

Nous arrivons à la dernière étape avant le lancement du serveur, l’import des librairies dans Rocket. Copier le contenu du dossier Librairies de votre solution ([ici](https://www.notion.so/Project-Aspect-28700373ee574643a7a8fd1f22f75330)) dans le dossier Librairies de rocket (`Servers/Rocket/Librairies`):

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%2013.png)

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%2014.png)

## Dernière étape : Lancement du serveur et validation

Voila, le serveur est prêt à être lancé ! 

une fois lancé vous pouvez vérifier que le plugin à bien été load :

![Untitled](Project%20Aspect%20252252b2b3f44e7bbc277036d151fe30/Untitled%2015.png)
