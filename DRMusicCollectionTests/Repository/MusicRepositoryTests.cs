using Microsoft.VisualStudio.TestTools.UnitTesting;
using DRMusicCollection.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRMusicCollection.Model;

namespace DRMusicCollection.Repository.Tests
{
    [TestClass()]
    public class MusicRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            // Arrange: Initializes the BeersRepository to test the GetBeers functionality
            var repo = new MusicRepository();

            // Act: Calls the GetBeers method to get all beers
            var result = repo.GetAll();

            // Assert: Checks if the result contains the expected number of beer entries
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var repo = new MusicRepository();
            var expectedMusicId = 1; // The ID of the beer to retrieve

            // Act: Calls GetById with the expectedBeerId
            var result = repo.GetById(expectedMusicId);

            // Assert: Verifies the retrieved beer has the correct ID
            Assert.IsNotNull(result); // Ensures a beer was returned
            Assert.AreEqual(expectedMusicId, result.Id);
        }
        [TestMethod()]
        public void AddTest()
        {
            // Arrange: Setup with a new BeersRepository and a new Beer object
            var repo = new MusicRepository();
            var newArtist = new Music { Title = "House of cards", Artist = "New Test Artist", Duration = 5, PublicationYear = 2020 };

            // Act: Adds the new beer and retrieves all beers to check if it was added
            var result = repo.Add(newArtist);
            var allMusics = repo.GetAll();

            // Assert: Verifies the new beer was added successfully
            Assert.IsNotNull(result); // Ensures a result was returned
            Assert.AreEqual(5, allMusics.Count); // Checks if the total number of beers increased by one
            Assert.IsTrue(allMusics.Any(b => b.Artist == "New Test Artist")); // Verifies the new beer is in the collection        }

        }
        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange: Initializes the repository and specifies the ID of the beer to delete
            var repo = new MusicRepository();
            var musicTitleToDelete = "House of Rock";

            // Act: Deletes the beer and then retrieves all beers to verify deletion
            var result = repo.Delete(musicTitleToDelete);
            var allMusics = repo.GetAll();

            // Assert: Confirms the beer was deleted
            Assert.IsNotNull(result); // Ensures a beer was returned from the delete operation
            Assert.AreEqual(4, allMusics.Count); // Checks if the total number of beers decreased
            Assert.IsFalse(allMusics.Any(b => b.Title == musicTitleToDelete));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            // Arrange
            var repo = new MusicRepository();
            var originalMusicTitle = "House of Rock";
            var updatedData = new Music { Title = originalMusicTitle, Artist = "Frederik", Duration = 5, PublicationYear = 1998 };

            // Act
            var result = repo.Update(1, updatedData);  // Ensure this method should return something meaningful, like a boolean
            var updatedMusic = repo.GetById(1);  // Retrieving using the original title

            // Assert
            Assert.IsNotNull(result); // Check result is not null or true/false
            Assert.IsNotNull(updatedMusic);
            Assert.AreEqual("Frederik", updatedMusic.Artist, "Artist name did not update correctly.");
            Assert.AreEqual(5, updatedMusic.Duration, "Duration did not update correctly.");
            Assert.AreEqual(1998, updatedMusic.PublicationYear, "Publication year did not update correctly.");
        }
    }
}