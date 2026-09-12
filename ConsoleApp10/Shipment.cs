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


    }
}
