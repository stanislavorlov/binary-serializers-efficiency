using Avro;
using Avro.File;
using Avro.Generic;
using Avro.Specific;
using Avro.IO;
using BinarySerializers.Contracts;
using BinarySerializers.DataContracts;
using BinarySerializers.Serializers;
using System.Numerics;

namespace BinarySerializers.Serializers;

public class AvroSerializer
{
    private static Schema deviceTelemetrySchema;
    private static Schema invoiceSchema;

    static AvroSerializer()
    {
        // Initialize the Avro serializer settings if needed

        deviceTelemetrySchema = Schema.Parse(@"
            {
                ""type"": ""record"",
                ""name"": ""DeviceTelemetry"",
                ""fields"": [
                    {""name"": ""Id"", ""type"": ""int""},
                    {""name"": ""Name"", ""type"": ""string""},
                    {""name"": ""IsActive"", ""type"": ""boolean""},
                    {""name"": ""Temperature"", ""type"": ""float""},
                    {""name"": ""Pressure"", ""type"": ""double""},
                    {""name"": ""Timestamp"", ""type"": ""long"" },
                    {""name"": ""Tags"", ""type"": {""type"": ""array"", ""items"": ""string""}},
                    {""name"": ""SensorData"", ""type"": {""type"": ""map"", ""values"": ""int""}}
                ]
            }");

        invoiceSchema = Schema.Parse(@"
            {
                ""type"": ""record"",
                ""name"": ""Invoice"",
                ""fields"": [
                    { ""name"": ""Id"", ""type"": ""int"" },
                    { ""name"": ""InvoiceNumber"", ""type"": ""string"" },
                    { ""name"": ""InvoiceDate"", ""type"": ""long"" },
                    { ""name"": ""DueDate"", ""type"": ""long"" },
                    {
                        ""name"": ""Vendor"",
                        ""type"": {
                            ""type"": ""record"",
                            ""name"": ""Vendor"",
                            ""fields"": [
                            { ""name"": ""VendorId"", ""type"": ""int"" },
                            { ""name"": ""CompanyName"", ""type"": ""string"" },
                            { ""name"": ""ContactPerson"", ""type"": ""string"" },
                            { ""name"": ""Address"", ""type"": ""string"" },
                            { ""name"": ""Email"", ""type"": ""string"" },
                            { ""name"": ""Phone"", ""type"": ""string"" },
                            { ""name"": ""TaxNumber"", ""type"": ""string"" },
                            { ""name"": ""BankAccount"", ""type"": ""string"" }
                            ]
                        }
                    },
                    {
                        ""name"": ""Customer"",
                        ""type"": {
                            ""type"": ""record"",
                            ""name"": ""Customer"",
                            ""fields"": [
                            { ""name"": ""CustomerId"", ""type"": ""int"" },
                            { ""name"": ""CompanyName"", ""type"": ""string"" },
                            { ""name"": ""ContactPerson"", ""type"": ""string"" },
                            { ""name"": ""Address"", ""type"": ""string"" },
                            { ""name"": ""Email"", ""type"": ""string"" },
                            { ""name"": ""Phone"", ""type"": ""string"" }
                            ]
                        }
                    },
                    {
                        ""name"": ""Details"",
                        ""type"": {
                            ""type"": ""array"",
                            ""items"": {
                            ""type"": ""record"",
                            ""name"": ""InvoiceItem"",
                            ""fields"": [
                                { ""name"": ""Description"", ""type"": ""string"" },
                                { ""name"": ""Quantity"", ""type"": ""int"" },
                                {
                                ""name"": ""UnitPrice"",
                                ""type"": {
                                    ""type"": ""bytes"",
                                    ""logicalType"": ""decimal"",
                                    ""precision"": 18,
                                    ""scale"": 2
                                }
                                },
                                {
                                ""name"": ""TaxRate"",
                                ""type"": {
                                    ""type"": ""bytes"",
                                    ""logicalType"": ""decimal"",
                                    ""precision"": 5,
                                    ""scale"": 4
                                }
                                }
                            ]
                            }
                        }
                    },
                    { ""name"": ""Notes"", ""type"": ""string"" }
                ]
            }");
    }

    public static byte[] SerializeSimpleObject(DeviceTelemetry instance)
    {
        var totalTicks = instance.Timestamp.ToUniversalTime().Ticks / TimeSpan.TicksPerMillisecond;
        var avroSensorData = instance.SensorData.ToDictionary(kv => kv.Key, kv => (object)kv.Value);

        var record = new GenericRecord((RecordSchema)deviceTelemetrySchema);
        record.Add("Id", instance.Id);
        record.Add("Name", instance.Name);
        record.Add("IsActive", instance.IsActive);
        record.Add("Temperature", instance.Temperature);
        record.Add("Pressure", instance.Pressure);
        record.Add("Timestamp", totalTicks);
        record.Add("Tags", instance.Tags.ToArray());
        record.Add("SensorData", avroSensorData);

        using var memoryStream = new MemoryStream();
        var writer = new BinaryEncoder(memoryStream);
        var datumWriter = new GenericWriter<GenericRecord>(deviceTelemetrySchema);
        datumWriter.Write(record, writer);
        writer.Flush();

        return memoryStream.ToArray();
    }

    public static byte[] SerializeSimpleObjectList(List<DeviceTelemetry> items)
    {
        using var memoryStream = new MemoryStream();
        var writer = new BinaryEncoder(memoryStream);
        var datumWriter = new GenericWriter<GenericRecord>(deviceTelemetrySchema);

        foreach (var instance in items)
        {
            var totalTicks = instance.Timestamp.ToUniversalTime().Ticks / TimeSpan.TicksPerMillisecond;
            var avroSensorData = instance.SensorData.ToDictionary(kv => kv.Key, kv => (object)kv.Value);

            var record = new GenericRecord((RecordSchema)deviceTelemetrySchema);
            record.Add("Id", instance.Id);
            record.Add("Name", instance.Name);
            record.Add("IsActive", instance.IsActive);
            record.Add("Temperature", instance.Temperature);
            record.Add("Pressure", instance.Pressure);
            record.Add("Timestamp", totalTicks);
            record.Add("Tags", instance.Tags.ToArray());
            record.Add("SensorData", avroSensorData);

            datumWriter.Write(record, writer);
        }

        writer.Flush();

        return memoryStream.ToArray();
    }

    public static DeviceTelemetry DeserializeSimpleObject(byte[] buffer)
    {
        using var ms = new MemoryStream(buffer);
        var reader = new BinaryDecoder(ms);
        var datumReader = new GenericReader<GenericRecord>(deviceTelemetrySchema, deviceTelemetrySchema);
        var deserializedRecord = datumReader.Read((GenericRecord?)null, reader);

        var tags = (IList<object>)deserializedRecord["Tags"];
        var sensorData = (IDictionary<string, object>)deserializedRecord["SensorData"];

        var telemetry = new DeviceTelemetry
        {
            Id = (int)deserializedRecord["Id"],
            Name = (string)deserializedRecord["Name"],
            IsActive = (bool)deserializedRecord["IsActive"],
            Temperature = (float)deserializedRecord["Temperature"],
            Pressure = (double)deserializedRecord["Pressure"],
            Timestamp = DateTimeOffset.FromUnixTimeMilliseconds((long)deserializedRecord["Timestamp"]).UtcDateTime,
            Tags = [.. tags.Cast<string>()],
            SensorData = sensorData.ToDictionary(kv => kv.Key, kv => (int)kv.Value)
        };

        return telemetry;
    }

    public static DeviceTelemetry[] DeserializeSimpleObjectList(byte[] buffer)
    {
        using var ms = new MemoryStream(buffer);
        var reader = new BinaryDecoder(ms);
        var datumReader = new GenericReader<GenericRecord>(deviceTelemetrySchema, deviceTelemetrySchema);

        var records = new List<DeviceTelemetry>();
        while (ms.Position < ms.Length)
        {
            var deserializedRecord = datumReader.Read((GenericRecord?)null, reader);

            var tags = (IList<object>)deserializedRecord["Tags"];
            var sensorData = (IDictionary<string, object>)deserializedRecord["SensorData"];

            var telemetry = new DeviceTelemetry
            {
                Id = (int)deserializedRecord["Id"],
                Name = (string)deserializedRecord["Name"],
                IsActive = (bool)deserializedRecord["IsActive"],
                Temperature = (float)deserializedRecord["Temperature"],
                Pressure = (double)deserializedRecord["Pressure"],
                Timestamp = DateTimeOffset.FromUnixTimeMilliseconds((long)deserializedRecord["Timestamp"]).UtcDateTime,
                Tags = [.. tags.Cast<string>()],
                SensorData = sensorData.ToDictionary(kv => kv.Key, kv => (int)kv.Value)
            };

            records.Add(telemetry);
        }

        return records.ToArray();
    }

    public static byte[] SerializeComplexObject(Invoice invoice)
    {
        var record = new GenericRecord((RecordSchema)invoiceSchema);

        // Vendor record
        var vendorSchema = ((RecordSchema)invoiceSchema)["Vendor"].Schema as RecordSchema;
        var vendorRecord = new GenericRecord(vendorSchema);
        vendorRecord.Add("VendorId", invoice.Vendor.VendorId);
        vendorRecord.Add("CompanyName", invoice.Vendor.CompanyName);
        vendorRecord.Add("ContactPerson", invoice.Vendor.ContactPerson);
        vendorRecord.Add("Address", invoice.Vendor.Address);
        vendorRecord.Add("Email", invoice.Vendor.Email);
        vendorRecord.Add("Phone", invoice.Vendor.Phone);
        vendorRecord.Add("TaxNumber", invoice.Vendor.TaxNumber);
        vendorRecord.Add("BankAccount", invoice.Vendor.BankAccount);

        // Customer record
        var customerSchema = ((RecordSchema)invoiceSchema)["Customer"].Schema as RecordSchema;
        var customerRecord = new GenericRecord(customerSchema);
        customerRecord.Add("CustomerId", invoice.Customer.CustomerId);
        customerRecord.Add("CompanyName", invoice.Customer.CompanyName);
        customerRecord.Add("ContactPerson", invoice.Customer.ContactPerson);
        customerRecord.Add("Address", invoice.Customer.Address);
        customerRecord.Add("Email", invoice.Customer.Email);
        customerRecord.Add("Phone", invoice.Customer.Phone);

        // Details array
        var itemSchema = ((ArraySchema)((RecordSchema)invoiceSchema)["Details"].Schema).ItemSchema as RecordSchema;
        var itemRecords = invoice.Details.Select(item =>
        {
            var itemRecord = new GenericRecord(itemSchema);
            itemRecord.Add("Description", item.Description);
            itemRecord.Add("Quantity", item.Quantity);
            itemRecord.Add("UnitPrice", ToAvroDecimal(item.UnitPrice, scale: 2));
            itemRecord.Add("TaxRate", ToAvroDecimal(item.TaxRate, scale: 4));
            return itemRecord;
        }).ToArray();

        // Main invoice record
        var invoiceDateTotalTicks = invoice.InvoiceDate.ToUniversalTime().Ticks / TimeSpan.TicksPerMillisecond;
        var invoiceDueTotalTicks = invoice.DueDate.ToUniversalTime().Ticks / TimeSpan.TicksPerMillisecond;

        record.Add("Id", invoice.Id);
        record.Add("InvoiceNumber", invoice.InvoiceNumber);
        record.Add("InvoiceDate", invoiceDateTotalTicks);
        record.Add("DueDate", invoiceDueTotalTicks);
        record.Add("Vendor", vendorRecord);
        record.Add("Customer", customerRecord);
        record.Add("Details", itemRecords);
        record.Add("Notes", invoice.Notes);

        using var ms = new MemoryStream();
        var writer = new BinaryEncoder(ms);
        var datumWriter = new GenericWriter<GenericRecord>(invoiceSchema);
        datumWriter.Write(record, writer);
        writer.Flush();

        return ms.ToArray();
    }

    private static byte[] DecimalToBytes(decimal value, int scale)
    {
        var unscaled = (BigInteger)(value * (decimal)Math.Pow(10, scale));
        var bytes = unscaled.ToByteArray();
        Array.Reverse(bytes); // Avro uses big-endian
        return bytes;
    }

    private static AvroDecimal ToAvroDecimal(decimal value, int scale)
    {
        var unscaledValue = (BigInteger)(value * (decimal)Math.Pow(10, scale));
        return new AvroDecimal(unscaledValue, scale);
    }

    private static decimal FromAvroDecimal(object avroDecimalObj, int scale)
    {
        if (avroDecimalObj is AvroDecimal avroDecimal)
        {
            return (decimal)avroDecimal.UnscaledValue / (decimal)Math.Pow(10, avroDecimal.Scale);
        }

        throw new InvalidCastException("Expected AvroDecimal.");
    }

    public static Invoice DeserializeComplexObject(byte[] buffer)
    {
        using var ms = new MemoryStream(buffer);
        var reader = new BinaryDecoder(ms);
        var datumReader = new GenericReader<GenericRecord>(invoiceSchema, invoiceSchema);
        var deserializedRecord = datumReader.Read(null, reader);

        // ───── Parse Vendor ─────
        var vendorRecord = (GenericRecord)deserializedRecord["Vendor"];
        var vendor = new Vendor
        {
            VendorId = (int)vendorRecord["VendorId"],
            CompanyName = (string)vendorRecord["CompanyName"],
            ContactPerson = (string)vendorRecord["ContactPerson"],
            Address = (string)vendorRecord["Address"],
            Email = (string)vendorRecord["Email"],
            Phone = (string)vendorRecord["Phone"],
            TaxNumber = (string)vendorRecord["TaxNumber"],
            BankAccount = (string)vendorRecord["BankAccount"]
        };

        // ───── Parse Customer ─────
        var customerRecord = (GenericRecord)deserializedRecord["Customer"];
        var customer = new Customer
        {
            CustomerId = (int)customerRecord["CustomerId"],
            CompanyName = (string)customerRecord["CompanyName"],
            ContactPerson = (string)customerRecord["ContactPerson"],
            Address = (string)customerRecord["Address"],
            Email = (string)customerRecord["Email"],
            Phone = (string)customerRecord["Phone"]
        };

        // ───── Parse InvoiceItems ─────
        var details = ((IList<object>)deserializedRecord["Details"])
            .Cast<GenericRecord>()
            .Select(r => new InvoiceItem
            {
                Description = (string)r["Description"],
                Quantity = (int)r["Quantity"],
                UnitPrice = FromAvroDecimal(r["UnitPrice"], scale: 2),
                TaxRate = FromAvroDecimal(r["TaxRate"], scale: 4)
            })
            .ToList();

        // ───── Construct Invoice ─────
        var invoice = new Invoice
        {
            Id = (int)deserializedRecord["Id"],
            InvoiceNumber = (string)deserializedRecord["InvoiceNumber"],
            InvoiceDate = DateTimeOffset.FromUnixTimeMilliseconds((long)deserializedRecord["InvoiceDate"]).UtcDateTime,
            DueDate = DateTimeOffset.FromUnixTimeMilliseconds((long)deserializedRecord["DueDate"]).UtcDateTime,
            Vendor = vendor,
            Customer = customer,
            Details = details,
            Notes = (string)deserializedRecord["Notes"]
        };

        return invoice;
    }

    public static byte[] SerializeComplexObjectList(List<Invoice> items)
    {
        using var memoryStream = new MemoryStream();
        var writer = new BinaryEncoder(memoryStream);
        var datumWriter = new GenericWriter<GenericRecord>(invoiceSchema);

        foreach (var invoice in items)
        {
            var record = new GenericRecord((RecordSchema)invoiceSchema);

            // Vendor record
            var vendorSchema = ((RecordSchema)invoiceSchema)["Vendor"].Schema as RecordSchema;
            var vendorRecord = new GenericRecord(vendorSchema);
            vendorRecord.Add("VendorId", invoice.Vendor.VendorId);
            vendorRecord.Add("CompanyName", invoice.Vendor.CompanyName);
            vendorRecord.Add("ContactPerson", invoice.Vendor.ContactPerson);
            vendorRecord.Add("Address", invoice.Vendor.Address);
            vendorRecord.Add("Email", invoice.Vendor.Email);
            vendorRecord.Add("Phone", invoice.Vendor.Phone);
            vendorRecord.Add("TaxNumber", invoice.Vendor.TaxNumber);
            vendorRecord.Add("BankAccount", invoice.Vendor.BankAccount);

            // Customer record
            var customerSchema = ((RecordSchema)invoiceSchema)["Customer"].Schema as RecordSchema;
            var customerRecord = new GenericRecord(customerSchema);
            customerRecord.Add("CustomerId", invoice.Customer.CustomerId);
            customerRecord.Add("CompanyName", invoice.Customer.CompanyName);
            customerRecord.Add("ContactPerson", invoice.Customer.ContactPerson);
            customerRecord.Add("Address", invoice.Customer.Address);
            customerRecord.Add("Email", invoice.Customer.Email);
            customerRecord.Add("Phone", invoice.Customer.Phone);

            // Details array
            var itemSchema = ((ArraySchema)((RecordSchema)invoiceSchema)["Details"].Schema).ItemSchema as RecordSchema;
            var itemRecords = invoice.Details.Select(item =>
            {
                var itemRecord = new GenericRecord(itemSchema);
                itemRecord.Add("Description", item.Description);
                itemRecord.Add("Quantity", item.Quantity);
                itemRecord.Add("UnitPrice", ToAvroDecimal(item.UnitPrice, scale: 2));
                itemRecord.Add("TaxRate", ToAvroDecimal(item.TaxRate, scale: 4));
                return itemRecord;
            }).ToArray();

            // Main invoice record
            var invoiceDateTotalTicks = invoice.InvoiceDate.ToUniversalTime().Ticks / TimeSpan.TicksPerMillisecond;
            var invoiceDueTotalTicks = invoice.DueDate.ToUniversalTime().Ticks / TimeSpan.TicksPerMillisecond;

            record.Add("Id", invoice.Id);
            record.Add("InvoiceNumber", invoice.InvoiceNumber);
            record.Add("InvoiceDate", invoiceDateTotalTicks);
            record.Add("DueDate", invoiceDueTotalTicks);
            record.Add("Vendor", vendorRecord);
            record.Add("Customer", customerRecord);
            record.Add("Details", itemRecords);
            record.Add("Notes", invoice.Notes);

            datumWriter.Write(record, writer);
        }

        writer.Flush();

        return memoryStream.ToArray();
    }

    public static Invoice[] DeserializeComplexObjectList(byte[] buffer)
    {
        using var ms = new MemoryStream(buffer);
        var reader = new BinaryDecoder(ms);
        var datumReader = new GenericReader<GenericRecord>(invoiceSchema, invoiceSchema);

        var records = new List<Invoice>();
        while (ms.Position < ms.Length)
        {
            var deserializedRecord = datumReader.Read((GenericRecord?)null, reader);

            // ───── Parse Vendor ─────
            var vendorRecord = (GenericRecord)deserializedRecord["Vendor"];
            var vendor = new Vendor
            {
                VendorId = (int)vendorRecord["VendorId"],
                CompanyName = (string)vendorRecord["CompanyName"],
                ContactPerson = (string)vendorRecord["ContactPerson"],
                Address = (string)vendorRecord["Address"],
                Email = (string)vendorRecord["Email"],
                Phone = (string)vendorRecord["Phone"],
                TaxNumber = (string)vendorRecord["TaxNumber"],
                BankAccount = (string)vendorRecord["BankAccount"]
            };

            // ───── Parse Customer ─────
            var customerRecord = (GenericRecord)deserializedRecord["Customer"];
            var customer = new Customer
            {
                CustomerId = (int)customerRecord["CustomerId"],
                CompanyName = (string)customerRecord["CompanyName"],
                ContactPerson = (string)customerRecord["ContactPerson"],
                Address = (string)customerRecord["Address"],
                Email = (string)customerRecord["Email"],
                Phone = (string)customerRecord["Phone"]
            };

            // ───── Parse InvoiceItems ─────
            var details = ((IList<object>)deserializedRecord["Details"])
                .Cast<GenericRecord>()
                .Select(r => new InvoiceItem
                {
                    Description = (string)r["Description"],
                    Quantity = (int)r["Quantity"],
                    UnitPrice = FromAvroDecimal(r["UnitPrice"], scale: 2),
                    TaxRate = FromAvroDecimal(r["TaxRate"], scale: 4)
                })
                .ToList();

            // ───── Construct Invoice ─────
            var invoice = new Invoice
            {
                Id = (int)deserializedRecord["Id"],
                InvoiceNumber = (string)deserializedRecord["InvoiceNumber"],
                InvoiceDate = DateTimeOffset.FromUnixTimeMilliseconds((long)deserializedRecord["InvoiceDate"]).UtcDateTime,
                DueDate = DateTimeOffset.FromUnixTimeMilliseconds((long)deserializedRecord["DueDate"]).UtcDateTime,
                Vendor = vendor,
                Customer = customer,
                Details = details,
                Notes = (string)deserializedRecord["Notes"]
            };

            records.Add(invoice);
        }

        return records.ToArray();
    }
}
