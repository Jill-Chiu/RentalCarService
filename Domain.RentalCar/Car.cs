﻿namespace Domain.RentalCar
{
    /// <summary>
    /// 轎車
    /// </summary>
    public class Car : IVehicle
    {
        public string Model { get; set; }
        public string CC { get; set; }

        /// <summary>
        /// 計算租車費用
        /// </summary>
        /// <param name="daysRented"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public decimal CalculateRenta1Cost(int daysRented)
        {
            return daysRented * 100;//假設為美元
        }

        /// <summary>
        /// 選擇租車時間
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public TimeSpan ChoiseRenta1Time(DateTime start, DateTime end)
        {
            return end - start;
        }

        /// <summary>
        /// 取得車輛類型
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public VehicleType GetVehicIeType() => VehicleType.car;
        


    }
}
