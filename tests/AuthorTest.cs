using System;
using Fisher.Bookstore.Api.Models;
using Xunit;

namespace tests
{
    public class AuthorTest
    {
         [Fact] 
        public void changeID()
        {
            //Arrange
            var author= new Author()
            {
                Id = 1, 
                Name= "Tiffany Single",
                Bio = "Tiffany is engaged to a famous baseball player, and loves to write about sports"
            };

            //Act
            var newName = "Tiffany Married";
            author.ChangeName(newName);

            //Assert
            var expectedName = newName;
            var actualName = author.Name;
            
            Assert.Equal(expectedName, actualName);
        }
        
        [Fact] 
        public void UpdateBio()
        {
            //Arrange
            var author = new Author()
            {
                Id = 1, 
                Name = "Cody Green",
                Bio = "at tOSU persuing a bachelor degree in writing"
            };

            //Act
            var updatedBio = "Recieved Bachelor degree in writing from tOSU";
            author.updatedBio(updatedBio);

            //Assert
            var expectedBio = updatedBio;
            var actualBio = author.Bio;
            
            Assert.Equal(expectedBio, actualBio);

         
        }
    }

}