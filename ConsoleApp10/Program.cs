using System;

namespace SmartDeliveryManagementSystem
{
    class Program
    {
 
        // 6) In Main

        static void Main(string[] args)
        {
            DeliveryCenter center = new DeliveryCenter(10);


            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"\nEnter Shipment {i} Data");

                Console.Write("Tracking Code: ");
                string trackingCode = Console.ReadLine();

                Console.Write("Description: ");
                string description = Console.ReadLine();

                Console.Write("Weight: ");
                double weight = double.Parse(Console.ReadLine());

                Console.Write("Delivery Fee: ");
                decimal fee = decimal.Parse(Console.ReadLine());

                Console.Write("City: ");
                string city = Console.ReadLine();

                Console.Write("Street: ");
                string street = Console.ReadLine();

                Console.Write("Building Number: ");
                int buildingNumber = int.Parse(Console.ReadLine());

                DeliveryAddress address = new DeliveryAddress(city, street, buildingNumber);
                Shipment shipment = new Shipment(trackingCode, description, weight, fee, address);

                bool added = center.AddShipment(shipment);
                Console.WriteLine(added ? "\nShipment added successfully." : "\nDelivery center is full.");
            }


            Console.WriteLine("\n--- All Shipments");
            for (int i = 0; i < 3; i++)
            {
                center[i].PrintShipment();
                Console.WriteLine();
            }

            Console.Write("Enter a tracking code to search: ");
            string searchCode = Console.ReadLine();


            Shipment found = center[searchCode];

    
            if (found.TrackingCode != null)
                Console.WriteLine($"Shipment found: {found.TrackingCode} - {found.Description}");
            else
                Console.WriteLine("Shipment not found");

 
            Console.WriteLine("\n--- Struct Copy Test ---");
            DeliveryAddress original = new DeliveryAddress("Cairo", "Tahrir Street", 15);
            DeliveryAddress copy = original; 
            copy.City = "Cairo Copied";
            copy.Street = "Makram Ebeid Street";
            copy.BuildingNumber = 20;

            Console.WriteLine($"Original Address: {original.GetFullAddress()}");
            Console.WriteLine($"Copied Address: {copy.GetFullAddress()}");
        }
    }
}
