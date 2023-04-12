using rent.Models;
using System.Data.OleDb;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Hosting;

namespace rent.Repository
{
    public class Data : IData
    {
        private readonly IConfiguration configuration;
        private readonly string dbcon = "";
        private readonly IWebHostEnvironment webhost;
        public Data(IConfiguration configuration, IWebHostEnvironment webhost)
        {
            this.configuration = configuration;
            dbcon = this.configuration.GetConnectionString("dbConnection");
            this.webhost = webhost;
        }
        [SupportedOSPlatform("windows")]
        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();
            Car car;
            OleDbConnection con = GetOleDbConnection();
            try
            {
                con.Open();
                string qry = "Select * from Cars";
                OleDbDataReader reader = GetData(qry, con);
                while (reader.Read())
                {
                    car = new Car();
                    car.Id = int.Parse(reader["ID"].ToString());
                    car.Brand = reader["Brand"].ToString();
                    car.Model = reader["Model"].ToString();
                    car.PassingYear = int.Parse(reader["PassingYear"].ToString());
                    car.Engine = reader["Engine"].ToString();
                    car.FuelType = reader["FuelType"].ToString();
                    car.ImagePath = reader["ImagePath"].ToString();
                    car.CarNumber = reader["CarNumber"].ToString();
                    car.SeatingCapacity = int.Parse(reader["SeatingCapacity"].ToString());
                    cars.Add(car);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return cars;
        }
        [SupportedOSPlatform("windows")]
        private OleDbDataReader GetData(string qry, OleDbConnection con)
        {
            OleDbDataReader reader = null;
            try
            {
                OleDbCommand cmd = new OleDbCommand(qry, con);
                reader = cmd.ExecuteReader();   
            }
            catch (Exception) 
            { 
                throw; 
            }
            return reader;
        }
        [SupportedOSPlatform("windows")]
        public bool AddNewCar(Car newcar)
        {
            bool isSaved = false;
            OleDbConnection con = GetOleDbConnection();
            try
            {
                con.Open();
                newcar.ImagePath = SaveImage(newcar.CarImage, "cars");
                string qry = String.Format("Insert into Cars(Brand,Model,PassingYear,CarNumber,Engine,FuelType,ImagePath,SeatingCapacity) " +
                    "values("+ "'{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7})",newcar.Brand,newcar.Model,newcar.PassingYear,newcar.CarNumber,
                    newcar.Engine,newcar.FuelType,newcar.ImagePath,newcar.SeatingCapacity);
                isSaved = SaveData(qry, con);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return isSaved;
        }
        private string SaveImage(IFormFile file, string folderName)
        {
            string imagepath = "";
            try
            {
                string uploadfolder = Path.Combine(webhost.WebRootPath,"images/"+folderName);
                imagepath = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filepath = Path.Combine(uploadfolder, imagepath);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    file.CopyTo(filestream);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return imagepath;
        }
        [SupportedOSPlatform("windows")]
        private new OleDbConnection GetOleDbConnection()
        {
            return new OleDbConnection(dbcon);
        }
        [SupportedOSPlatform("windows")]
        private bool SaveData(string qry, OleDbConnection con)
        {
            bool isSaved = false;
            try
            {
                OleDbCommand cmd = new OleDbCommand(qry, con);
                cmd.ExecuteNonQuery();
                isSaved = true;
            }
            catch(Exception)
            {
                throw;
            }
            return isSaved;
        }
    }
}
