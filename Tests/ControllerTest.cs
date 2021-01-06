using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Moq;
using ImotiWebsite.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ImotiWebsite.Controllers;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ImotiWebsite.Database;

namespace Tests
{
    public class ControllerTest
    {
        [Fact]
        public void Get_AdsInfo_Correct()
        {
            // Setup
            var ctxMock = new Mock<IRealEstateContext>();
            IEnumerable<Ad> ads = GetAds();
            DbSet<Ad> set = ads.ToDbSet();
            ctxMock.Setup(x => x.Ads).Returns(set);

            var controller = new AdsInfoController(null, ctxMock.Object);
            IEnumerable<Ad> returnedAds = controller.Get();

            Assert.Equal(ads.Count(), returnedAds.Count());
        }
        public IEnumerable<Ad> GetAds()
        {
            return new List<Ad>()
            {
                new Ad{Size = 15},
                new Ad{Size = 14}
            };
        }
    }
}
