using Bit_Reader_Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZW
{
    internal class Decoder
    {
        private BitReader bitReader;
        private BitWriter bitWriter;
        private long fileLength;
        private long fileLengthInBits;
        private string encoderInputFilePath;
        private string encoderOutputFilePath;
        private List<string> defaultSymbolsDictionary;
        private List<string> symbolsDictionary;
        private int indicesSizeInBits;
        private bool dictionaryType;

        public Decoder()
        {

        }

        public void InitialiseDecoder(string inputFilePath, string outputFilePath)
        {
            bitReader = new BitReader(inputFilePath);
            bitWriter = new BitWriter(outputFilePath);
            fileLength = bitReader.GetFileLengthInBytes();
            fileLengthInBits = fileLength * 8;

            defaultSymbolsDictionary = new List<string>();
            for (int i = 0; i < 256; i++)
            {
                char symbol = Convert.ToChar(i);
                defaultSymbolsDictionary.Add(symbol.ToString());
            }

            encoderInputFilePath = inputFilePath;
            encoderOutputFilePath = outputFilePath;

            uint value = bitReader.ReadNBits(4);
            indicesSizeInBits = (int)value;
            value = bitReader.ReadNBits(1);
            dictionaryType = Convert.ToBoolean(value);
        }

        public void DecodeFile()
        {
            int symbolSize = indicesSizeInBits;
            long numberOfRemainingBits = fileLengthInBits - 5;

            symbolsDictionary = defaultSymbolsDictionary.ToList();

            string endOfFile = Convert.ToChar(26).ToString();

            uint value = bitReader.ReadNBits(symbolSize);
            string lastSymbol = symbolsDictionary[(int)value];

            do
            {
                value = bitReader.ReadNBits(symbolSize);

                var currentSymbol = symbolsDictionary[(int)value];
                symbolsDictionary.Add(lastSymbol + currentSymbol[0]);
                
                foreach (char character in lastSymbol)
                {
                    bitWriter.WriteNBits(8, Convert.ToUInt32(character));
                }
                lastSymbol = currentSymbol;

            } while (lastSymbol != endOfFile);


            bitReader.CloseFile();
            bitWriter.CloseFile();
        }

    }
}
