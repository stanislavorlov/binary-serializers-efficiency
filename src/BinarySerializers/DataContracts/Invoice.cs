using MessagePack;
using ProtoBuf;

namespace BinarySerializers.Contracts;

[MessagePackObject]
[ProtoContract]
public class Invoice
{
    [Key(0)]
    [ProtoMember(1)]
    public int Id { get; set; }

    [Key(1)]
    [ProtoMember(2)]
    public required string InvoiceNumber { get; set; }

    [Key(2)]
    [ProtoMember(3)]
    public required DateTime InvoiceDate { get; set; }

    [Key(3)]
    [ProtoMember(4)]
    public required DateTime DueDate { get; set; }

    [Key(4)]
    [ProtoMember(5)]
    public required Vendor Vendor { get; set; }

    [Key(5)]
    [ProtoMember(6)]
    public required Customer Customer { get; set; }

    [Key(6)]
    [ProtoMember(7)]
    public required List<InvoiceItem> Details { get; set; }

    [Key(7)]
    [ProtoMember(8)]
    public required string Notes { get; set; }
}

[MessagePackObject]
[ProtoContract]
public class Vendor
{
    [Key(0)]
    [ProtoMember(1)]
    public required int VendorId { get; set; }

    [Key(1)]
    [ProtoMember(2)]
    public required string CompanyName { get; set; }

    [Key(2)]
    [ProtoMember(3)]
    public required string ContactPerson { get; set; }

    [Key(3)]
    [ProtoMember(4)]
    public required string Address { get; set; }

    [Key(4)]
    [ProtoMember(5)]
    public required string Email { get; set; }

    [Key(5)]
    [ProtoMember(6)]
    public required string Phone { get; set; }

    [Key(6)]
    [ProtoMember(7)]
    public required string TaxNumber { get; set; }

    [Key(7)]
    [ProtoMember(8)]
    public required string BankAccount { get; set; }
}

[MessagePackObject]
[ProtoContract]
public class Customer
{
    [Key(0)]
    [ProtoMember(1)]
    public required int CustomerId { get; set; }

    [Key(1)]
    [ProtoMember(2)]
    public required string CompanyName { get; set; }

    [Key(2)]
    [ProtoMember(3)]
    public required string ContactPerson { get; set; }

    [Key(3)]
    [ProtoMember(4)]
    public required string Address { get; set; }

    [Key(4)]
    [ProtoMember(5)]
    public required string Email { get; set; }

    [Key(5)]
    [ProtoMember(6)]
    public required string Phone { get; set; }
}

[MessagePackObject]
[ProtoContract]
public class InvoiceItem
{
    [Key(0)]
    [ProtoMember(1)]
    public required string Description { get; set; }

    [Key(1)]
    [ProtoMember(2)]
    public required int Quantity { get; set; }

    [Key(2)]
    [ProtoMember(3)]
    public required decimal UnitPrice { get; set; }

    [Key(3)]
    [ProtoMember(4)]
    public required decimal TaxRate { get; set; } // 0.05 = 5%, 0.2 = 20%, etc.
}