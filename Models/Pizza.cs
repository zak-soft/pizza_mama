using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pizza_mama.Models
{
    // Une fois la classe créée avec ses éléments,
    // il faut l'associer à la base de données
    public class Pizza
    {
        // PizzaID sera l'identifiant unique de chaque pizza
        public int PizzaID { get; set; }        
        [Display(Name = "Nom")]


        public string nom { get; set; } = ""; 
        [Display(Name = "Prix ($)")]
        public float prix { get; set; }        
        [Display(Name = "Végétarienne")]

        public bool vegetarienne { get; set; }
        [Display(Name = "Ingrédients")]


        public string ingredients { get; set; } = ""; 
    }
}