// Remplacez par votre clé API
const apikey = "da6153fa7589cdd5ae0121501c4193b4";

// Ville pour laquelle vous voulez obtenir la météo
const city = "Lille";

// URL de l'API OpenWeatherMap pour obtenir les données de la météo
const url = `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apikey}&units=metric`;

// Utilisation de fetch pour obtenir les données de l'API
fetch(url)
  .then(response => {
    if (!response.ok) {
      throw new Error("Erreur lors de la récupération des données");
    }
    return response.json(); // Parse les données JSON
  })
  .then(data => {
    // Obtenir la température actuelle
    const temperature = data.main.temp;

    // Afficher la température dans la console
    console.log(`La température actuelle à ${city} est de ${temperature}°C`);
  })
  .catch(error => {
    console.error("Erreur:", error.message); // Gérer les erreurs
  });
