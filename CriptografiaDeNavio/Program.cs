using System;

class Program
{
    static void Main()
    {
        var encryptedMessage = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 " +
            "00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";

        var decryptedBinary = DecryptMessage(encryptedMessage);
        var decryptedText = ConvertBinaryToText(decryptedBinary);
        Console.WriteLine(decryptedText);
    }

    static string DecryptMessage(string encryptedMessage)
    {
        string[] encryptedMessageChunks = encryptedMessage.Split(' ');
        var decryptedBinary = "";

        foreach (string chunk in encryptedMessageChunks)
        {
            decryptedBinary += SwapNumberPositions(chunk);
        }

        return decryptedBinary;
    }

    static string SwapNumberPositions(string binaryChunk)
    {
        char[] bits = binaryChunk.ToCharArray();

        char temp = bits[6];
        bits[6] = bits[7];
        bits[7] = temp;

        for (int i = 0; i < 4; i++)
        {
            temp = bits[i];
            bits[i] = bits[i + 4];
            bits[i + 4] = temp;
        }

        return new string(bits);
    }

    static string ConvertBinaryToText(string binaryToConvert)
    {
        var decodedText = "";

        for (int i = 0; i < binaryToConvert.Length; i += 8)
        {
            string binaryByte = binaryToConvert.Substring(i, 8);
            char asciiChar = (char)Convert.ToInt32(binaryByte, 2);
            decodedText += asciiChar;
        }

        return decodedText;
    }
}