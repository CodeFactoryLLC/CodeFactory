//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Enumeration that identifies well know types used by the C# language.
    /// </summary>
    public enum CsKnownLanguageType
    {
        /// <summary>
        /// The language type definition is not well known (Default Value)
        /// </summary>
        NotWellKnown = WellKnownLanguageType.NotWellKnown,

        /// <summary>
        /// Implements the well known type <see cref="System.Object"/>.
        /// </summary>
        Object = WellKnownLanguageType.Object,

        /// <summary>
        /// Is a special return type that specifies no value will be returned. <see cref="System.Void"/>
        /// </summary>
        Void = WellKnownLanguageType.Void,

        /// <summary>
        /// The well known data type of <see cref="System.Boolean"/>
        /// </summary>
        Boolean = WellKnownLanguageType.Boolean,

        /// <summary>
        /// The well know data type of <see cref="System.Char"/> that stores a character.
        /// </summary>
        Character = WellKnownLanguageType.Character,

        /// <summary>
        /// The well know data type is a signed 8 bit integer -128 to 127 <see cref="System.SByte"/>.
        /// </summary>
        Signed8BitInteger = WellKnownLanguageType.Signed8BitInteger,

        /// <summary>
        /// The well know data type is an unsigned 8 bit integer 0 to 255 <see cref="System.Byte"/>
        /// </summary>
        UnSigned8BitInteger = WellKnownLanguageType.UnSigned8BitInteger,

        /// <summary>
        /// The well known data type is a signed 16 bit integer -32,768 to 32,767 <see cref="System.Int16"/>
        /// </summary>
        Signed16BitInteger = WellKnownLanguageType.Signed16BitInteger,

        /// <summary>
        /// The well know data type is a unsigned 16 bit integer 0 to 65,535 <see cref="System.UInt16"/>
        /// </summary>
        Unsigned16BitInteger = WellKnownLanguageType.Unsigned16BitInteger,

        /// <summary>
        /// The well known data type is a signed 32 bit integer -2,147,483,648 to 2,147,483,647 <see cref="System.Int32"/>
        /// </summary>
        Signed32BitInteger = WellKnownLanguageType.Signed32BitInteger,

        /// <summary>
        /// The well know data type is a unsigned 32 bit integer 0 to 4,294,967,295 <see cref="System.UInt32"/>
        /// </summary>
        Unsigned32BitInteger = WellKnownLanguageType.Unsigned32BitInteger,

        /// <summary>
        /// The well known data type is a signed 64 bit integer -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 <see cref="System.Int64"/>
        /// </summary>
        Signed64BitInteger = WellKnownLanguageType.Signed64BitInteger,

        /// <summary>
        /// The well known data type is a unsigned 64 bit integer 0 to 18,446,744,073,709,551,615 <see cref="System.UInt64"/>
        /// </summary>
        Unsigned64BitInteger = WellKnownLanguageType.Unsigned64BitInteger,

        /// <summary>
        /// The well known data type is a decimal floating point number ±1.0 x 10-28 to ±7.9228 x 10 to the 28 power  <see cref="System.Decimal"/>
        /// </summary>
        Decimal = WellKnownLanguageType.Decimal,

        /// <summary>
        /// The well known data type is a single precision floating point number ±1.5 x 10−45 to ±3.4 x 10 to the 38 power <see cref="System.Single"/>
        /// </summary>
        Single = WellKnownLanguageType.Single,

        /// <summary>
        /// The well known data type is a double precision floating point number ±5.0 × 10−324 to ±1.7 × 10 to the 308 power <see cref="System.Double"/>
        /// </summary>
        Double = WellKnownLanguageType.Double,

        
        /// <summary>
        /// Well known type that is used to represent the location of a pointer or handle <see cref="System.IntPtr"/>
        /// </summary>
        Pointer = WellKnownLanguageType.Pointer,

        /// <summary>
        /// Well known type that represents a pointer that is platform specific <see cref="System.UIntPtr"/>
        /// </summary>
        PlatformPointer = WellKnownLanguageType.PlatformPointer,

        /// <summary>
        /// Well known type that holds a date and a time <see cref="System.DateTime"/>
        /// </summary>
        DateTime = WellKnownLanguageType.DateTime,

        /// <summary>
        /// Well know type that contains an immutable sequence of UTF-16 code units <see cref="System.String"/>
        /// </summary>
        String = WellKnownLanguageType.String

    }
}
