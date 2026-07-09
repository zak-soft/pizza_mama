using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pizza_mama.Models
{
    // Une fois la classe créée avec ses éléments,
    // il faut l'associer à la base de données
    public class Pizza
    {
        // PizzaID sera l'identifiant unique de chaque pizza
        // quand je veux ignorer l'id dans le format json je n'ai que appliquer cela avant la variable concernée 
        [JsonIgnore]
        public int PizzaID { get; set; }        
        [Display(Name = "Nom")]


        public string nom { get; set; } = ""; 
        [Display(Name = "Prix ($)")]
        public float prix { get; set; }        
        [Display(Name = "Végétarienne")]

        public bool vegetarienne { get; set; }
        [Display(Name = "Ingrédients")]

        [JsonIgnore]
        public string ingredients { get; set; } = ""; 


        [NotMapped] //c'est a dire attention : je dis a ne surtout pas stocker dans la base de donnees 
        [JsonPropertyName("ingredients")]
        // Propriété qui retourne la liste des ingrédients sous forme de tableau
        public string[] ListeIngredients
        {
            get
            {
                // Si ingredients est null, vide, ou contient seulement des espaces,
                // on retourne un tableau vide
                if (string.IsNullOrWhiteSpace(ingredients))
                {
                    return Array.Empty<string>();
                }

                // On coupe la chaîne ingredients à chaque ", "
                // Exemple : "tomate, fromage, jambon"
                // devient : ["tomate", "fromage", "jambon"]
                return ingredients.Split(", ");
            }
        }
    }
}