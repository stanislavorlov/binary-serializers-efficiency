using BinarySerializers.Contracts;

namespace BinarySerializers.DataContracts;

internal class DataSource
{
    private readonly Random _random = new();
    private readonly List<DeviceTelemetry> _simpleObjects = [];
    private readonly List<Invoice> _complexObjects = [];

    public DataSource()
    {
        for (int i = 0; i < 1000000; i++)
        {
            _simpleObjects.Add(GetSimpleObject());
            _complexObjects.Add(GetComplexObject());
        }
    }

    public List<DeviceTelemetry> GetSimpleObjects(int count)
    {
        return _simpleObjects.Take(count).ToList();
    }

    public List<Invoice> GetComplexObjects(int count)
    {
        return _complexObjects.Take(count).ToList();
    }

    private DeviceTelemetry GetSimpleObject()
    {
        var telemetry = new DeviceTelemetry
        {
            Id = _random.Next(0, int.MaxValue),
            Name = "Sensor-X9",
            IsActive = true,
            Temperature = (float)_random.NextDouble(),
            Pressure = _random.NextDouble(),
            Timestamp = DateTime.UtcNow,
            Tags = ["env", "critical", "zone-1"],
            SensorData = new Dictionary<string, int>
            {
                ["humidity"] = 45,
                ["vibration"] = 7
            }
        };

        return telemetry;
    }

    private Invoice GetComplexObject()
    {
        var invoice = new Invoice
        {
            Id = _random.Next(0, int.MaxValue),
            InvoiceNumber = "INV-1002",
            InvoiceDate = DateTime.Today,
            DueDate = DateTime.Today.AddDays(30),
            Vendor = new Vendor
            {
                VendorId = _random.Next(0, int.MaxValue),
                CompanyName = "CodeWorks Ltd.",
                ContactPerson = "John Smith",
                Address = "456 Developer Way",
                Email = "john@codeworks.com",
                Phone = "+1-555-5678",
                TaxNumber = "TAX-123456",
                BankAccount = "IBAN123456789"
            },
            Customer = new Customer
            {
                CustomerId = _random.Next(0, int.MaxValue),
                CompanyName = "Tech Solutions Inc.",
                ContactPerson = "Alice Brown",
                Address = "789 Tech Park",
                Email = "alice@techsolutions.com",
                Phone = "+1-555-9012"
            },
            Details =
            [
                new InvoiceItem { Description = "Software License", Quantity = 3, UnitPrice = 200.0m, TaxRate = 0.1m },
                new InvoiceItem { Description = "Support Package", Quantity = 1, UnitPrice = 500.0m, TaxRate = 0.2m }
            ],
            Notes = "Payable within 30 days."
        };

        return invoice;
    }
}
