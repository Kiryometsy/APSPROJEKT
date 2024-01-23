using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using ASPPROJEKT.Services;
using Data;
using Data.Entities;

public class PhotoServiceTests : IDisposable
{
    private readonly DbContextOptions<AppDbContext> _options;
    private readonly AppDbContext _context;

    public PhotoServiceTests()
    {
        _context = new AppDbContext(); // Use the parameterless constructor
        SeedTestData();
    }

    private void SeedTestData()
    {
        // Seed test data as needed for your tests
        _context.Database.EnsureCreated();

        // Example: _context.Photos.Add(new PhotoEntity { ... });
        // Ensure to save changes
        _context.SaveChanges();
    }

    [Fact]
    public async Task GetAllPhotosAsync_ReturnsAllPhotos()
    {
        // Arrange
        var service = new PhotoService(_context);

        // Act
        var result = await service.GetAllPhotosAsync();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<PhotoEntity>>(result);
        // Add more assertions based on your specific implementation
    }

    // Add more test methods for other methods in PhotoService
    [Fact]
    public async Task GetPhotoDetailsAsync_ShouldReturnPhotoDetails()
    {
        // Arrange
        var photoId = 1;

        var photo = new PhotoEntity
        {
            PhotoId = photoId,
            // Set other properties as needed
        };

        var author = new AuthorEntity
        {
            Name = "Test",
            // Set other properties as needed
        };

        // Set the entire Author navigation property instead of AuthorId
        photo.Author = author;

        _context.Photos.Add(photo);
        _context.Authors.Add(author);
        _context.SaveChanges();

        var service = new PhotoService(_context);

        // Act
        var result = await service.GetPhotoDetailsAsync(photoId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(photoId, result.PhotoId);
        Assert.NotNull(result.Author);

        // Ensure that Author.Id is not null and is greater than 0
        Assert.NotNull(result.Author.Id);
        Assert.True(result.Author.Id > 0);
    }




    [Fact]
    public async Task FindAllAuthorsForViewModel_ReturnsAllAuthors()
    {
        // Arrange
        var service = new PhotoService(_context);

        // Act
        var result = await service.FindAllAuthorsForViewModel();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<AuthorEntity>>(result);
        // Add more assertions based on your specific implementation
    }

    [Fact]
    public async Task CreatePhotoAsync_AddsNewPhotoToDatabase()
    {
        // Arrange
        var service = new PhotoService(_context);
        var newPhoto = new PhotoEntity
        {
            // Provide necessary properties for the new photo
        };

        // Act
        await service.CreatePhotoAsync(newPhoto);

        // Assert
        var createdPhoto = await _context.Photos.FindAsync(newPhoto.PhotoId);
        Assert.NotNull(createdPhoto);
        // Add more assertions based on your specific implementation
        Assert.Equal(newPhoto.Description, createdPhoto.Description);
    }

    [Fact]
    public async Task UpdatePhotoAsync_UpdatesExistingPhotoInDatabase()
    {
        // Arrange
        var service = new PhotoService(_context);

        // Seed an existing photo
        var existingPhoto = new PhotoEntity
        {
            // Provide necessary properties for the existing photo
        };

        await service.CreatePhotoAsync(existingPhoto);

        // Modify the existing photo
        existingPhoto.Description = "Updated Description";

        // Act
        await service.UpdatePhotoAsync(existingPhoto);

        // Assert
        var updatedPhotoFromDb = await _context.Photos.FindAsync(existingPhoto.PhotoId);
        Assert.NotNull(updatedPhotoFromDb);
        // Add more assertions based on your specific implementation
        Assert.Equal(existingPhoto.Description, updatedPhotoFromDb.Description);
    }

    [Fact]
    public async Task DeletePhotoAsync_RemovesPhotoFromDatabase()
    {
        // Arrange
        var service = new PhotoService(_context);
        var photoIdToDelete = 1; // Provide a valid photoId based on your seeded data

        // Act
        await service.DeletePhotoAsync(photoIdToDelete);

        // Assert
        var deletedPhoto = await _context.Photos.FindAsync(photoIdToDelete);
        Assert.Null(deletedPhoto);
        // Add more assertions based on your specific implementation
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
