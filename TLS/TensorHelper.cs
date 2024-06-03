
using System.Text;

namespace TensorLatticeEncryption;
public static class TensorHelper
{
    // Function to generate a random tensor
    public static float[] GenerateRandomTensor(int length, Random rand)
    {
        float[] tensor = new float[length];
        for (int i = 0; i < length; i++)
        {
            tensor[i] = (float)rand.NextDouble() * 255;
        }
        return tensor;
    }

    // Function to generate a noise tensor
    public static float[] GenerateNoiseTensor(int length, double sigma, Random rand)
    {
        float[] noiseTensor = new float[length];
        for (int i = 0; i < length; i++)
        {
            noiseTensor[i] = (float)(rand.NextGaussian() * sigma);
        }
        return noiseTensor;
    }

    // Function to convert plain text to tensor, distributing data across all dimensions
    public static float[] TextToTensor(string text)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(text);
        int length = bytes.Length;
        float[] tensor = new float[length];
        for (int i = 0; i < length; i++)
        {
            tensor[i] = bytes[i];
        }
        return tensor;
    }

    // Function to convert tensor to plain text
    public static string TensorToText(float[] tensor)
    {
        byte[] bytes = tensor.Select(value => (byte)Math.Round(value)).ToArray();
        return Encoding.ASCII.GetString(bytes).TrimEnd('\0');
    }

    // Function to print tensor
    public static void PrintTensor(float[] tensor)
    {
        Console.WriteLine(string.Join(" ", tensor.Select(x => x.ToString("F2"))));
    }

    // Gaussian random number generator extension
    public static double NextGaussian(this Random rand)
    {
        double u1 = 1.0 - rand.NextDouble();
        double u2 = 1.0 - rand.NextDouble();
        return Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
    }
}