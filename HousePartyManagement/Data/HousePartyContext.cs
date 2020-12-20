using HousePartyManagement.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HousePartyManagement.Data
{
    public class HousePartyContext
    {
        public string ConnectionString { get; set; }

        public HousePartyContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);

        }

        public List<Drink> GetAllDrink()
        {
            List<Drink> drinks = new List<Drink>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM ital", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        drinks.Add(new Drink()
                        {
                            Id = Convert.ToInt32(reader["idItal"]),
                            Name = reader["Nev"].ToString(),
                            Bottle = Convert.ToDouble(reader["Mennyiseg"]),
                            AlcoholPercentage = Convert.ToInt32(reader["AlkoholSzazalek"]),
                            Price = Convert.ToInt32(reader["EgysegAr"])
                        });
                    }
                }

            }

            return drinks;
        }

        private Dictionary<int, double> GetConsumedDrinksByParty(int partyId)
        {
            Dictionary<int, double> consumedSnacks = new Dictionary<int, double>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM  ital_buli WHERE idBuli = {partyId}", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        consumedSnacks.Add(
                            Convert.ToInt32(reader["idItal"]),
                            Convert.ToDouble(reader["FogyottMennyiseg"])
                            );

                    }
                }

            }

            return consumedSnacks;
        }

        public List<Party> GetAllParty()
        {
            List<Party> partys = new List<Party>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM buli", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        partys.Add(new Party()
                        {
                            Id = Convert.ToInt32(reader["idBuli"]),
                            Host = reader["Szervezo"].ToString(),
                            Location = reader["Helyszin"].ToString(),
                            Time = DateTimeOffset.Parse(reader["Kezdes"].ToString()),
                            Members = new List<string>() { "Én", "Gyula", "Ottó" },
                            Capacity = Convert.ToInt32(reader["Kapacitas"]),
                            Snacks = new List<Snack>(),
                            ConsumedSnacks = new Dictionary<int, int>(),
                            Drinks = GetAllDrink(),
                            ConsumedDrinks = GetConsumedDrinksByParty(1),
                            Price = Convert.ToInt32(reader["Osszeg"]),
                        });
                    }
                }

            }

            return partys;
        }

        public Party GetPartyById(int partyId)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM  buli WHERE idBuli = {partyId}", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    return new Party()
                    {
                        Id = Convert.ToInt32(reader["idBuli"]),
                        Host = reader["Szervezo"].ToString(),
                        Location = reader["Helyszin"].ToString(),
                        Time = DateTimeOffset.Parse(reader["Kezdes"].ToString()),
                        Members = new List<string>() { "Én", "Gyula", "Ottó" },
                        Capacity = Convert.ToInt32(reader["Kapacitas"]),
                        Snacks = new List<Snack>(),
                        ConsumedSnacks = new Dictionary<int, int>(),
                        Drinks = GetAllDrink(),
                        ConsumedDrinks = GetConsumedDrinksByParty(1),
                        Price = Convert.ToInt32(reader["Osszeg"]),
                    };
                }
            }

        }

        public void UpdatePartyLocation(Party model)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update_buli_helyszin", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_in", model.Id);
                cmd.Parameters.AddWithValue("@helyszin_in", model.Location);
                cmd.Parameters.AddWithValue("@updatedBy_in", model.Host);
                cmd.ExecuteNonQuery();
            }

        }

        public void CreateParty(Party model)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("create_buli", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@szervezo_in", model.Host);
                cmd.Parameters.AddWithValue("@helyszin_in", model.Location);
                cmd.Parameters.AddWithValue("@kezdes_in", model.Time.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@kapacitas_in", model.Capacity);
                cmd.Parameters.AddWithValue("@osszeg_in", model.Price);
                cmd.Parameters.AddWithValue("@createdBy_in", model.Host);
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateDrink(Drink model)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("create_ital", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nev_in", model.Name);
                cmd.Parameters.AddWithValue("@mennyiseg_in", model.Bottle);
                cmd.Parameters.AddWithValue("@alkoholSzazalek_in", model.AlcoholPercentage);
                cmd.Parameters.AddWithValue("@egysegAr_in", model.Price);
                cmd.Parameters.AddWithValue("@kiegeszito_in", model.Comment);
                //cmd.Parameters.AddWithValue("@createdBy_in", model.Host);
                cmd.ExecuteNonQuery();
            }
        }

        public void AddDrinkToParty(int partyId, int drinkId, double consumed)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("create_ital_buli", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_buli_in", partyId);
                cmd.Parameters.AddWithValue("@id_ital_in", drinkId);
                cmd.Parameters.AddWithValue("@fogyottMennyiseg_in", consumed);
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateSnack(Snack model)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("create_snack", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nev_in", model.Name);
                cmd.Parameters.AddWithValue("@marka_in", model.Brand);
                cmd.Parameters.AddWithValue("@kiszereles_in", model.Weight);
                cmd.Parameters.AddWithValue("@darabszam_in", model.Count);
                cmd.Parameters.AddWithValue("@ar_in", model.Price);
                //cmd.Parameters.AddWithValue("@createdBy_in", model.Host);
                cmd.ExecuteNonQuery();
            }
        }

        public void AddSnackToParty(int partyId, int snackId, int consumed)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("create_snack_buli", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_buli_in", partyId);
                cmd.Parameters.AddWithValue("@id_snack_in", snackId);
                cmd.Parameters.AddWithValue("@fogyottMennyiseg_in", consumed);
                cmd.ExecuteNonQuery();
            }
        }

        //public void CreateUser(User model)
        //{
        //    using (MySqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("create_szemely", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@felhasznalonev_in", model.Username);
        //        cmd.Parameters.AddWithValue("@nev_in", model.Name);
        //        cmd.Parameters.AddWithValue("@szuletesiIdo_in", model.BirthDate.ToString("yyyy-MM-dd HH:mm:ss"));
        //        cmd.Parameters.AddWithValue("@nem_in", model.Gender);
        //        cmd.Parameters.AddWithValue("@jelszo_in", model.Password);
        //        cmd.Parameters.AddWithValue("@email_in", model.Email);
        //        cmd.Parameters.AddWithValue("@createdBy_in", model.Username);
        //        cmd.ExecuteNonQuery();
        //    }
        ////}

        public void AddUserToParty(int partyId, int userId)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("create_szemely_buli", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_buli_in", partyId);
                cmd.Parameters.AddWithValue("@id_szemely_in", userId);
                cmd.ExecuteNonQuery();
            }
        }

        //public List<User> GetUserFromParty(int partyId)
        //{
        //    List<User> members = new List<User>();

        //    using (MySqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("getAllSzemelyBuli", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@id_buli_in", partyId);

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                members.Add(new User()
        //                {
        //                    Id = Convert.ToInt32(reader["idSzemely"]),
        //                    Name = reader["Nev"].ToString(),
        //                });
        //            }
        //        }

        //    }

        //    return members;
        ////}
    }
}
