using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Model;
using ConsoleApp.Model.Enum;
using ConsoleApp.OutputTypes;

namespace ConsoleApp
{
    public class QueryHelper : IQueryHelper
    {
        // Task №1
        public IEnumerable<Delivery> Paid(IEnumerable<Delivery> deliveries) => deliveries.Where(d => !string.IsNullOrEmpty(d.PaymentId));

        // Task №2
        public IEnumerable<Delivery> NotFinished(IEnumerable<Delivery> deliveries) => deliveries.Where(d => d.Status != DeliveryStatus.Cancelled && d.Status != DeliveryStatus.Done);

        // Task №3
        public IEnumerable<DeliveryShortInfo> DeliveryInfosByClient(IEnumerable<Delivery> deliveries, string clientId) =>
            deliveries.Where(d => d.ClientId == clientId)
                      .Select(d => new DeliveryShortInfo
                      {
                          Id = d.Id,
                          StartCity = d.Direction.Origin.City,
                          EndCity = d.Direction.Destination.City,
                          ClientId = d.ClientId,
                          Type = d.Type,
                          LoadingPeriod = d.LoadingPeriod,
                          ArrivalPeriod = d.ArrivalPeriod,
                          Status = d.Status,
                          CargoType = d.CargoType
                      });
    }
}
