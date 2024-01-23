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

public class AppDbContextFactory
{
    public static AppDbContext Create()
    {
        var dbContext = new AppDbContext();
        // Additional configuration or setup if needed
        return dbContext;
    }
}
public class PhotoControllerTests
{

    [Fact]
    public async Task Index_ReturnsViewResultWithPhotos()
    {
        // Arrange
        var dbContext = AppDbContextFactory.Create();
        var photoService = new PhotoService(dbContext);
        var controller = new PhotoController(photoService);

        // Act
        var result = await controller.Index();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public async Task PagedIndex_ReturnsViewResult()
    {
        // Arrange
        var photoServiceMock = new Mock<PhotoService>();
        var controller = new PhotoController(photoServiceMock.Object);

        // Act
        var result = await controller.PagedIndex();

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public async Task PagedFilteredIndex_ReturnsViewResult()
    {
        // Arrange
        var photoServiceMock = new Mock<PhotoService>();
        var controller = new PhotoController(photoServiceMock.Object);

        // Act
        var result = await controller.PagedFilteredIndex(filter: "exampleFilter");

        // Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public async Task Index_ReturnsViewResultWithPhotos2()
    {
        // Arrange
        var dbContext = AppDbContextFactory.Create(); // Assuming you have a factory to create AppDbContext
        var photoService = new PhotoService(dbContext);
        var controller = new PhotoController(photoService);

        // Act
        var result = await controller.Index();

        // Assert
        Assert.IsType<ViewResult>(result);
        // Add additional assertions as needed

        // For example, you might want to assert that the model is of type List<PhotoEntity>
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<PhotoEntity>>(viewResult.Model);
        // Add more specific assertions based on your controller's behavior
    }

    [Fact]
    public async Task Details_ReturnsNotFound_WhenIdIsNull()
    {
        // Arrange
        var photoServiceMock = new Mock<PhotoService>();
        var controller = new PhotoController(photoServiceMock.Object);

        // Act
        var result = await controller.Details(id: null);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Details_ReturnsViewResult_WhenPhotoIsFound()
    {
        // Arrange
        var photoServiceMock = new Mock<PhotoService>(MockBehavior.Strict);
        photoServiceMock.Setup(service => service.GetPhotoDetailsAsync(It.IsAny<int>()))
            .ReturnsAsync(new PhotoEntity()); // Provide a sample photo
        var controller = new PhotoController(photoServiceMock.Object);

        // Act
        var result = await controller.Details(id: 1);

        // Assert
        Assert.IsType<ViewResult>(result);
    }
}
