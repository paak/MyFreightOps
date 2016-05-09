using FluentValidation.Attributes;
using FreightOps.DTO.Validator;
using System;
using Newtonsoft;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using FreightOps.DTO.MyJsonConverter;

namespace FreightOps.DTO
{
    /*
    Type    Represents                      Range                                                       Default Value
    bool    Boolean value                   True or False                                               False
    byte    8-bit unsigned integer          0 to 255                                                    0
    char    16-bit Unicode character        U +0000 to U +ffff                                          '\0'
    decimal 128-bit precise decimal values
            with 28-29 significant digits   (-7.9 x 1028 to 7.9 x 1028) / 100 to 28                     0.0M
    double  64-bit double-precision
            floating point type             (+/-)5.0 x 10-324 to (+/-)1.7 x 10308                       0.0D
    float   32-bit single-precision
            floating point type             -3.4 x 1038 to + 3.4 x 1038                                 0.0F
    int     32-bit signed integer type      -2,147,483,648 to 2,147,483,647                             0
    long    64-bit signed integer type      -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807     0L
    sbyte   8-bit signed integer type       -128 to 127                                                 0
    short   16-bit signed integer type      -32,768 to 32,767                                           0
    uint    32-bit unsigned integer type	0 to 4,294,967,295                                          0
    ulong   64-bit unsigned integer type	0 to 18,446,744,073,709,551,615                             0
    ushort  16-bit unsigned integer type	0 to 65,535                                                 0
    */
    [Validator(typeof(MyDTOValidator))]
    public class MyDTO
    {
        //[Required]
        //[JsonConverter(typeof(IntConverter))]
        public int Id { get; set; }
        public bool IsActivated { get; set; }
        public byte MyByte { get; set; }
        public char MyChar { get; set; }
        public Nullable<DateTime> MyDateTime { get; set; }
        public decimal MyDecimal { get; set; }
        public double MyDouble { get; set; }
        public float MyFloat { get; set; }
        public long MyLong { get; set; }

        //public sbyte MySByte { get; set; }
        public short MyShort { get; set; }

        //[Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        //public uint MyUInt { get; set; }
        //public ulong MyULong { get; set; }
        //public ushort MyUShort { get; set; }

        public MyDTO()
        {
        }
    }
}