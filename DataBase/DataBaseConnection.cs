using AHRestAPI.Models;
using AnimalHouseRestAPI.Models;

namespace AnimalHouseRestAPI.DataBase
{
    public class DataBaseConnection
    {
        public static AnimalhouseContext Context { get; set; } = new AnimalhouseContext();
    }
}
