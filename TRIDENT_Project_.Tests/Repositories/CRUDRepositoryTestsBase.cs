﻿using Microsoft.EntityFrameworkCore;
using TRIDENT_Project.Data;
using TRIDENT_Project.Repositories;


namespace TRIDENT_Project.Tests.Repositories
{
    public abstract class CRUDRepositoryTestsBase<TEntity> where TEntity : class, new()
    {
        private StudentEnrollmentSystemContext _context;
        private CRUDRepository<TEntity, DbContext> _repository;
        protected DbSet<TEntity> _dbset;
        protected abstract void SeedData();  // For seeding data specific to each entity

        [SetUp]
        public void SetUp()
        {
            //使用 InMemory 資料庫
            var options = new DbContextOptionsBuilder<StudentEnrollmentSystemContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new StudentEnrollmentSystemContext(options);

            _dbset = _context.Set<TEntity>();
            //Seed資料
            SeedData();
            _context.SaveChanges();

            _repository = new CRUDRepository<TEntity, DbContext>(_context);
        }

        [TearDown]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }


        [Test]
        public async Task CreateAsync_WhenCalled_AddsEntityToDbSetAndSaveChanges()
        {
            //Arrange
            var entity = await _repository.FindByIdAsync(1);
            if (entity == null) throw new NullReferenceException();
            _context.Database.EnsureDeleted();
            _context.ChangeTracker.Clear();

            //Act
            await _repository.CreateAsync(entity);

            //Assert
            Assert.That(_dbset.Contains(entity), Is.True);
        }

        [Test]
        public async Task UpdateAsync_WhenCalled_UpdateToDbSetAndSaveChanges()
        {
            //Arrange
            var entity = await _repository.FindByIdAsync(1);
            if (entity == null) throw new NullReferenceException();
            
            //Act
            await _repository.UpdateAsync(entity);

            //Assert
            Assert.That(_dbset.Contains(entity), Is.True);
        }

        [Test]
        public async Task DeleteAsync_WhenCalled_DeleteEntityFromDbSet()
        {
            //Arrange
            var entity = await _repository.FindByIdAsync(1);
            if (entity == null) throw new NullReferenceException();

            //Act
            await _repository.DeleteAsync(entity);

            //Assert
        }

        [Test]
        public async Task FindByIdAsync_WhenCalled_RetrunsEntity()
        {
            //Arrange

            //Act
            var entity = await _repository.FindByIdAsync(1);

            //Assert
            Assert.That(entity, Is.Not.Null);
        }

        [Test]
        public async Task FindAsync_WhenCalled_RetrunsData()
        {
            //Arrange

            //Act
            var data = await _repository.FindAsync(x => true);

            //Assert
            Assert.That(data, Is.Not.Null);
            Assert.That(data.Count, Is.GreaterThan(0));
        }
    }
}
