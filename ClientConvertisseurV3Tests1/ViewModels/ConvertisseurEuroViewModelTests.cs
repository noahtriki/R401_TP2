using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV3.Models;

namespace ClientConvertisseurV3.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurEuroViewModelTests
    {
        /// <summary>
        /// Test constructeur.
        /// </summary>
        [TestMethod()]
        public void ConvertisseurEuroViewModelTest()
        {
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            Assert.IsNotNull(convertisseurEuro);
        }
        /// <summary>
        /// Test GetDataOnLoadAsyncTest OK
        /// </summary>
        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            //Act
            convertisseurEuro.GetDataOnLoadAsync();
            Thread.Sleep(1000);
            //Assert
            Assert.IsNotNull(convertisseurEuro.LesDevises);
        }
        /// <summary>
        /// /// Test conversion OK
        /// </summary>
        [TestMethod()]
        public void ActionSetConversionTest()
        {
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            //Création d'un objet de type ConvertisseurEuroViewModel
            //Property MontantEuro = 100 (par exemple)
            convertisseurEuro.Montant = 100;
            //Création d'un objet Devise, dont Taux=1.07
            Devise ladevise = new Devise(4, "Zouble", 1.07);
            //Property DeviseSelectionnee = objet Devise instancié
            convertisseurEuro.SelectedDevise= ladevise;
            //Act
            //Appel de la méthode ActionSetConversion
            convertisseurEuro.ActionSetConversion();
            //Assert
            //Assertion : MontantDevise est égal à la valeur espérée 107
            Assert.AreEqual(107, convertisseurEuro.Resultat, "Resultat doit etre = 107");
        }
    }
}