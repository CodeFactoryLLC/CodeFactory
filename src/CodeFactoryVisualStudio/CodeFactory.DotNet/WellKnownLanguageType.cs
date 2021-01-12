//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Enumeration that identifies well know types used by various .net languages.
    /// </summary>
    public enum WellKnownLanguageType
    {
        /// <summary>
        /// The language type definition is not well known (Default Value)
        /// </summary>
        NotWellKnown = 0,

        /// <summary>
        /// Implements the well known type <see cref="System.Object"/>.
        /// </summary>
        Object = 1,

        /// <summary>
        /// Is a special return type that specifies no value will be returned. <see cref="System.Void"/>
        /// </summary>
        Void = 2,

        /// <summary>
        /// The well known data type of <see cref="System.Boolean"/>
        /// </summary>
        Boolean = 3,

        /// <summary>
        /// The well know data type of <see cref="System.Char"/> that stores a character.
        /// </summary>
        Character = 4,

        /// <summary>
        /// The well know data type is a signed 8 bit integer -128 to 127 <see cref="System.SByte"/>.
        /// </summary>
        Signed8BitInteger = 5,

        /// <summary>
        /// The well know data type is an unsigned 8 bit integer 0 to 255 <see cref="System.Byte"/>
        /// </summary>
        UnSigned8BitInteger = 6,

        /// <summary>
        /// The well known data type is a signed 16 bit integer -32,768 to 32,767 <see cref="System.Int16"/>
        /// </summary>
        Signed16BitInteger = 7,

        /// <summary>
        /// The well know data type is a unsigned 16 bit integer 0 to 65,535 <see cref="System.UInt16"/>
        /// </summary>
        Unsigned16BitInteger = 8,

        /// <summary>
        /// The well known data type is a signed 32 bit integer -2,147,483,648 to 2,147,483,647 <see cref="System.Int32"/>
        /// </summary>
        Signed32BitInteger = 9,

        /// <summary>
        /// The well know data type is a unsigned 32 bit integer 0 to 4,294,967,295 <see cref="System.UInt32"/>
        /// </summary>
        Unsigned32BitInteger = 10,

        /// <summary>
        /// The well known data type is a signed 64 bit integer -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 <see cref="System.Int64"/>
        /// </summary>
        Signed64BitInteger = 11,

        /// <summary>
        /// The well known data type is a unsigned 64 bit integer 0 to 18,446,744,073,709,551,615 <see cref="System.UInt64"/>
        /// </summary>
        Unsigned64BitInteger = 12,

        /// <summary>
        /// The well known data type is a decimal floating point number ±1.0 x 10-28 to ±7.9228 x 10 to the 28 power  <see cref="System.Decimal"/>
        /// </summary>
        Decimal = 13,

        /// <summary>
        /// The well known data type is a single precision floating point number ±1.5 x 10−45 to ±3.4 x 10 to the 38 power <see cref="System.Single"/>
        /// </summary>
        Single = 14,

        /// <summary>
        /// The well known data type is a double precision floating point number ±5.0 × 10−324 to ±1.7 × 10 to the 308 power <see cref="System.Double"/>
        /// </summary>
        Double = 15,

        /// <summary>
        /// Well known type that is used to represent the location of a pointer or handle <see cref="System.IntPtr"/>
        /// </summary>
        Pointer = 16,

        /// <summary>
        /// Well known type that represents a pointer that is platform specific <see cref="System.UIntPtr"/>
        /// </summary>
        PlatformPointer = 17,

        /// <summary>
        /// Well known type that holds a date and a time <see cref="System.DateTime"/>
        /// </summary>
        DateTime = 18,

        /// <summary>
        /// Well know type that contains an immutable sequence of UTF-16 code units <see cref="System.String"/>
        /// </summary>
        String = 19

    }
}
