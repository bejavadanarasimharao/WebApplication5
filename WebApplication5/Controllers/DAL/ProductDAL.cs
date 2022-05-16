using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.Controllers.DAL
{
    public class ProductDAL
    {
        string constr = ConfigurationManager.ConnectionStrings["connection"].ToString();

        public void AddProduct(Product r)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = new SqlCommand("AddProductDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId", r.ProductId);
            com.Parameters.AddWithValue("@ProductName", r.ProductName);
            com.Parameters.AddWithValue("@ProductDescription", r.ProductDescription);
            com.Parameters.AddWithValue("@CurrentPrice", r.CurrentPrice);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public List<Product> GetAllProduct()
        {
            List<Product> ProductList = new List<Product>();
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = new SqlCommand("GetProductDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                ProductList.Add(

                    new Product
                    {

                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        ProductName = Convert.ToString(dr["ProductName"]),
                        ProductDescription = Convert.ToString(dr["ProductDescription"]),
                        CurrentPrice = Convert.ToInt32(dr["CurrentPrice"])

                    }
                    );
            }

            return ProductList;
        }
        public void DeleteProductDetails(int ProductId)
        {
            
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = new SqlCommand("deleteProductDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId", ProductId);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public void UpdateProductDetails(Product obj)
        {

            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = new SqlCommand("EditProductDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductId",obj.ProductId);
            com.Parameters.AddWithValue("@ProductName",obj.ProductName);
            com.Parameters.AddWithValue("@ProductDescription",obj.ProductDescription);
            com.Parameters.AddWithValue("@CurrentPrice",obj.CurrentPrice);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
    }
}