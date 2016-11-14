using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelpApp.Models;

namespace YelpApp.Controllers
{
    public class BusinessRankController : BaseController
    {
        // GET: BusinessRank
        public ActionResult Index(BusinessRank model)
        {
            if (!string.IsNullOrEmpty(model.SearchButton))
            {
                model.RankResults = new List<BusinessRankResult>();

                //var categoryParameter = new MySqlParameter("@cat", model.Category);
                //categoryParameter.Direction = System.Data.ParameterDirection.Input;
                //var cityParameter = new MySqlParameter("@city", model.City);
                //cityParameter.Direction = System.Data.ParameterDirection.Input;
                //var stateParameter = new MySqlParameter("@state", model.State);
                //stateParameter.Direction = System.Data.ParameterDirection.Input;
                //var scoreParameter = new MySqlParameter("@score", 0);
                //scoreParameter.Direction = System.Data.ParameterDirection.Output;
                //var sql = @"call citycategoryscore(@cat, @city, @state, @score)";
                //db.Database.ExecuteSqlCommand(sql, categoryParameter, cityParameter, stateParameter, scoreParameter);

                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection conn = new MySqlConnection(db.Database.Connection.ConnectionString);
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "citycategoryscore";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cat", model.Category);
                cmd.Parameters["@cat"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@city", model.City);
                cmd.Parameters["@city"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@state", model.State);
                cmd.Parameters["@state"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@score", MySqlDbType.Double);
                cmd.Parameters["@score"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                double calc = 0;
                if (cmd.Parameters["@score"].Value != System.DBNull.Value)
                {
                    calc = Math.Round((double)cmd.Parameters["@score"].Value, 2);

                }

                model.RankResults.Add(new BusinessRankResult()
                {
                    Category = model.Category,
                    City = model.City,
                    State = model.State,
                    Score = calc
            });

            }
            return View(model);
        }
    }
}