using System;

namespace SmartDeliveryManagementSystem
{
    // 5) Create a DeliveryCenter struct

    public struct DeliveryCenter
    {
        private Shipment[] shipments;
        private int count;

        public DeliveryCenter(int capacity)
        {
            shipments = new Shipment[capacity > 0 ? capacity : 10];
            count = 0;
        }

   
        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length)
                    return shipments[index];
                return default;
            }
            set
            {
                if (index >= 0 && index < shipments.Length)
                    shipments[index] = value;
 
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i].TrackingCode == trackingCode)
                        return shipments[i];
                }
                return default;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i].TrackingCode == null)
                {
                    shipments[i] = shipment;
                    count++;
                    return true;
                }
            }
            return false; 
        }

        public int Capacity => shipments.Length;
        public int Count => count;
    }
}
