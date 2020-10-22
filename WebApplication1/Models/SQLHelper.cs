using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SQLHelper
    {
        private string _connectionString;
        public SQLHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        }

        public List<Country> GetAllCountry()
        {
            List<Country> countries = null;

            countries = new List<Country>();
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("stp_GetCountry", con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Country country = new Country();
                country.Row_Id = Convert.ToInt32(reader["Row_Id"]);
                country.CountryName = reader["CountryName"].ToString();
                countries.Add(country);
            }
            return countries;
        }

        public List<State> GetAllState()
        {
            List<State> states = null;

            states = new List<State>();
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("stp_GetState", con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                State state = new State();
                state.Row_Id = Convert.ToInt32(reader["Row_Id"]);
                state.CountryId = Convert.ToInt32(reader["CountryId"]);
                state.StateName = reader["StateName"].ToString();

                states.Add(state);
            }
            return states;


        }


        public List<City> GetAllCity()
        {
            List<City> cities = null;

            cities = new List<City>();
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("stp_GetCity", con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                City city = new City();
                city.Row_Id = Convert.ToInt32(reader["Row_Id"]);
                city.StateId = Convert.ToInt32(reader["StateId"]);
                city.CityName = reader["CityName"].ToString();

                cities.Add(city);
            }
            return cities;

        }


        public void AddNeo_Test(Neo_Test neoTest)
        {

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("stp_NeoTestCreate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmailAddress", neoTest.EmailAddress);
            cmd.Parameters.AddWithValue("@CountryId", neoTest.CountryId);
            cmd.Parameters.AddWithValue("@StateId", neoTest.StateId);
            cmd.Parameters.AddWithValue("@CityId", neoTest.CityId);
            cmd.Parameters.AddWithValue("@PanNumebr", neoTest.PanNumebr);
            cmd.Parameters.AddWithValue("@PassportNumber", neoTest.PassportNumber);
            cmd.Parameters.AddWithValue("@ProfileImage", neoTest.ProfileImage);
            cmd.Parameters.AddWithValue("@Gender", neoTest.Gender);
            cmd.Parameters.AddWithValue("@IsActive ", neoTest.@IsActive);
            con.Open();
            cmd.ExecuteNonQuery().ToString();
            con.Close();

        }


        public List<Neo_Test> GetAllNeosoftData()
        {
            List<Neo_Test> neosoft = null;

            neosoft = new List<Neo_Test>();
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("stp_GetAllNeoTest", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Neo_Test neo = new Neo_Test();
                neo.EmailAddress = reader["EmailAddress"].ToString();
                neo.CountryId = Convert.ToInt32(reader["CountryId"]);
                neo.Country = new Country() {
                    Row_Id = Convert.ToInt32(reader["CountryId"]),
                    CountryName = reader["CountryName"].ToString()
                };
                neo.StateId = Convert.ToInt32(reader["StateId"]);
                neo.State = new State()
                {
                    Row_Id = Convert.ToInt32(reader["StateId"]),
                    StateName = reader["StateName"].ToString()
                };

                neo.CityId = Convert.ToInt32(reader["CityId"]);
                neo.City = new City()
                {
                    Row_Id = Convert.ToInt32(reader["CityId"]),
                    CityName = reader["CityName"].ToString()
                };
                neo.PanNumebr= reader["PanNumebr"].ToString();
                neo.PassportNumber= reader["PassportNumber"].ToString();
                neo.ProfileImage= reader["ProfileImage"].ToString();
                neo.Gender = reader["Gender"].ToString();
                neo.IsActive = Convert.ToBoolean(reader["IsActive"]);
                neosoft.Add(neo);
            }
            return neosoft;
        }
    }
}