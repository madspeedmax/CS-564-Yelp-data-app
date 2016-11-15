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

                #region city 1
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

                double calc1 = 0;
                if (cmd.Parameters["@score"].Value != System.DBNull.Value)
                {
                    calc1 = Math.Round((double)cmd.Parameters["@score"].Value, 2);

                }

                model.RankResults.Add(new BusinessRankResult()
                {
                    Category = model.Category,
                    City = model.City,
                    State = model.State,
                    Score = calc1
            });
                #endregion

                #region city 2
                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "citycategoryscore";
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@cat", model.Category);
                cmd2.Parameters["@cat"].Direction = ParameterDirection.Input;

                cmd2.Parameters.AddWithValue("@city", model.City2);
                cmd2.Parameters["@city"].Direction = ParameterDirection.Input;

                cmd2.Parameters.AddWithValue("@state", model.State2);
                cmd2.Parameters["@state"].Direction = ParameterDirection.Input;

                cmd2.Parameters.Add("@score", MySqlDbType.Double);
                cmd2.Parameters["@score"].Direction = ParameterDirection.Output;

                cmd2.ExecuteNonQuery();

                double calc2 = 0;
                if (cmd2.Parameters["@score"].Value != System.DBNull.Value)
                {
                    calc2 = Math.Round((double)cmd2.Parameters["@score"].Value, 2);

                }

                model.RankResults.Add(new BusinessRankResult()
                {
                    Category = model.Category,
                    City = model.City2,
                    State = model.State2,
                    Score = calc2
                });
                #endregion
            }
            return View(model);
        }
    }
}