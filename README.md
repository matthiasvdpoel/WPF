
# WPF
Dit is een WPF applicatie in C# en maakt gebruik van .NET framework. De databasecommunicatie verloopt via Dapper.net.
Aangezien de gebruikte database voor dit project niet meer bestaat, lukt het niet om de applicatie te runnen. 
Met visualstudio kunnen alle schermen (zonder data) toch bekeken worden.

Het hele project is geschreven volgens het MVVM design pattern.
Navigatie tussen de verschillende pagina's wordt geregeld door PageNavigationService.cs in Model.
Data wordt tussen de verschillende pagina's gedeeld via een Messenger klasse.
Alle vieuws worden dynamisch opgebouwd via databinding naar de overeenkomstige klasse in ViewModel.

## Opschrijving: 
In deze applicatie kan de gebruiker een account aanmaken en inloggen om cambio en lime te reserveren als deze zich in Geel zouden bevinden. Deze combinatie van Lime en Cambio komt voort uit een paper die ik in teamverband in mijn vorige opleiding heb geschreven. In de paper werd een oplossing gezocht op het falend succes van Cambio. De oplossing die uit de bus kwam was een samenwerking met een deelstep organisatie om zo de toegankelijkheid van de cambio staanplaatsen te vergroten. 
De app maakt gebruik van een consistente stijl van material design. De illustraties die doorheen de app verspreid zijn behoren tot Cambio zelf.

### SplashScreen:
Zichtbaar voor 3 seconden. Daarna wordt het login scherm getoond.
LogIn
Hier kan de gebuiker inloggen met zijn gebruikersnaam en wachtwoord. De texboxen maken gebruik van de hint assist van material design. 
Er zijn 3 knoppen:
* Registreren: Naar registreren scherm
* Login: Als de login correct is, naar dashboard. De overeenkomstige gebruiker wordt meegegeven.
* Forget Password: Deze knop heeft in deze applicatie geen functionaliteit.

### Register
 In dit scherm kan de gebruiker zijn account aanmaken. 
Knop registreren: foute registratie = shakeanimation van de knop. Als de registratie juist is wordt de gebruiker in de database toegevoegd en het login scherm wordt getoond.
Knop terug: terug naar login scherm.
Dashboard
Voornaam en naam worden getoond in de welkomstboodschap. 
In dit scherm ziet de gebruiker zijn huidige punten en een kaart met de Cambio en Lime staanplaatsen in Geel. De kaart kan verplaatst worden en er kan ingezoomd worden. De kaart is gelinkt aan mijn microsoft developer account. 
Er zijn verschillende knoppen:
* Boeken: De gebruiker gaat naar het scherm om een boeking te doen (currentuser wordt doorgegeven)
* Community: De gebruiker krijgt het scherm met overzicht van de huidige ranking te zien. (currentuser wordt doorgegeven)
* Mijn Profiel:  De gebruiker ziet het scherm om zijn profiel aan te passen. (currentuser wordt doorgegeven)

* Loguit knop: Deze knop dient om zich af te melden. Na de klik komt de gebruiker op de login pagina.


### Boeking
In dit scherm kan de gebruiker een boeking maken. De interactieve kaart uit het dashboard is terug zichtbaar, echter nu zal de kaart reageren als er een locatie wordt geselecteerd uit de listview. De kaart zal inzoomen en verplaatsen naar de overeenkomstige locatie. 
De gebruiker kiest een datum en tijd voor het ophalen en afleveren van de step of auto. Dit gebeurt in de datpicker en de timepicker van materialdesign. Bij het laden van de pagina worden datum en tijd op het huidige moment gezet.
De knoppen:
* terug: De gebruiker gaat terug (currentuser wordt doorgegeven)
* Mijn boekingen: De gebruiker ziet een overzicht van zijn boekingen. (currentuser wordt doorgegeven)
* Boeken: Er wordt een dialog window geopend met een overzicht van de boeking. Hier kan de gebruiker de gegevens nakijken. Nadat de gebruiker op de sluit knop drukt komt de gebruiker op het scherm met overzicht van al zijn boekingen. Hiervoor wordt via messenger een custom message gestuurd naar het mainwindow.  De Boeken knop werkt pas als er een Locatie is geselecteerd. De punten van de gebruiker worden geüpdatet in de databank.

### BoekingOverzicht
De boekingen met overeenkomstig userId worden geladen in de listview. Nadat de gebruiker een selectie maakt kan deze verwijderd worden door de knop met vuilbak. Vervolgens wordt de lijst herladen. 
De home knop brengt de gebruiker terug naar het Dashboard.
Community
Hier kan de gebruiker de huidige ranking zien op basis van de punten. De lijst wordt geladen met de voor- en achternaam en het aantal punten van de gebruikers. De lijst wordt automatisch van groot naar klein gesorteerd. 
Terug knop gaat terug naar het dashboard (currentuser wordt doorgegeven)

### Mijn Profiel
De gebruiker ziet een gelijkaardig scherm als bij het registreren. Nu zijn de gegevens van de gebruiker echter al ingevuld. Als een waarde volledig verwijderd wordt ziet de gebruiker de materialdesign hint assist in de textbox. De update knop zal de gebruiker updaten. Vervolgens komt de gebruiker terug op het dashboard. De aangepaste gebruiker wordt doorgegeven. De terug knop brengt de gebruiker ook naar het dashboard (currentuser wordt doorgegeven)


![image](https://i.ibb.co/k5P7j2p/image1.png)
![image](https://i.ibb.co/S5jb0qw/image2.png)
![image](https://i.ibb.co/MZKGkbB/image3.png)
![image](https://i.ibb.co/yfxzFPZ/image4.png)
![image](https://i.ibb.co/ZdFmnrB/image5.png)
![image](https://i.ibb.co/28cG1r2/image6.png)
![image](https://i.ibb.co/fG4GQBq/image7.png)
![image](https://i.ibb.co/mDZWQQw/image8.png)
![image](https://i.ibb.co/wctcV4H/image9.png)
![image](https://i.ibb.co/MD9QvYz/image10.png)
