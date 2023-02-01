﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV1.Models
{
    public class Devise
    {
        private int id;
        private string? nomDevise;
        private double taux;
        public Devise()
        {

        }

        public Devise(int id, string nomDevise, double taux)
        {
            Id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }

        public double Taux
        {
            get { return taux; }
            set { taux = value; }
        }

        [Required]
        public string? NomDevise
        {
            get { return nomDevise; }
            set { nomDevise = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


    }
}
