using System;

namespace SmartDeliveryManagementSystem
{

    public struct Shipment
    {
        // 2) private fields: TrackingCode, Description, Weight, DeliveryFee
        private string trackingCode;
        private string description;
        private double weight;
        private decimal deliveryFee;


        public DeliveryAddress Destination { get; set; }


        public string TrackingCode
        {
            get { return trackingCode; }
        }


        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    description = value;

            }
        }


        public double Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                    weight = value;

            }
        }


        public decimal DeliveryFee
        {
            get { return deliveryFee; }
            private set
            {
                if (value > 0)
                    deliveryFee = value;
            }
        }


        public decimal EstimatedCost
        {
            get { return DeliveryFee + ((decimal)Weight * 5); }
        }
        #region  Q3 Constructor 1: receives only trackingCode

        public Shipment(string trackingCode)
        {
            this.trackingCode = !string.IsNullOrWhiteSpace(trackingCode) ? trackingCode : "UNKNOWN";
            description = "Unknown";
            weight = 1;
            deliveryFee = 50;
            Destination = new DeliveryAddress("Unknown", "Unknown", 0);
        }


        public Shipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress destination)
        {
            this.trackingCode = !string.IsNullOrWhiteSpace(trackingCode) ? trackingCode : "UNKNOWN";
            this.description = !string.IsNullOrWhiteSpace(description) ? description : "Unknown";
            this.weight = weight > 0 ? weight : 1;
            this.deliveryFee = deliveryFee > 0 ? deliveryFee : 50;
            Destination = destination;
        }
        #endregion

        #region 
        //Q4
        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
                deliveryFee = newFee;
        }


        public void PrintShipment()
        {
            Console.WriteLine("---Tracking Code:");
            Console.WriteLine($"{TrackingCode} Description:");
            Console.WriteLine($"{Description} Weight: {Weight} KG");
            Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
        }

        #endregion
    }
}
