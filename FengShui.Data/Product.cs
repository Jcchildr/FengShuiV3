﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public Guid AdminId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Brandname { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public int Width { get; set; }
        //Combine the Dimensions into a single line of Data
        public string Dimension
        {
            get
            {
                return Length + " X " + Width + " X " + Height;
            }
        }
        [Required]
        public int NumberInStock { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }


        //Allows one to view all the Adjectives of a product (Many to many)
        public virtual ICollection<Ambience> ListOfAmbiences { get; set; }

        public Product()
        {
            ListOfAmbiences = new HashSet<Ambience>();
        }

        //One to many relationship with ItemCategory
        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

        //Allows the user to select a HomeLocation from a list 
        public HomeLocationEnum HomeLocation { get; set; }

        //Allows the user to select a Color from a list
        public ColorEnum PrimaryColor { get; set; }
        public ColorEnum ?SecondaryColor {get; set;} 
    }

    //List of HomeLocations
    public enum HomeLocationEnum
    {
        [Display(Name = "Living Room")]
        LivingRoom,
        [Display(Name = "Dining Room & Kitchen")]
        DiningAndKitchen,
        Bedroom,
        [Display(Name = "Home Office/Study")]
        HomeOffice,
        Garage,
        [Display(Name = "Outdoor & Garden")]
        OutdoorAndGarden,
        [Display(Name = "Home Gym")]
        HomeGym,
        Bathroom,
        [Display(Name = "Decor, Rugs and Lighting")]
        GeneralDecor,
    }

    //List of Colors
    public enum ColorEnum
    {
        Red,
        Yellow,
        Blue,
        Green,
        Purple,
        Orange,
    }
}