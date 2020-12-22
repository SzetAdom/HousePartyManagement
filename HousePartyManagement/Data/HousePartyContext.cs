using HousePartyManagement.Areas.Identity.Data;
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
        public string LoggedInUser { get; set; }
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
                            AlcoholPercentage = reader["AlkoholSzazalek"].ToString(),
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


        public List<Snack> GetSnacks()
        {
            List<Snack> snacks = new List<Snack>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM  snack", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        snacks.Add(new Snack()
                        {
                            Id = Convert.ToInt32(reader["idSnack"]),
                            Name = reader["Nev"].ToString(),
                            Brand = reader["Marka"].ToString(),
                            Weight = reader["Kiszereles"].ToString(),
                            Count = Convert.ToInt32(reader["Darabszam"]),
                            Price = Convert.ToInt32(reader["Ar"]),
                            IsActive = Convert.ToInt32(reader["IsActive"])
                        });

                    }
                }

            }

            return snacks;
        }


        public List<Party> GetAllParty()
        {
            List<Party> partys = new List<Party>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM buli ORDER BY kezdes DESC", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        partys.Add(new Party()
                        {
                            Id = Convert.ToInt32(reader["idBuli"]),
                            Host = reader["Szervezo"].ToString(),
                            Location = reader["Helyszin"].ToString(),
                            Time = DateTime.Parse(reader["Kezdes"].ToString()),
                            Members = new List<string>() { "Én", "Gyula", "Ottó" },
                            Capacity = Convert.ToInt32(reader["Kapacitas"]),
                            Snacks = GetSnackByParty(Convert.ToInt32(reader["idBuli"])),
                            ConsumedSnacks = new Dictionary<int, int>(),
                            Drinks = GetDrinkByParty(Convert.ToInt32(reader["idBuli"])),
                            ConsumedDrinks = GetConsumedDrinksByParty(Convert.ToInt32(reader["idBuli"])),
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
                        Time = DateTime.Parse(reader["Kezdes"].ToString()),
                        Members = new List<string>() { "Én", "Gyula", "Ottó" },
                        Capacity = Convert.ToInt32(reader["Kapacitas"]),
                        Snacks = GetSnackByParty(Convert.ToInt32(reader["idBuli"])),
                        ConsumedSnacks = new Dictionary<int, int>(),
                        Drinks = GetDrinkByParty(Convert.ToInt32(reader["idBuli"])),
                        ConsumedDrinks = GetConsumedDrinksByParty(Convert.ToInt32(reader["idBuli"])),
                        Price = Convert.ToInt32(reader["Osszeg"]),
                    };
                }
            }

        }

        public int GetSnackIdByName(string name) {

            int id = -1;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("read_snack_by_name", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nev_in", name);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["idSnack"]);
                    }
                }

            }

            return id;
        }

        public int GetDrinkIdByName(string name)
        {

            int id = -1;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("read_ital_by_name", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nev_in", name);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["idItal"]);
                    }
                }

            }

            return id;
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

        public void UpdatePartyCapacity(Party model)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update_buli_kapacitas", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_in", model.Id);
                cmd.Parameters.AddWithValue("@kapacitas_in", model.Capacity);
                cmd.Parameters.AddWithValue("@updatedBy_in", model.Host);
                cmd.ExecuteNonQuery();
            }

        }

        public void UpdatePartyOrganiser(Party model) {

            string host = "\"" + model.Host + "\"";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"UPDATE buli SET buli.Szervezo = {host}  WHERE buli.idBuli = {model.Id}", conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePartyTime(Party model)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update_buli_kezdes", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_in", model.Id);
                cmd.Parameters.AddWithValue("@kezdes_in", model.Time);
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
                cmd.Parameters.AddWithValue("@kezdes_in", model.Time);
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
                cmd.Parameters.AddWithValue("@createdBy_in", model.Name); //Ideiglenes
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
                cmd.Parameters.AddWithValue("@createdBy_in", model.Name); //Ideiglenes
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
        //        cmd.Parameters.AddWithValue("@felhasznalonev_in", model.UserName);
        //        cmd.Parameters.AddWithValue("@nev_in", model.Name);
        //        cmd.Parameters.AddWithValue("@szuletesiIdo_in", model.BirthDate);
        //        cmd.Parameters.AddWithValue("@nem_in", model.Gender);
        //        cmd.Parameters.AddWithValue("@jelszo_in", model.PasswordHash);
        //        cmd.Parameters.AddWithValue("@email_in", model.Email);
        //        cmd.Parameters.AddWithValue("@createdBy_in", model.UserName);
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        public void AddUserToParty(int partyId, string userId)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("create_szemely_buli", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_buli_in", 1);
                cmd.Parameters.AddWithValue("@id_szemely_in", userId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<User> GetUserFromParty(int partyId) //lehet hiba
        {
            List<User> members = new List<User>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("getAllSzemelyBuli", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_buli_in", partyId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        members.Add(new User()
                        {
                            UserName = reader["idSzemely"].ToString(),
                            Name = reader["Nev"].ToString(),
                        });
                    }
                }

            }

            return members;
        }

        public List<Drink> GetDrinkByParty(int partyId)
        {
            List<Drink> drinks = new List<Drink>();

            using (MySqlConnection conn = GetConnection())
            {
                int idItal = 0;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT idItal FROM ital_buli WHERE idBuli = {partyId}", conn);
                

                //italid-k lekerese egy bulihoz
                List<int> idItal_list = new List<int>();
                using (var reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        idItal_list.Add(Convert.ToInt32(reader["idItal"]));
                    }
                }

                foreach (int ital in idItal_list) {
                    idItal = ital;
                    MySqlCommand cmd1 = new MySqlCommand($"SELECT * from ital where idItal = {idItal}", conn);
                    using (var reader1 = cmd1.ExecuteReader()) {

                        while (reader1.Read())
                        {
                            drinks.Add(new Drink()
                            {
                                Id = Convert.ToInt32(reader1["idItal"]),
                                Name = reader1["Nev"].ToString(),
                                Bottle = Convert.ToDouble(reader1["Mennyiseg"]),
                                AlcoholPercentage = reader1["AlkoholSzazalek"].ToString(),
                                Price = Convert.ToInt32(reader1["EgysegAr"])
                            });
                        }
                    }
                }

            }

            return drinks;
        }

        public List<Snack> GetSnackByParty(int partyId)
        {
            List<Snack> snacks = new List<Snack>();

            using (MySqlConnection conn = GetConnection())
            {
                int idSnack = 0;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT idSnack FROM snack_buli WHERE idBuli = {partyId}", conn);

                List<int> idSnack_list = new List<int>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idSnack_list.Add(Convert.ToInt32(reader["idSnack"]));
                    }
                }

                foreach (int snack in idSnack_list)
                {
                    idSnack = snack;
                    MySqlCommand cmd1 = new MySqlCommand($"SELECT * from snack where idSnack = {idSnack}", conn);
                    using (var reader1 = cmd1.ExecuteReader())
                    {

                        while (reader1.Read())
                        {
                            snacks.Add(new Snack()
                            {
                                Id = Convert.ToInt32(reader1["idSnack"]),
                                Name = reader1["Nev"].ToString(),
                                Brand = reader1["Marka"].ToString(),
                                Weight = reader1["Kiszereles"].ToString(),
                                Count = Convert.ToInt32(reader1["Darabszam"]),
                                Price = Convert.ToInt32(reader1["Ar"]),
                                IsActive = Convert.ToInt32(reader1["IsActive"])
                            });
                        }
                    }
                }

            }

            return snacks;
        }

        public bool UserValid(string username, string password) {

            List<string> user = new List<string>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("read_szemely_by_username", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@felhasznalonev_in", username);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.Add(reader["Felhasznalonev"].ToString());
                        user.Add(reader["Jelszo"].ToString());
                        break;
                    }
                }

            }
            if (user.Count() != 0)
            {
                if (user[0] == username && user[1] == password) return true; else return false;
            }
            else return false;
            
        }

        public string GetUserByUserName(string UserName)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT idSzemely FROM szemely WHERE Felhasznalonev = \"{UserName}\"", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader["Felhasznalonev"].ToString();
                    }
                }

            }
            return null;
        }
    }

}
