using Microsoft.VisualStudio.TestTools.UnitTesting;
using DRMusicCollection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRMusicCollection.Model.Tests
{
    [TestClass()]
    public class MusicTests
    {
        [TestMethod()]
        public void ValidateTitleTest()
        {
            Music music = new()
            {
                Title = "House of Rock",
                Artist = "Elvis",
                Duration = 3,
                PublicationYear = 1989
            };
            music.Validate();

            Music MusicNullTitle = new()
            {
                Title = null,
                Artist = "Frederik",
                Duration = 4,
                PublicationYear = 1990
            };
            Assert.ThrowsException<ArgumentException>(
                () => MusicNullTitle.Validate());

        }


        [TestMethod()]
        public void ValidateDuration()
        {
            Music MusicLowDuration = new()
            {
                Title = "House of Jazz",
                Artist = "Frederik",
                Duration = 5
            };
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => MusicLowDuration.Validate());

            Music MusicGoodDuration = new()
            {
                Title = "Mine store tanker",
                Artist = "Mig selv",
                Duration = 10,
                PublicationYear = 1992
            };
            MusicGoodDuration.Validate();
        }
    }
}