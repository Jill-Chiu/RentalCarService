using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RentalCar
{
    public interface IVehicle
    {
        decimal CalculateRenta1Cost(int daysRented);
        TimeSpan ChoiseRenta1Time(DateTime start, DateTime end);
        VehicleType GetVehicIeType();


        string Model { get; set; }
        string CC { get; set; }
    }
}
