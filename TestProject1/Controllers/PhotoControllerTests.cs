using System.Collections.Generic;
using System.Threading.Tasks;
using ASPPROJEKT.Controllers;
using ASPPROJEKT.Services;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class PhotoControllerTests
{
    private readonly Mock<PhotoService> _mockPhotoService;
    private readonly PhotoController _controller;

    public PhotoControllerTests()
    {
        // Mock dependencies and instantiate the controller
        _mockPhotoService = new Mock<PhotoService>(/* provide required dependencies */);
        _controller = new PhotoController(_mockPhotoService.Object);

        // Ensure that a photo with photoId exists in the mock service
        SeedTestData();
    }

    private void SeedTestData()
    {
        // Seed test data, including a photo with the specified photoId
        var photoId = 1;
        var testPhoto = new PhotoEntity { PhotoId = photoId, /* other properties */ };

        // Set up the behavior of the mock service to return the test photo
        _mockPhotoService.Setup(service => service.GetPhotoDetailsAsync(photoId))
            .ReturnsAsync(testPhoto);
    }

    [Fact]
    public async Task Index_ReturnsViewResultWithPhotos()
    {
        // Arrange
        _mockPhotoService.Setup(service => service.GetAllPhotosAsync())
            .ReturnsAsync(new List<PhotoEntity> { new PhotoEntity() });

        // Act
        var result = await _controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<PhotoEntity>>(viewResult.ViewData.Model);
        Assert.Single(model);
    }

    [Fact]
    public async Task Create_ValidModelState_ReturnsRedirectToIndex()
    {
        // Arrange
        var photoModel = new PhotoEntity { /* set properties */ };

        // Act
        var result = await _controller.Create(photoModel);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
        _mockPhotoService.Verify(service => service.CreatePhotoAsync(photoModel), Times.Once);
    }

    [Fact]
    public async Task Create_InvalidModelState_ReturnsViewResult()
    {
        // Arrange
        _controller.ModelState.AddModelError("error", "some error");
        var invalidPhotoModel = new PhotoEntity { /* set properties */ };

        // Act
        var result = await _controller.Create(invalidPhotoModel);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(invalidPhotoModel, viewResult.ViewData.Model);
        _mockPhotoService.Verify(service => service.CreatePhotoAsync(It.IsAny<PhotoEntity>()), Times.Never);
    }

    [Fact]
    public async Task Update_ValidModelState_ReturnsRedirectToIndex()
    {
        // Arrange
        var photoModel = new PhotoEntity { /* set properties */ };

        // Act
        var result = await _controller.Update(photoModel);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
        _mockPhotoService.Verify(service => service.UpdatePhotoAsync(photoModel), Times.Once);
    }

    [Fact]
    public async Task Update_InvalidModelState_ReturnsViewResult()
    {
        // Arrange
        _controller.ModelState.AddModelError("error", "some error");
        var invalidPhotoModel = new PhotoEntity { /* set properties */ };

        // Act
        var result = await _controller.Update(invalidPhotoModel);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Equal(invalidPhotoModel, viewResult.ViewData.Model);
        _mockPhotoService.Verify(service => service.UpdatePhotoAsync(It.IsAny<PhotoEntity>()), Times.Never);
    }

    [Fact]
    public async Task Delete_ReturnsRedirectToIndex()
    {
        // Arrange
        var photoId = 1;

        // Act
        var result = await _controller.Delete(photoId);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
        _mockPhotoService.Verify(service => service.DeletePhotoAsync(photoId), Times.Once);
    }
}
