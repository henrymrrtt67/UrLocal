﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;

namespace UrLocal
{
    public class UrLocalDB
    {
        public NpgsqlConnection connect()
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id=henrymrrtt;" +
                "Password=Ories-10;Database=postgres;");
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connected chief.");
                }
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool add_user(string username, string password, int craft_slide, int complexity,
        int wineOrBeer, int wineCheck, int beerCheck, int spiritCheck, double priceRange)
        {
            try
            {
                NpgsqlConnection conn = connect();
                NpgsqlCommand query =
                new NpgsqlCommand("INSERT INTO users"
                + "(user_name, password, craft_slide,complexity,wineorbeer,"
                + "winecheck,beercheck,spiritcheck,pricerange) VALUES"
                + "('" + username + "','" + password + "'," + craft_slide + "," + complexity + "," + wineOrBeer + "," + wineCheck + "," +
                beerCheck + "," + spiritCheck + "," + priceRange + ");", conn);
                NpgsqlDataReader dr = query.ExecuteReader();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
        public bool add_bar(string barname, int craft_slide, int complexity,
        int wineOrBeer, int wineCheck, int beerCheck, int spiritCheck, double lowerQuartileMeal,
        double lowerQuartileBeer, double upperQuartileMeal, double upperQuartileBeer, string location)
        {
            try
            {
                NpgsqlConnection conn = connect();
                NpgsqlCommand query =
                new NpgsqlCommand("INSERT INTO bars"
                + "(bar_name, craft_slide,complexity,wineorbeer, winecheck,"
                + "beercheck,spiritcheck,lowerquartilemeal,lowerquartilebeer,"
                + "upperquartilemeal, upperquartilebeer, location) VALUES"
                + "('" + barname + "'," + craft_slide + "," + complexity + "," + wineOrBeer + "," + wineCheck + "," +
                beerCheck + "," + spiritCheck + "," + lowerQuartileMeal + "," + lowerQuartileBeer +
                "," + upperQuartileMeal + "," + upperQuartileBeer + ",'" + location + "');", conn);
                NpgsqlDataReader dr = query.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }


        public int userIdentification(string username, string password)
        {
            try
            {
                NpgsqlConnection conn = connect();
                NpgsqlCommand query =
                new NpgsqlCommand("SELECT user_id FROM users WHERE user_name = '"
                + username
                + "' AND password = '"
                + password + "';", conn);
                NpgsqlDataReader dr = query.ExecuteReader();
                dr.Read();
                int userID = dr.GetInt16(0);
                return userID;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return -1;
        }


        public (string, string) bar_location(int bar_id)
        {
            try
            {
                NpgsqlConnection conn = connect();
                NpgsqlCommand query =
                    new NpgsqlCommand("SELECT bar_name, location FROM bars WHERE"
                    + " bar_id = " + bar_id + ";", conn);
                NpgsqlDataReader dr = query.ExecuteReader();
                dr.Read();
                string bar_name = dr.GetString(0);
                string location = dr.GetString(1);
                conn.Close();
                return (bar_name, location);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ("There is no bar under this id.", "");
        }
        public (List<int> bar_id, List<int> craft, List<int> complexities, List<int> wineOrBeer,
        List<int[]> checkBox, List<double> lowerQuartileMeal, List<double> lowerQuartileBeer, List<double> upperQuartileMeal,
        List<double> upperQuartileBeer) get_bar()
        {
            try
            {
                NpgsqlConnection conn = connect();
                NpgsqlCommand query = new NpgsqlCommand("SELECT bar_id, craft_slide, complexity,"
                + "wineorbeer, winecheck,beercheck,spiritcheck, lowerquartilemeal,"
                + "lowerquartilebeer, upperquartilemeal,upperquartilebeer FROM bars;", conn);
                NpgsqlDataReader dr = query.ExecuteReader();
                List<int> bar_id = new List<int>();
                List<int> craft = new List<int>();
                List<int> complexities = new List<int>();
                List<int> wineOrBeer = new List<int>();
                List<int[]> checkBox = new List<int[]>();
                List<double> lowerQuartileMeal = new List<double>();
                List<double> lowerQuartileBeer = new List<double>();
                List<double> upperQuartileMeal = new List<double>();
                List<double> upperQuartileBeer = new List<double>();
                while (dr.Read())
                {
                    bar_id.Add(dr.GetInt16(0));
                    craft.Add(dr.GetInt16(1));
                    complexities.Add(dr.GetInt16(2));
                    wineOrBeer.Add(dr.GetInt16(3));
                    int[] temp = { dr.GetInt16(4), dr.GetInt16(5), dr.GetInt16(6) };
                    checkBox.Add(temp);
                    lowerQuartileMeal.Add(dr.GetDouble(7));
                    lowerQuartileBeer.Add(dr.GetDouble(8));
                    upperQuartileMeal.Add(dr.GetDouble(9));
                    upperQuartileBeer.Add(dr.GetDouble(10));
                }
                conn.Close();
                return (bar_id, craft, complexities, wineOrBeer, checkBox, lowerQuartileMeal, lowerQuartileBeer, upperQuartileMeal, upperQuartileBeer);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return (null, null, null, null, null, null, null, null, null);
        }
        public (int, int, int, int[],double) get_user_preferences(int userid)
        {
            try
            {
                NpgsqlConnection conn = connect();
                NpgsqlCommand query =
                new NpgsqlCommand("SELECT craft_slide, complexity, "
                + "wineorbeer, winecheck,beercheck,spiritcheck,pricerange FROM users WHERE user_id=" + userid + ";", conn);
                NpgsqlDataReader dr = query.ExecuteReader();
                dr.Read();
                int craft = dr.GetInt16(0);
                int complexities = dr.GetInt16(1);
                int wineOrBeer = dr.GetInt16(2);
                int[] checkBox = { dr.GetInt16(3), dr.GetInt16(4), dr.GetInt16(5) };
                double priceRange = dr.GetDouble(6);
                conn.Close();
                return (craft, complexities, wineOrBeer, checkBox, priceRange);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return (-1, -1, -1, null,-1.0);
        }
    }
}