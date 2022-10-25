
using Microsoft.EntityFrameworkCore;
using CodeFirst.Models;

public static class SampleData
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Province>().HasData(
            GetProvinces()
        );
        modelBuilder.Entity<City>().HasData(
            GetCities()
        );
    }


    public static List<Province> GetProvinces()
    {
        List<Province> provinces = new List<Province>(){
        new Province() { ProvinceCode = "AB", ProvinceName = "Alberta" },
        new Province() { ProvinceCode = "BC", ProvinceName = "British Columbia" },
        new Province() { ProvinceCode = "MB", ProvinceName = "Manitoba" },
        new Province() { ProvinceCode = "NB", ProvinceName = "New Brunswick" },
        new Province() { ProvinceCode = "NL", ProvinceName = "Newfoundland and Labrador" },
        new Province() { ProvinceCode = "NS", ProvinceName = "Nova Scotia" },
        new Province() { ProvinceCode = "NT", ProvinceName = "Northwest Territories" },
        new Province() { ProvinceCode = "NU", ProvinceName = "Nunavut" },
        new Province() { ProvinceCode = "ON", ProvinceName = "Ontario" },
        new Province() { ProvinceCode = "PE", ProvinceName = "Prince Edward Island" },
        new Province() { ProvinceCode = "QC", ProvinceName = "Quebec" },
        new Province() { ProvinceCode = "SK", ProvinceName = "Saskatchewan" },
        new Province() { ProvinceCode = "YT", ProvinceName = "Yukon" }
    };
        return provinces;
    }


    public static List<City> GetCities()
    {
        List<City> cities = new List<City>(){
        new City() { CityId = 1, CityName = "Calgary", Population = 1239220, ProvinceCode = "AB" },
        new City() { CityId = 2, CityName = "Edmonton", Population = 979587, ProvinceCode = "AB" },
        new City() { CityId = 3, CityName = "Red Deer", Population = 100418, ProvinceCode = "AB" },
        new City() { CityId = 4, CityName = "Vancouver", Population = 631486, ProvinceCode = "BC" },
        new City() { CityId = 5, CityName = "Victoria", Population = 367770, ProvinceCode = "BC" },
        new City() { CityId = 6, CityName = "Kelowna", Population = 141767, ProvinceCode = "BC" },
        new City() { CityId = 7, CityName = "Winnipeg", Population = 778489, ProvinceCode = "MB" },
        new City() { CityId = 8, CityName = "Brandon", Population = 45935, ProvinceCode = "MB" },
        new City() { CityId = 9, CityName = "Steinbach", Population = 13245, ProvinceCode = "MB" },
        new City() { CityId = 10, CityName = "Fredericton", Population = 56250, ProvinceCode = "NB" },
        new City() { CityId = 11, CityName = "Moncton", Population = 71227, ProvinceCode = "NB" },
        new City() { CityId = 12, CityName = "Saint John", Population = 67074, ProvinceCode = "NB" },
        new City() { CityId = 13, CityName = "St. John's", Population = 108792, ProvinceCode = "NL" },
        new City() { CityId = 14, CityName = "Corner Brook", Population = 21420, ProvinceCode = "NL" },
        new City() { CityId = 15, CityName = "Grand Falls-Windsor", Population = 11266, ProvinceCode = "NL" },
        new City() { CityId = 16, CityName = "Halifax", Population = 403131, ProvinceCode = "NS" },
        new City() { CityId = 17, CityName = "Dartmouth", Population = 103733, ProvinceCode = "NS" },
        new City() { CityId = 18, CityName = "Sydney", Population = 35986, ProvinceCode = "NS" },
        new City() { CityId = 19, CityName = "Yellowknife", Population = 19769, ProvinceCode = "NT" },
        new City() { CityId = 20, CityName = "Iqaluit", Population = 6830, ProvinceCode = "NU" },
        new City() { CityId = 21, CityName = "Toronto", Population = 2731571, ProvinceCode = "ON" },
        new City() { CityId = 22, CityName = "Ottawa", Population = 934243, ProvinceCode = "ON" },
        new City() { CityId = 23, CityName = "Hamilton", Population = 721053, ProvinceCode = "ON" },
        new City() { CityId = 24, CityName = "Charlottetown", Population = 34579, ProvinceCode = "PE" },
        new City() { CityId = 25, CityName = "Quebec City", Population = 531902, ProvinceCode = "QC" },
        new City() { CityId = 26, CityName = "Montreal", Population = 1704694, ProvinceCode = "QC" },
        new City() { CityId = 27, CityName = "Regina", Population = 236481, ProvinceCode = "SK" },
        new City() { CityId = 28, CityName = "Saskatoon", Population = 255251, ProvinceCode = "SK" },
        new City() { CityId = 29, CityName = "Prince Albert", Population = 35146, ProvinceCode = "SK" },
        new City() { CityId = 30, CityName = "Whitehorse", Population = 24505, ProvinceCode = "YT" }
    };

        return cities;
    }

}