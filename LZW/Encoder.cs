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
        private List<string> defaultSymbolsDictionary;
        private List<string> symbolsDictionary;
        private int indicesSizeInBits;
        private bool dictionaryType;

        private bool[] symbolExists = new bool[256];

        public Encoder()
        {

        }

        public void InitialiseEncoder(string inputFilePath, string outputFilePath)
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
        }

        public void SetIndicesSize(int size)
        {
            indicesSizeInBits = size;
        }

        public void SetDictionaryType(bool type)
        {
            dictionaryType = type;
        }

        public void CreateHeader()
        {
            bitWriter.WriteNBits(4, (uint)indicesSizeInBits);
            bitWriter.WriteNBits(1, Convert.ToUInt32(dictionaryType));
        }

        public void EncodeFile()
        {
            CreateHeader();

            int symbolSize = 8;
            long numberOfRemainingBits = fileLengthInBits;
            long encodedFileSizeInBits = 5;

            string symbolGroup = string.Empty; char currentSymbol;

            uint symbolIndex = 0;

            int maxIndexValue = (int)Math.Pow(2, indicesSizeInBits) - 1;
            symbolsDictionary = defaultSymbolsDictionary.ToList();

            do
            {
                uint value = bitReader.ReadNBits(symbolSize);
                currentSymbol = (char)value;
                symbolExists[currentSymbol] = true;

                if (symbolsDictionary.Contains(symbolGroup + currentSymbol))
                {
                    symbolIndex = (uint)symbolsDictionary.IndexOf(symbolGroup + currentSymbol);
                    symbolGroup = symbolGroup + currentSymbol;
                }
                else
                {
                    bitWriter.WriteNBits(indicesSizeInBits, symbolIndex);
                    encodedFileSizeInBits += indicesSizeInBits;
                    if (dictionaryType == false)
                    {
                        if (symbolsDictionary.Count <= maxIndexValue)
                        {
                            symbolsDictionary.Add(symbolGroup + currentSymbol);
                        }
                    }
                    else
                    {
                        if (symbolsDictionary.Count > maxIndexValue)
                        {
                            symbolsDictionary = defaultSymbolsDictionary.ToList();
                        }
                        symbolsDictionary.Add(symbolGroup + currentSymbol);
                    }
                    symbolGroup = "" + currentSymbol;
                    symbolIndex = value;
                }
                numberOfRemainingBits -= symbolSize;

            } while (numberOfRemainingBits > 0);

            bitWriter.WriteNBits(indicesSizeInBits, Convert.ToUInt32(currentSymbol));
            encodedFileSizeInBits += indicesSizeInBits;

            bitWriter.WriteNBits(indicesSizeInBits, (uint)26);
            encodedFileSizeInBits += indicesSizeInBits;

            if ((encodedFileSizeInBits % 8) != 0)
            {
                bitWriter.WriteNBits((int)(8 - encodedFileSizeInBits % 8), 0);
            }

            bitReader.CloseFile();
            bitWriter.CloseFile();

        }

        public void DisplaySymbolCodes(ListBox listBox)
        {
            for (int i = 0; i < 256; i++)
            {
                if (symbolExists[i])
                {
                    listBox.Items.Add(i + ": " + Convert.ToChar(i));
                }
            }
            for (int i = 256; i < symbolsDictionary.Count; i++)
            {
                listBox.Items.Add(i + ": " + symbolsDictionary[i]);
            }
        }
    }
}
