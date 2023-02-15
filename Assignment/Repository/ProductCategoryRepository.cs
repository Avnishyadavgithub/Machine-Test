using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Assignment.Models;

namespace Assignment.Repository
{
    public class ProductCategoryRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["Connection"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details    
        public bool AddUpdateCategory(string CategoryName, int CategoryID, string Method)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("usp_InsertCategoryMaster", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@CategoryName", CategoryName);
                com.Parameters.AddWithValue("@CategoryID", CategoryID);
                com.Parameters.AddWithValue("@Method", Method);


                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    
                }
            }
            catch(Exception ex)
            {

            }

            return false;


        }


        public bool AddUpdateProduct(int ProductID, string ProductName, int CategoryID, string Method)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("usp_InsertProductMaster", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProductID", ProductID);
                com.Parameters.AddWithValue("@ProductName", ProductName);
                com.Parameters.AddWithValue("@CategoryID", CategoryID);
                com.Parameters.AddWithValue("@Method", Method);


                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {


                }
            }
            catch (Exception ex)
            {

            }

            return false;


        }

        public List<Category> GetAllCategory()
        {
            connection();
            List<Category> CategoryList = new List<Category>();


            SqlCommand com = new SqlCommand("usp_getCategoryMaster", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                CategoryList.Add(

                    new Category
                    {

                        Category_id = Convert.ToInt32(dr["Category_id"]),
                        Category_name = Convert.ToString(dr["Category_name"])
                       

                    }
                    );
            }

            return CategoryList;
        }


        public List<Product> GetAllProduct()
        {
            connection();
            List<Product> ProductList = new List<Product>();


            SqlCommand com = new SqlCommand("usp_getProductMaster", con);
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

                        Product_id = Convert.ToInt32(dr["Product_id"]),
                        Product_name = Convert.ToString(dr["Product_name"]),
                         Category_id = Convert.ToInt32(dr["Category_id"]),
                        Category_name = Convert.ToString(dr["Category_name"])


                    }
                    );
            }

            return ProductList;
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("usp_DeleteCategoryMaster", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
              


                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {


                }
            }
            catch (Exception ex)
            {

            }

            return false;


        }

        public bool DeleteProduct(int id)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("usp_DeleteProductMaster", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);



                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {


                }
            }
            catch (Exception ex)
            {

            }

            return false;


        }

    }
}