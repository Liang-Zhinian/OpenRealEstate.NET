﻿using System;
using OpenRealEstate.Core.Models;
using Shouldly;
using Xunit;

namespace OpenRealEstate.Tests.Models
{
    public class AggregateRootTests
    {
        public class CopyTests
        {
            [Fact]
            public void GivenAnExistingListing_Copy_CopiesOverTheData()
            {
                // Arrange.
                var sourceListing =TestHelperUtilities.ResidentialListingFromFile(false) as AggregateRoot;
                sourceListing.Id = "2140F1E6-EF8B-45D4-82FB-90940A3F1D90";
                sourceListing.UpdatedOn = DateTime.UtcNow;

                var destinationListing = TestHelperUtilities.ResidentialListingFromFile() as AggregateRoot;

                // Act.
                destinationListing.Copy(sourceListing);

                // Assert.
                destinationListing.Id.ShouldBe(sourceListing.Id);
                destinationListing.UpdatedOn.ShouldBe(sourceListing.UpdatedOn);
            }
        }
    }
}