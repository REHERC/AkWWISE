﻿using AkWWISE.Core;
using AkWWISE.Core.DataStruct;

namespace AkWWISE.IO.Interfaces
{
    public interface IReader
    {
        long Position { get; }

        long Length { get; }

        Endianness Endianness { get; set; }

        byte[] Xorpad { get; set; }

        bool IsEOF();

        long Seek(long offset);

        long Skip(long bytes);

        void PushOffset();

        long PopOffset();

        Endianness GuessEndianness(long offset);

        Endianness GuessEndianness();
        #region Read Methods
        byte[] ReadGAP(int bytes);

        string ReadSTR(int size);

        string ReadSTZ();

        double ReadD64();

        float ReadF32();

        long ReadS64();

        ulong ReadU64();

        int ReadS32();

        uint ReadU32();

        short ReadS16();

        ushort ReadU16();

        sbyte ReadS8();

        byte ReadU8();

        FourCC Read4CC();

        uint ReadSID();

        uint ReadTID();
        #endregion
    }
}
