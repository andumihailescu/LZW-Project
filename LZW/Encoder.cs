using Bit_Reader_Writer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZW
{
    internal class Encoder
    {
        private BitReader bitReader;
        private BitWriter bitWriter;
        private long fileLength;
        private long fileLengthInBits;
        private string encoderInputFilePath;
        private string encoderOutputFilePath;
        private List<string> symbolsDictionary;
        private int indicesSizeInBits;

        public Encoder()
        {

        }

        public void InitialiseEncoder(string inputFilePath, string outputFilePath)
        {
            bitReader = new BitReader(inputFilePath);
            bitWriter = new BitWriter(outputFilePath);
            fileLength = bitReader.GetFileLengthInBytes();
            fileLengthInBits = fileLength * 8;

            symbolsDictionary = new List<string>();
            for (int i = 0; i < 256; i++)
            {
                char symbol = Convert.ToChar(i);
                symbolsDictionary.Add(symbol.ToString());
            }

            encoderInputFilePath = inputFilePath;
            encoderOutputFilePath = outputFilePath;
        }

        public void SetIndicesSize(int size)
        {
            indicesSizeInBits = size;
        }

        public void EncodeFile()
        {
            int symbolSize = 8;
            long numberOfRemainingBits = fileLengthInBits;

            string s = string.Empty; char ch;

            do
            {
                uint value = bitReader.ReadNBits(symbolSize);
                ch = (char)value;
                if (symbolsDictionary.Contains(s + ch)){
                    s = s + ch;
                }
                else
                {
                    //mai jos, in loc de s, trebuie scris indexul de unde pleaca s
                    bitWriter.WriteNBits(indicesSizeInBits, Convert.ToUInt32(s));
                    symbolsDictionary.Add(s + ch);
                    s = "" + ch;
                }
                numberOfRemainingBits -= symbolSize;

            } while (numberOfRemainingBits > 0);

            bitReader.CloseFile();
            bitWriter.CloseFile();

        }
    }
}
