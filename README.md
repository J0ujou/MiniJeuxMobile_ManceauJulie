# MiniJeuxMobile_ManceauJulie

Marshmallow Quest

// Première partie : Idée globale du projet dans sa totalité //

Marshmallow Quest est un jeu mobile arcade (pour Android) regroupant 3 (à 4) différents mini-jeux qui suivent un thème et un objectif communs.
Le joueur aide (et incarne) un personnage de guimauve dans un monde 2D coloré et mignon fait de sucreries. Ce marshmallow a besoin de se construire une maison pour s'abriter et se protéger de son plus grand danger : le chocolat.

Le joueur suit le personnage sur les différentes étapes de fabrication de sa maison en bonbon :
-	[Jeu de type Game and Watch] Il récupère des bonbons produits à la suite d’une pluie de bonbons. Ils sont très utiles pour la construction de sa maison et ses meubles, mais ont une particularité : ils sont fragiles. 
-	[Jeu de type Chrome Dino] Il parcourt son monde pour trouver l’emplacement rêvé pour son chez-soi tout en évitant chocolat et autres obstacles.
-	[Jeu de type Suika Game/ jeu de la pastèque] Il rassemble le plus de sucreries pour obtenir de bons matériaux pour la base de sa maison.
-	[BONUS] [Jeu de type stacking] Il construit sa maison brique par brique tout en faisant en sorte qu’elle soit dans plus grande et stable possible.

Chaque mini-jeu se débloque dans cet ordre après un score minimal obtenu au mini-jeu précédent. Une fois tous les mini-jeux débloqués la maison du personnage aura été construite et « l’histoire » prend fin (aperçus de sa maison et possibilité de refaire les mini-jeux pour battre les records)

// Deuxième partie : Explication du premier mini-jeu : Candy Rain //

*Concept*

Le personnage profite d’une pluie de bonbons, pour en récupérer le plus possible, afin de les utiliser plus tard pour bâtir sa future maison.

*Mécanique principale*

Le joueur se déplace de gauche à droite, sur 5 positions fixes. Il doit se positionner en dessous d’un bonbon qui tombe pour le récupérer (comme un Game and Watch, le bonbon tombe en plusieurs temps). Le but est d’en ramasser le plus possible. Si un bonbon touche le sol, la partie se termine.

*Fonctionnalités*

Le joueur a accès à un menu principal basique ainsi qu’un contexte bref avant la première partie, navigation avec des inputs Touch. Il peut insérer son nom de joueur.
Dans Candy Rain, le joueur swipe de gauche à droite pour se déplacer et se place sous une sucrerie pour la récupérer. Une sucrerie donne un point. A chaque palier de 10 points marqués, la difficulté augmente (diminution du temps d’apparition entre les bonbons puis augmentation progressive de la vitesse de chute à partir de 30 points). Lorsqu’un bonbon tombe et que sa partie prend fin, il a la possibilité de savoir si son nouveau score a battu son meilleur score et d’accéder à un tableau regroupant les 10 meilleures performances avec le nom des joueurs.

*Feeling*

Candy Rain applique la structure d’un jeu Game and Watch tout en s’adaptant au style graphique et sonore. Durant la partie, une légère musique de fond est présente pour couper le vide et coller à l’univers mais les sons de déplacement, chute de bonbons et autres ont plus d’importance et donnent le même feeling que donne un Game and Watch. Des pop-ups et animations accompagnent le son.

//Détails de conception//

L’utilisation de l’IA a été limitée. Je m’en suis servi pour des vérifications et validations de ma logique et mon développement ainsi que pour m’aider lors de mes difficultés concernant la création du tableau des high scores.
