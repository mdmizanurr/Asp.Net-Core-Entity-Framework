﻿using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SportsStore.Tests
{
    public class ProductControllerTest
    {
        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            //Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product{ProductID = 1, Name = "P1"},
                new Product{ProductID = 2, Name = "P2"},
                new Product{ProductID = 3, Name = "P3"},
                new Product{ProductID = 4, Name = "P4"},
                new Product{ProductID = 5, Name = "P5"}
            }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3 ;

            //Act
            
            ProductListViewModel result = controller.List(null, 2).ViewData.Model 
                as ProductListViewModel;

            //Assert
            Product[] prodArray = result.Products.ToArray();
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);




        }
    }
}
