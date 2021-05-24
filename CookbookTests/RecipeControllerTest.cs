using Cookbook.Controllers.UseCases;
using Cookbook.Models;
using Cookbook.Patterns.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookbookTests
{
    [TestClass]
    public class RecipeControllerTest
    {
        [TestMethod]
        public void TestClassGetUseCase_Execute_CollectionRecipesExpected()
        {
            // Arrange
            TestDB testDB = new TestDB();
            IUnitOfWork testUnitOfWork = new TestUnitOfWork<TestDB>(testDB);
            GetUseCase testGetUseCase = new GetUseCase(testUnitOfWork);

            // Act
            var actual = testGetUseCase.Execute();

            // Assert
            Assert.IsTrue(actual.Any());
        }
        [TestMethod]
        public void TestClassGetUseCase_Execute_CorrectGetRecipeExpected()
        {
            // Arrange
            TestDB testDB = new TestDB();
            IUnitOfWork testUnitOfWork = new TestUnitOfWork<TestDB>(testDB);
            GetUseCase testGetUseCase = new GetUseCase(testUnitOfWork);
            Recipe expectedRecipe = testGetUseCase.Execute()[0];

            // Act
            Recipe actual = testGetUseCase.Execute(1);

            // Assert
            Assert.AreEqual(expectedRecipe, actual);
        }
        [TestMethod]
        public void TestClassPostUseCase_Execute_CorrectPostRecipeExpected()
        {
            // Arrange
            TestDB testDB = new TestDB();
            IUnitOfWork testUnitOfWork = new TestUnitOfWork<TestDB>(testDB);
            PostUseCase testPostUseCase = new PostUseCase(testUnitOfWork);
            GetUseCase testGetUseCase = new GetUseCase(testUnitOfWork);
            Recipe testRecipe = new Recipe() { Id = 10, name = "Orange", date = DateTime.Now, description = "Orange description", ChildRecipes = new List<Recipe>() };

            // Act
            testPostUseCase.Execute(testRecipe);
            List<Recipe> actualList = testGetUseCase.Execute();
            Recipe actual = testGetUseCase.Execute(10);

            // Assert
            Assert.AreEqual(testDB.Recipes.Count, actualList.Count);
            Assert.AreEqual(actual, testRecipe);
        }
        [TestMethod]
        public void TestClassPutUseCase_Execute_CorrectPutRecipeExpected()
        {
            // Arrange
            TestDB testDB = new TestDB();
            IUnitOfWork testUnitOfWork = new TestUnitOfWork<TestDB>(testDB);
            GetUseCase testGetUseCase = new GetUseCase(testUnitOfWork);
            PutUseCase TestPutUseCase = new PutUseCase(testUnitOfWork);
            Recipe testRecipe = testGetUseCase.Execute(9);
            testRecipe.name = "Orange";
            testRecipe.description = "Orange description";

            // Act
            TestPutUseCase.Execute(testRecipe);
            Recipe actual = testGetUseCase.Execute(9);

            // Assert
            Assert.AreEqual(actual, testRecipe);
        }
        [TestMethod]
        public void TestClassDeleteUseCase_Execute_CorrectDeleteRecipeExpected()
        {
            // Arrange
            TestDB testDB = new TestDB();
            IUnitOfWork testUnitOfWork = new TestUnitOfWork<TestDB>(testDB);
            PostUseCase testPostUseCase = new PostUseCase(testUnitOfWork);
            GetUseCase testGetUseCase = new GetUseCase(testUnitOfWork);
            DeleteUseCase TestDeleteUseCase = new DeleteUseCase(testUnitOfWork);
            Recipe testRecipe = new Recipe() { Id = 11, name = "Plum", date = DateTime.Now, description = "Plum description", ChildRecipes = new List<Recipe>() };
            List<Recipe> testRecipes = testGetUseCase.Execute();

            // Act
            testPostUseCase.Execute(testRecipe);
            bool beforeDelete = testRecipes.Any(x => x.Id == 11);
            TestDeleteUseCase.Execute(11);
            bool afterDelete = testRecipes.Any(x => x.Id == 11);

            // Assert
            Assert.IsTrue(beforeDelete);
            Assert.IsFalse(afterDelete);
        }
    }
}