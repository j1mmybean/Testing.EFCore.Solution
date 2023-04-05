using ISpan.Inseparable.BLL.Core;
using ISpan.Inseparable.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.Inseparable.SqlDataLayer
{
	public class ProductRepository : IProductRepository
	{
		public IQueryable<Products> Search(int? categoryID, int? cinemaID, String productName)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			IQueryable<Products> search = InseparableDb.Products;

			if (categoryID != null) { search = search.Where(p => p.ProductCategoryId == categoryID); }
			if (cinemaID != null) { search = search.Where(p => p.CinemaID == cinemaID); }
			if (string.IsNullOrEmpty(productName) == false) { search = search.Where(p => p.ProductName.Contains(productName)); }


			return search;
		}

		public Products GrtProduct(int? productID)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			var get = InseparableDb.Products.Single(p => p.ProductId == productID);

			return get;
		}

		public void Create(ProductEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			Products p = new Products();
			p.ProductName = entity.ProductName;
			p.ProductCategoryId = (int)entity.ProductCategoryId;
			p.ProductUnitprice = (int)entity.ProductStock;
			p.CinemaID = (int)entity.CinemaID;
			p.ProductPicture = entity.ProductPicture;

			try
			{
				InseparableDb.Products.Add(p);
				InseparableDb.SaveChanges();
			}
			catch (SqlException ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Update(ProductEntity entity)
		{
			InseparableEntities InseparableDb = new InseparableEntities();

			var Edit = InseparableDb.Products.Single(p => p.ProductId == entity.ProductId);

			Edit.ProductName = entity.ProductName;
			Edit.ProductCategoryId = (int)entity.ProductCategoryId;
			Edit.ProductStock = (int)entity.ProductStock;
			Edit.CinemaID = (int)entity.CinemaID;
			Edit.ProductUnitprice = (int)entity.ProductUnitprice;

			if (entity.ProductPicture != null) Edit.ProductPicture = entity.ProductPicture;

			try
			{
				InseparableDb.SaveChanges();
			}
			catch (SqlException ex) { throw new Exception(ex.Message); }
		}

		public void Delete(int Id)
		{
			InseparableEntities InseparableDb = new InseparableEntities();

			var delete = InseparableDb.Products.SingleOrDefault(p => p.ProductId == Id);
			try
			{
				InseparableDb.Products.Remove(delete);
				InseparableDb.SaveChanges();
			}
			catch (SqlException ex) { throw new Exception(ex.Message); }
		}

		public ProductEntity GetByCinema(int cinemaId, string name)
		{
			InseparableEntities InseparableDb = new InseparableEntities();
			Products p = InseparableDb.Products.Where(pr => pr.CinemaID == cinemaId).SingleOrDefault(pr => pr.ProductName == name);

			return p == null ? null : new ProductEntity(p.ProductName, p.CinemaID, p.ProductCategoryId, p.ProductUnitprice, p.ProductStock)
			{
				ProductId = p.ProductId,
				ProductPicture = p.ProductPicture,
			};
		}
	}
}
